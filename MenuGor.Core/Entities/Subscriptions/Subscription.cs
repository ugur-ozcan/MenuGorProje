using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Core.Entities.Subscriptions
{
    // Subscription.cs
    public class Subscription : BaseEntity
    {
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Company Company { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
