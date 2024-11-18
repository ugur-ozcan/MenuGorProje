// AllowedIp.cs
using MenuGor.Core.Entities;

public class AllowedIp : BaseEntity
{
    public string IpAddress { get; set; }
    public int? DealerId { get; set; }
    public int? CompanyId { get; set; }
    public int? BranchId { get; set; }

    // Navigation properties
    public virtual Dealer Dealer { get; set; }
    public virtual Company Company { get; set; }
    public virtual Branch Branch { get; set; }
}