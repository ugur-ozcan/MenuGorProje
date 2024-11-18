// MenuGor.Application/Interfaces/ICompanyService.cs
using MenuGor.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuGor.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyDto> GetCompanyBySlugAsync(string slug);
        Task<IEnumerable<CompanyDto>> GetCompaniesByDealerIdAsync(int dealerId);
        Task<IEnumerable<CompanyDto>> SearchCompaniesAsync(string searchTerm);
        Task<int> GetTotalCompanyCountAsync();
        Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto);
        Task UpdateCompanyAsync(CompanyDto companyDto);
        Task DeleteCompanyAsync(int id);
    }
}