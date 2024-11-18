using MenuGor.Application.DTOs;
using System.Collections.Generic;

namespace MenuGor.Web.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalAdminCount { get; set; }
        public int TotalCompanyCount { get; set; }
        public int TotalBranchCount { get; set; }
        public int TotalDealerCount { get; set; }
        public IEnumerable<AdminDto> Admins { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool ShowInactive { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string FilterBy { get; set; }
    }
}