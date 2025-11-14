using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Genre.UpdateGenre;

public sealed class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(x => x.Request.Title).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Request.Alias).NotEmpty().MaximumLength(50);
    }
}