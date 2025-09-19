using Microsoft.EntityFrameworkCore;

public class VacationOverlapException : Exception
{
    public VacationOverlapException(string message) : base(message) { }
}

public class VacationService
{
    private readonly ApplicationDbContext _db;
    public VacationService(ApplicationDbContext db) => _db = db;
    public async Task<VacationRequest> CreateAsync(VacationRequestCreateDto dto)
    {
        var employee = await _db.Employees.FindAsync(dto.EmployeeId);
        if (employee == null) throw new ArgumentException("Employee not found.");

        var start = dto.StartDate.Date;
        var end = dto.EndDate.Date;

        bool conflict = await _db.VacationRequests
            .Where(v => v.Approved && v.EmployeeId != dto.EmployeeId)
            .AnyAsync(v => v.StartDate <= end && v.EndDate >= start);

        if (conflict)
            throw new VacationOverlapException("Pedido de férias sobrepõe-se a férias aprovadas de outro colaborador.");

        var vr = new VacationRequest
        {
            EmployeeId = dto.EmployeeId,
            StartDate = start,
            EndDate = end,
            Notes = dto.Notes,
            Approved = true
        };

        _db.VacationRequests.Add(vr);
        await _db.SaveChangesAsync();
        return vr;
    }
}
