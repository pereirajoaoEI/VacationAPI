using System.ComponentModel.DataAnnotations;

public class VacationRequest
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    public string? Notes { get; set; }
    public bool Approved { get; set; } = true;
    
}
