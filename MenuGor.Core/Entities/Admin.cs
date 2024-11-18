

namespace MenuGor.Core.Entities
{
    // MenuGor.Core/Entities/Admin.cs
    public class Admin : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }
     }
}
