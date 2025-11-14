using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaVideo;

public sealed class UploadMediaVideoCommandValidator : AbstractValidator<UploadMediaVideoCommand>
{
    public UploadMediaVideoCommandValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .Must(IsCorrectVideoExtension)
            .WithMessage($"Invalid video extension must {Constants.FileStorage.VideoExtension}");
        
        RuleFor(x => x.EpisodeNumber).NotEmpty();
        RuleFor(x => x.Alias).NotEmpty();
    }

    private static bool IsCorrectVideoExtension(string arg) => arg.EndsWith(Constants.FileStorage.VideoExtension);
}