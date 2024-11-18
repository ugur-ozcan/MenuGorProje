namespace MenuGor.Core.Entities.Security
{
    // User.cs
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? DealerId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual Company Company { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
