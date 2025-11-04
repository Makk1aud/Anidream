namespace Anidream.Infrastructure.FileSystemStorage.Interfaces;

public interface IStorageConnectionProvider
{
    public string GetStorageImageFolderPath();
    public string GetStorageVideoFolderPath();
}