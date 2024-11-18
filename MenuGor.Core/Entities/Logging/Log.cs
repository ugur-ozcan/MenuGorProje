// Log.cs
 using MenuGor.Core.Entities.Security;
namespace MenuGor.Core.Entities.Logging
{ 
public class Log : BaseEntity
{
    public string Message { get; set; }
    public string Level { get; set; }
    public string Exception { get; set; }
    public string StackTrace { get; set; }
    public int? UserId { get; set; }
    public int? DealerId { get; set; }
    public int? CompanyId { get; set; }
    public int? BranchId { get; set; }
    public virtual User User { get; set; }
    public virtual Dealer Dealer { get; set; }
    public virtual Company Company { get; set; }
    public virtual Branch Branch { get; set; }
}
}