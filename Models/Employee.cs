using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public ICollection<VacationRequest> VacationRequests { get; set; } = new List<VacationRequest>();
}
