using MenuGor.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuGor.Application.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDto> CreateAdminAsync(AdminDto adminDto);
        Task<AdminDto> GetAdminByIdAsync(int id);
        Task<AdminDto> UpdateAdminAsync(AdminDto adminDto);
        Task<IEnumerable<AdminDto>> GetAllAdminsAsync();
        Task<bool> AuthenticateAsync(string username, string password);
        Task<int> GetTotalAdminCountAsync();
        Task<bool> DeleteAdminAsync(int id);
        Task<IEnumerable<AdminDto>> GetPagedAdminsAsync(
            int page,
            int pageSize,
            bool showInactive,
            string sortBy = "Username",
            string sortOrder = "asc",
            string filterBy = "");
    }
}