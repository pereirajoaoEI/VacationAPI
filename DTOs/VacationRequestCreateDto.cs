public class VacationRequestCreateDto
{
    public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; } // format: yyyy-MM-dd
    public DateTime EndDate { get; set; }
    public string? Notes { get; set; }
}

