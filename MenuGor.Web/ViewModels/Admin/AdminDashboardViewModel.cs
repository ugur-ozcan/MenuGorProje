namespace MenuGor.Web.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        public int TotalAdminCount { get; set; }
        public int TotalDealerCount { get; set; }
        public int TotalCompanyCount { get; set; }
        public int TotalBranchCount { get; set; }

        // İstatistikler için ek özellikler ekleyebilirsiniz
        public int ActiveCompanyCount { get; set; }
        public int InactiveCompanyCount { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}