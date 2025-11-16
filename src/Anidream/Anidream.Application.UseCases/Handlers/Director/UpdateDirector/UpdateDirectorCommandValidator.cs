using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Director.UpdateDirector;

public sealed class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(x => x.Request.FullName).NotEmpty().MaximumLength(100);
    }
}