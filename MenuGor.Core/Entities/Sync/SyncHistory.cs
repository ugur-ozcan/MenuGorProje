

namespace MenuGor.Core.Entities.Sync
{
    // SyncHistory.cs
    public class SyncHistory : BaseEntity
    {
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public DateTime SyncDate { get; set; }
        public string Status { get; set; } // Success, Failed, PartialSuccess
        public string Details { get; set; }
        public virtual Company Company { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
