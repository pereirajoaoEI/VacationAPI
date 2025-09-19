using FluentValidation;

public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
{
    public EmployeeCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
