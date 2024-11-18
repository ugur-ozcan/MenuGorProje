// File: MenuGor.Core/Interfaces/ICompanyRepository.cs

using MenuGor.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuGor.Core.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetCompanyBySlugAsync(string slug);
        Task<IEnumerable<Company>> GetCompaniesByDealerIdAsync(int dealerId);
        Task<bool> SlugExistsAsync(string slug);
        Task<IEnumerable<Company>> SearchCompaniesAsync(string searchTerm);
        Task<int> GetTotalCompanyCountAsync();
        Task<int> GetBranchCountForCompanyAsync(int companyId);

    }
}