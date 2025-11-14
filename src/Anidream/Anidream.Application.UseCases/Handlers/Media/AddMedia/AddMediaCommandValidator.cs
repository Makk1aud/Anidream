using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Media.AddMedia;

public sealed class AddMediaCommandValidator : AbstractValidator<AddMediaCommand>
{
    public AddMediaCommandValidator()
    {
        RuleFor(x => x.Request.Title)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(x => x.Request.Alias)
            .NotEmpty()
            .MaximumLength(250);
        
        RuleFor(x => x.Request.Description)
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(x => x.Request.ReleaseDate)
            .NotEmpty();
        
        RuleFor(x => x.Request.Rating)
            .InclusiveBetween(0, 10)
            .When(x => x is not null);
        
        RuleFor(x => x.Request.TotalEpisodes)
            .GreaterThanOrEqualTo(0)
            .When(x => x is not null);
        
        RuleFor(x => x.Request.CurrentEpisodes)
            .GreaterThanOrEqualTo(0)
            .When(x => x is not null);
        
        RuleFor(x => x.Request.GenresIds).Must(HaveAnyItems);
    }
    
    private static bool HaveAnyItems(IReadOnlyCollection<Guid> genresIds) => genresIds.Any();
}