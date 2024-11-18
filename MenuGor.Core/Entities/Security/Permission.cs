namespace MenuGor.Core.Entities.Security
{
    // Permission.cs
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
