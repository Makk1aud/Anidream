using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaVideo;

internal class UploadMediaVideoCommandValidator : AbstractValidator<UploadMediaVideoCommand>
{
    public UploadMediaVideoCommandValidator()
    {
        RuleFor(x => x.FileName).NotEmpty().Must(IsCorrectVideoExtension);
        RuleFor(x => x.EpisodeNumber).NotEmpty();
        RuleFor(x => x.Alias).NotEmpty();
    }

    private static bool IsCorrectVideoExtension(string arg) => arg.EndsWith(Constants.FileStorage.VideoExtension);
}