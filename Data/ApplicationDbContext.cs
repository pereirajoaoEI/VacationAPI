using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts) { }
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<VacationRequest> VacationRequests { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Ana Silva", Email = "ana.silva@workflow.com" },
            new Employee { Id = 2, Name = "João Pereira", Email = "joao.pereira@workflow.com" },
            new Employee { Id = 3, Name = "Marta Fernandes", Email = "marta.fernandes@workflow.com" }
        );

        modelBuilder.Entity<VacationRequest>().HasData(
            new VacationRequest
            {
                Id = 1,
                EmployeeId = 1,
                StartDate = new DateTime(2025,8,1),
                EndDate = new DateTime(2025,8,5),
                Notes = "Primeiras férias do ano",
                Approved = true
            },
            new VacationRequest
            {
                Id = 2,
                EmployeeId = 3,
                StartDate = new DateTime(2025,8,10),
                EndDate = new DateTime(2025,8,15),
                Notes = "Viagem em família",
                Approved = true
            }
        );
    }
}
