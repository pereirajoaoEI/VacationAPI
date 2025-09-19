using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public EmployeesController(ApplicationDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDto dto)
    {
        var e = new Employee { Name = dto.Name, Email = dto.Email };
        _db.Employees.Add(e);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
    }

    [HttpGet]
    public async Task<IActionResult> List() => Ok(await _db.Employees.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var e = await _db.Employees.FindAsync(id);
        if (e == null) return NotFound();
        return Ok(e);
    }
}
