using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Media.UpdateMedia;

public class UpdateMediaCommandValidator : AbstractValidator<UpdateMediaCommand>
{
    public UpdateMediaCommandValidator()
    {
        RuleFor(x => x.Request.Title)
            .MaximumLength(250)
            .When(x => x is not null);;
        
        RuleFor(x => x.Request.Alias)
            .MaximumLength(250)
            .When(x => x is not null);;
        
        RuleFor(x => x.Request.Rating)
            .InclusiveBetween(0, 10)
            .When(x => x is not null);
        
        RuleFor(x => x.Request.TotalEpisodes)
            .GreaterThanOrEqualTo(0)
            .When(x => x is not null);
        
        RuleFor(x => x.Request.CurrentEpisodes)
            .GreaterThanOrEqualTo(0)
            .When(x => x is not null);
        
        RuleForEach(x => x.Request.GenresIds).NotEmpty();
    }
}