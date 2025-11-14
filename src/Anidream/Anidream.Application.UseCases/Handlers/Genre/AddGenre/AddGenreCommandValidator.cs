using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Genre.AddGenre;

public sealed class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
{
    public AddGenreCommandValidator()
    {
        RuleFor(x => x.Request.Title).NotEmpty();
        RuleFor(x => x.Request.Alias).NotEmpty();
    }
}