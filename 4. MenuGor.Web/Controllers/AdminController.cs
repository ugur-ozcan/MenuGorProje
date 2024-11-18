using MenuGor.Application.DTOs;
using MenuGor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MenuGor.Web.ViewModels.Admin;
using Microsoft.Extensions.Logging;

namespace MenuGor.Web.Controllers
{
    /// <summary>
    /// Admin işlemlerini yöneten controller sınıfı
    /// </summary>
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Admin giriş sayfasını gösterir
        /// </summary>
        [HttpGet("Login")]
        public IActionResult Login()
        {
            // Eğer kullanıcı zaten giriş yapmışsa dashboard'a yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }

        /// <summary>
        /// Admin giriş işlemini gerçekleştirir
        /// </summary>
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginDto adminDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(adminDto);
                }

                var isAuthenticated = await _adminService.AuthenticateAsync(adminDto.Username, adminDto.Password);
                if (isAuthenticated)
                {
                    _logger.LogInformation($"Başarılı giriş: {adminDto.Username}");
                    // TODO: Oturum yönetimi eklenecek
                    return RedirectToAction(nameof(Dashboard));
                }

                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre, ya da hesap aktif değil.");
                return View(adminDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Giriş hatası: {adminDto.Username}");
                ModelState.AddModelError(string.Empty, "Giriş işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                return View(adminDto);
            }
        }

        /// <summary>
        /// Admin dashboard sayfasını gösterir
        /// </summary>
        [HttpGet("Dashboard")]
        public async Task<IActionResult> Dashboard(AdminDashboardParameters parameters)
        {
            try
            {
                // Varsayılan değerleri ayarla
                parameters ??= new AdminDashboardParameters
                {
                    Page = 1,
                    PageSize = 10,
                    ShowInactive = false,
                    SortBy = "Username",
                    SortOrder = "asc"
                };

                // Verileri getir
                var adminCount = await _adminService.GetTotalAdminCountAsync();
                var admins = await _adminService.GetPagedAdminsAsync(
                    parameters.Page,
                    parameters.PageSize,
                    parameters.ShowInactive,
                    parameters.SortBy,
                    parameters.SortOrder,
                    parameters.FilterBy);

                // ViewModel oluştur
                var viewModel = new AdminDashboardViewModel
                {
                    TotalAdminCount = adminCount,
                    TotalCompanyCount = 0, // Şimdilik 0
                    TotalBranchCount = 0, // Şimdilik 0
                    TotalDealerCount = 0, // Şimdilik 0
                    ActiveCompanyCount = 0, // Şimdilik 0
                    InactiveCompanyCount = 0, // Şimdilik 0
                    LastLoginDate = DateTime.Now, // Şimdilik şu anki zaman
                    Admins = admins,
                    CurrentPage = parameters.Page,
                    PageSize = parameters.PageSize,
                    ShowInactive = parameters.ShowInactive,
                    SortBy = parameters.SortBy,
                    SortOrder = parameters.SortOrder,
                    FilterBy = parameters.FilterBy
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dashboard verilerini getirirken hata oluştu");
                // Kullanıcıya daha detaylı hata mesajı göster
                TempData["ErrorMessage"] = "Veriler yüklenirken bir hata oluştu. Lütfen sayfayı yenileyin veya daha sonra tekrar deneyin.";
                return View("Error");
            }
        }

        /// <summary>
        /// Yeni admin oluşturma sayfasını gösterir
        /// </summary>
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new AdminDto());
        }

        /// <summary>
        /// Yeni admin oluşturma işlemini gerçekleştirir
        /// </summary>
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminDto adminDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(adminDto);
                }

                await _adminService.CreateAdminAsync(adminDto);
                _logger.LogInformation($"Yeni admin oluşturuldu: {adminDto.Username}");
                TempData["SuccessMessage"] = "Admin başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Dashboard));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Admin oluşturma hatası: {adminDto.Username}");
                ModelState.AddModelError("", "Admin oluşturulurken bir hata oluştu. Lütfen tekrar deneyin.");
                return View(adminDto);
            }
        }
    }

    /// <summary>
    /// Dashboard parametreleri için yardımcı sınıf
    /// </summary>
    public class AdminDashboardParameters
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool ShowInactive { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string FilterBy { get; set; }
    }
}