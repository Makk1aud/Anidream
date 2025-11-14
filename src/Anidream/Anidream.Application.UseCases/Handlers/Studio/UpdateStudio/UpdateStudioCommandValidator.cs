using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Studio.UpdateStudio;

public sealed class UpdateStudioCommandValidator : AbstractValidator<UpdateStudioCommand>
{
    public UpdateStudioCommandValidator()
    {
        RuleFor(x => x.Request.Title).NotEmpty().MaximumLength(100);
    }
}