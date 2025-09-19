using FluentValidation;

public class VacationRequestCreateDtoValidator : AbstractValidator<VacationRequestCreateDto>
{
    public VacationRequestCreateDtoValidator()
    {
        RuleFor(x => x.EmployeeId).GreaterThan(0);
        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("StartDate must be on or before EndDate.");
    }
}
