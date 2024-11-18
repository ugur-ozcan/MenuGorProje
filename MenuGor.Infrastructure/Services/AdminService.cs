using AutoMapper;
using MenuGor.Application.DTOs;
using MenuGor.Application.Interfaces;
using MenuGor.Core.Entities;
using MenuGor.Core.Exceptions;
using MenuGor.Core.Interfaces;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;

    public AdminService(IAdminRepository adminRepository, IMapper mapper)
    {
        _adminRepository = adminRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminDto>> GetPagedAdminsAsync(
        int page,
        int pageSize,
        bool showInactive,
        string sortBy = "Username",
        string sortOrder = "asc",
        string filterBy = "")
    {
        var admins = await _adminRepository.ListAllAsync();
        var query = admins.AsQueryable();

        // Aktif/Pasif filtreleme
        if (!showInactive)
        {
            query = query.Where(a => a.IsActive);
        }

        // Filtreleme
        if (!string.IsNullOrEmpty(filterBy))
        {
            query = query.Where(a =>
                a.Username.Contains(filterBy, StringComparison.OrdinalIgnoreCase) ||
                a.Email.Contains(filterBy, StringComparison.OrdinalIgnoreCase));
        }

        // Sıralama
        query = sortOrder.ToLower() == "asc"
            ? sortBy.ToLower() switch
            {
                "email" => query.OrderBy(a => a.Email),
                "isactive" => query.OrderBy(a => a.IsActive),
                _ => query.OrderBy(a => a.Username)
            }
            : sortBy.ToLower() switch
            {
                "email" => query.OrderByDescending(a => a.Email),
                "isactive" => query.OrderByDescending(a => a.IsActive),
                _ => query.OrderByDescending(a => a.Username)
            };

        // Sayfalama
        return _mapper.Map<IEnumerable<AdminDto>>(
            query.Skip((page - 1) * pageSize)
                 .Take(pageSize)
                 .ToList()
        );
    }

    public async Task<AdminDto> CreateAdminAsync(AdminDto adminDto)
    {
        var admin = _mapper.Map<Admin>(adminDto);
        admin.CreatedBy = "System";
        admin.CreatedDate = DateTime.UtcNow;
        admin.IsDeleted = false;
        admin.DeletedBy = null;
        admin.DeletedDate = null;
        admin.IsActive = true;
        admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);

        var createdAdmin = await _adminRepository.AddAsync(admin);
        return _mapper.Map<AdminDto>(createdAdmin);
    }

    public async Task<AdminDto> GetAdminByIdAsync(int id)
    {
        var admin = await _adminRepository.GetByIdAsync(id);
        if (admin == null)
            throw new NotFoundException($"Admin with ID {id} not found");

        return _mapper.Map<AdminDto>(admin);
    }

    public async Task<AdminDto> UpdateAdminAsync(AdminDto adminDto)
    {
        var admin = await _adminRepository.GetByIdAsync(adminDto.Id);
        if (admin == null)
            throw new NotFoundException($"Admin with ID {adminDto.Id} not found");

        _mapper.Map(adminDto, admin);
        if (!string.IsNullOrEmpty(adminDto.Password))
            admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);

        await _adminRepository.UpdateAsync(admin);
        return _mapper.Map<AdminDto>(admin);
    }

    public async Task<IEnumerable<AdminDto>> GetAllAdminsAsync()
    {
        var admins = await _adminRepository.ListAllAsync();
        return _mapper.Map<IEnumerable<AdminDto>>(admins);
    }

    public async Task<bool> AuthenticateAsync(string username, string password)
    {
        var admin = await _adminRepository.GetByUsernameAsync(username);
        if (admin == null || !admin.IsActive || admin.IsDeleted)
            return false;

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash);
        if (isPasswordValid)
        {
            admin.LastLoginDate = DateTime.UtcNow;
            await _adminRepository.UpdateAsync(admin);
        }

        return isPasswordValid;
    }

    public async Task<int> GetTotalAdminCountAsync()
    {
        var admins = await _adminRepository.ListAllAsync();
        return admins.Count();
    }

    public async Task<bool> DeleteAdminAsync(int id)
    {
        try
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin == null)
                return false;

            admin.IsDeleted = true;
            admin.DeletedBy = "System";
            admin.DeletedDate = DateTime.UtcNow;
            admin.IsActive = false;

            await _adminRepository.UpdateAsync(admin);
            return true;
        }
        catch
        {
            return false;
        }
    }
}