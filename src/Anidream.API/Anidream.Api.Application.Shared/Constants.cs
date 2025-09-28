using System.Net.Mime;

namespace Anidream.Api.Application.Shared;

public class Constants
{
    public class FileStorage
    {
        public const string ImageExtension = ".jpg";
        public const string VideoExtension = ".mp4";
        public const string VideoContentType = "video/mp4";
        public const string ImageContentType = MediaTypeNames.Image.Jpeg;
    }
}