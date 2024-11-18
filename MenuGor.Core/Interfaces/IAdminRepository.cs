using MenuGor.Core.Entities;
 

namespace MenuGor.Core.Interfaces
{
    // MenuGor.Core/Interfaces/IAdminRepository.cs
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> GetByUsernameAsync(string username);
        Task<Admin> GetByEmailAsync(string email);
        Task<int> CountAsync();

    }
}
