using System;
using System.Collections.Generic;
using MenuGor.Application.DTOs;

namespace MenuGor.Web.ViewModels.Admin
{
    /// <summary>
    /// Admin dashboard sayfası için view model
    /// </summary>
    public class AdminDashboardViewModel
    {
        // İstatistik özellikleri
        public int TotalAdminCount { get; set; }
        public int TotalDealerCount { get; set; }
        public int TotalCompanyCount { get; set; }
        public int TotalBranchCount { get; set; }
        public int ActiveCompanyCount { get; set; }
        public int InactiveCompanyCount { get; set; }
        public DateTime LastLoginDate { get; set; }

        // Sayfalama ve filtreleme özellikleri
        public IEnumerable<AdminDto> Admins { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool ShowInactive { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string FilterBy { get; set; }

        // Hesaplanan özellikler
        public int TotalPages => (int)Math.Ceiling((double)TotalAdminCount / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public AdminDashboardViewModel()
        {
            // Varsayılan değerleri ayarla
            Admins = new List<AdminDto>();
            CurrentPage = 1;
            PageSize = 10;
            SortBy = "Username";
            SortOrder = "asc";
            LastLoginDate = DateTime.Now;
        }
    }
}