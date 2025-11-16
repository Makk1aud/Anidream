using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Director.AddDirector;

public sealed class AddDirectorCommandValidator : AbstractValidator<AddDirectorCommand>
{
    public AddDirectorCommandValidator()
    {
        RuleFor(x => x.Request.FullName).NotEmpty().MaximumLength(100);
    }
}