using MenuGor.Application.DTOs;
using MenuGor.Application.Interfaces;
using MenuGor.Application.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AdminApiController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly ILogger<AdminApiController> _logger;

    public AdminApiController(IAdminService adminService, ILogger<AdminApiController> logger)
    {
        _adminService = adminService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Create()
    {
        // API endpoint'leri view döndürmez, bunun yerine veri döndürür
        return Ok(new { message = "Use POST method to create a new admin" });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AdminDto adminDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdAdmin = await _adminService.CreateAdminAsync(adminDto);
            return CreatedAtAction(nameof(GetAdmin), new { id = createdAdmin.Id }, createdAdmin);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating admin");
            return StatusCode(500, "Admin oluşturulurken bir hata oluştu.");
        }
    }

     [HttpGet("{id}")]
    public async Task<ActionResult<AdminDto>> GetAdmin(int id)
    {
        var admin = await _adminService.GetAdminByIdAsync(id);
        if (admin == null)
            return NotFound();

        return admin;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdmin(int id, [FromBody] AdminDto adminDto)
    {
        if (id != adminDto.Id)
            return BadRequest();

        await _adminService.UpdateAdminAsync(adminDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        await _adminService.DeleteAdminAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AdminDto>>> GetAllAdmins()
    {
        var admins = await _adminService.GetAllAdminsAsync();
        return Ok(admins);
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
    {
        var isAuthenticated = await _adminService.AuthenticateAsync(model.Username, model.Password);
        if (!isAuthenticated)
            return Unauthorized();

        // Burada JWT token oluşturma işlemi yapılabilir
        return Ok(new { message = "Authentication successful" });
    }
}