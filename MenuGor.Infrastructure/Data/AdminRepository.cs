// MenuGor.Infrastructure/Data/AdminRepository.cs
using MenuGor.Core.Entities;
using MenuGor.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MenuGor.Infrastructure.Data
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        private readonly MenuGorDbContext _dbContext;

        public AdminRepository(MenuGorDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Admin> GetByUsernameAsync(string username)
        {
            return await _context.Admins
                .Where(a => a.Username == username && !a.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<Admin> GetByEmailAsync(string email)
        {
            return await _dbContext.Set<Admin>()
                .FirstOrDefaultAsync(a => a.Email == email && !a.IsDeleted);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Admins.CountAsync();
        }

        public new async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

    }
}