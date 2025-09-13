using Anidream.Api.Domain.Entities;

namespace Anidream.Api.Application.Extensions;

public static class MediaFilterExtensions
{
    public static IEnumerable<Media> FilterByTitle(this IEnumerable<Media> items, string? alias)
    {
        if(string.IsNullOrEmpty(alias))
            return items;
        return items.Where(item => item.Title.Contains(alias, StringComparison.InvariantCultureIgnoreCase));
    }
    
    public static IEnumerable<Media> FilterByIsDeleted(this IEnumerable<Media> items, bool? isDeleted)
    {
        return isDeleted is null 
            ? items
            : items.Where(item => item.IsDeleted == isDeleted);
    }
    
    public static IEnumerable<Media> FilterByAlias(this IEnumerable<Media> items, string? alias)
    {
        if(string.IsNullOrEmpty(alias))
            return items;
        return items.Where(item => item.Alias.Contains(alias, StringComparison.InvariantCultureIgnoreCase));
    }

    public static IEnumerable<Media> FilterByReleaseDate(
        this IEnumerable<Media> items,
        DateOnly? minReleaseDate,
        DateOnly? maxReleaseDate)
    {
        minReleaseDate ??= DateOnly.MinValue;
        maxReleaseDate ??= DateOnly.MaxValue;
        return items.Where(item => 
            item.ReleaseDate >= minReleaseDate 
            && item.ReleaseDate <= maxReleaseDate);
    }

    public static IEnumerable<Media> FilterByRating(
        this IEnumerable<Media> items,
        double? minRating = 0,
        double? maxRating = 10) =>
            items.Where(x => x.Rating >= minRating && x.Rating <= maxRating);
}