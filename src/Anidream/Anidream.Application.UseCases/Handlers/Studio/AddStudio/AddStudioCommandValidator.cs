using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Studio.AddStudio;

public sealed class AddStudioCommandValidator : AbstractValidator<AddStudioCommand>
{
    public AddStudioCommandValidator()
    {
        RuleFor(x => x.Request.Title).NotEmpty().MaximumLength(100);
    }
}