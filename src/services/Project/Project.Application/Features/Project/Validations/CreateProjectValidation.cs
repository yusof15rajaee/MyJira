using FluentValidation;
using Project.Application.Features.Project.Commands;

namespace Project.Application.Features.Project.Validations;

public class CreateProjectValidation : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidation()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} is required")
            .MinimumLength(20)
            .MaximumLength(500);
    }
}
