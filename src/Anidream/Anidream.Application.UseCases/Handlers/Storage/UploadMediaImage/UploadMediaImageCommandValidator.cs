using FluentValidation;

namespace Anidream.Application.UseCases.Handlers.Storage.UploadMediaImage;

internal class UploadMediaImageCommandValidator : AbstractValidator<UploadMediaImageCommand>
{
    public UploadMediaImageCommandValidator()
    {
        RuleFor(x => x.Alias).NotEmpty();
        RuleFor(x => x.FileExtension).NotEmpty().Must(IsCorrectImageExtension);
    }
    
    private static bool IsCorrectImageExtension(string arg) => arg.EndsWith(Constants.FileStorage.ImageExtension);
}