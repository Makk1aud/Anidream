namespace Anidream.Api.Application.Core;

public interface IStorageConnectionProvider
{
    public string GetStorageImageFolderPath();
    public string GetStorageVideoFolderPath();
}