// File: MenuGor.Infrastructure/Data/CompanyRepository.cs

using MenuGor.Core.Entities;
using MenuGor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuGor.Infrastructure.Data
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(MenuGorDbContext context) : base(context)
        {
        }

        public async Task<Company> GetCompanyBySlugAsync(string slug)
        {
            return await _context.Companies
                .Include(c => c.Branches)
                .Select(c => new Company
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    DealerId = c.DealerId,
                    Branches = c.Branches,
                    BranchCount = c.Branches.Count
                })
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<IEnumerable<Company>> GetCompaniesByDealerIdAsync(int dealerId)
        {
            return await _context.Companies
                .Where(c => c.DealerId == dealerId)
                .Select(c => new Company
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    DealerId = c.DealerId,
                    BranchCount = c.Branches.Count
                })
                .ToListAsync();
        }

        public async Task<bool> SlugExistsAsync(string slug)
        {
            return await _context.Companies.AnyAsync(c => c.Slug == slug);
        }

        public async Task<IEnumerable<Company>> SearchCompaniesAsync(string searchTerm)
        {
            return await _context.Companies
                .Where(c => c.Name.Contains(searchTerm) || c.Slug.Contains(searchTerm))
                .Select(c => new Company
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug,
                    DealerId = c.DealerId,
                    BranchCount = c.Branches.Count
                })
                .ToListAsync();
        }

        public async Task<int> GetTotalCompanyCountAsync()
        {
            return await _context.Companies.CountAsync();
        }

        public async Task<int> GetBranchCountForCompanyAsync(int companyId)
        {
            return await _context.Branches.CountAsync(b => b.CompanyId == companyId);
        }
    }
}