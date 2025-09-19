using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VacationRequestsController : ControllerBase
{
    private readonly VacationService _svc;
    private readonly ApplicationDbContext _db;
    public VacationRequestsController(VacationService svc, ApplicationDbContext db)
    {
        _svc = svc;
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(VacationRequestCreateDto dto)
    {
        try
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (VacationOverlapException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var list = await _db.VacationRequests.Include(v => v.Employee).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vr = await _db.VacationRequests.Include(v => v.Employee).FirstOrDefaultAsync(v => v.Id == id);
        if (vr == null) return NotFound();
        return Ok(vr);
    }
}
