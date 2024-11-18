// File: MenuGor.Infrastructure/Services/CompanyService.cs
using AutoMapper;
using MenuGor.Application.DTOs;
using MenuGor.Application.Interfaces;
using MenuGor.Core.Entities;
using MenuGor.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public async Task<CompanyDto> GetCompanyBySlugAsync(string slug)
    {
        var company = await _companyRepository.GetCompanyBySlugAsync(slug);
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<IEnumerable<CompanyDto>> GetCompaniesByDealerIdAsync(int dealerId)
    {
        var companies = await _companyRepository.GetCompaniesByDealerIdAsync(dealerId);
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<IEnumerable<CompanyDto>> SearchCompaniesAsync(string searchTerm)
    {
        var companies = await _companyRepository.SearchCompaniesAsync(searchTerm);
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<int> GetTotalCompanyCountAsync()
    {
        return await _companyRepository.GetTotalCompanyCountAsync();
    }

    public async Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto)
    {
        var company = _mapper.Map<Company>(companyDto);
        var createdCompany = await _companyRepository.AddAsync(company);
        return _mapper.Map<CompanyDto>(createdCompany);
    }

    public async Task UpdateCompanyAsync(CompanyDto companyDto)
    {
        var company = _mapper.Map<Company>(companyDto);
        await _companyRepository.UpdateAsync(company);
    }

    public async Task DeleteCompanyAsync(int id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        if (company != null)
        {
            await _companyRepository.DeleteAsync(company);
        }
    }
}