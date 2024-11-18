using MenuGor.Application.DTOs;
using MenuGor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using MenuGor.Web.ViewModels.Admin;

public class AdminController : Controller
{
    private readonly IAdminService _adminService;
    private readonly ILogger<AdminController> _logger;

    public AdminController(IAdminService adminService, ILogger<AdminController> logger)
    {
        _adminService = adminService;
        _logger = logger;
    }

    // MVC Actions
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AdminLoginDto adminDto)
    {
        try
        {
            var isAuthenticated = await _adminService.AuthenticateAsync(adminDto.Username, adminDto.Password);
            if (isAuthenticated)
            {
                // Başarılı giriş, Dashboard'a yönlendir
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre, ya da hesap aktif değil.");
                return View(adminDto);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login attempt failed");
            ModelState.AddModelError(string.Empty, "Giriş işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            return View(adminDto);
        }
    }

    [HttpGet("Dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var adminCount = await _adminService.GetTotalAdminCountAsync();
        // Diğer istatistikleri de ekleyebilirsiniz (örneğin, toplam firma sayısı, toplam şube sayısı vb.)

        var viewModel = new AdminDashboardViewModel
        {
            TotalAdminCount = adminCount,
            // Diğer istatistikleri de ekleyin
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AdminDto adminDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _adminService.CreateAdminAsync(adminDto);
                TempData["SuccessMessage"] = "Admin başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating admin");
                ModelState.AddModelError("", "Admin oluşturulurken bir hata oluştu.");
            }
        }
        return View(adminDto);
    }
}



public class AuthenticateModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}