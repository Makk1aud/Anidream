using Anidream.Domain.Entities;

namespace Anidream.DataAccess.Implementation;

public static class MediaFilterExtensions
{
    public static IQueryable<Media> FilterByTitle(this IQueryable<Media> items, string? title)
    {
        if(string.IsNullOrEmpty(title))
            return items;
        return items.Where(item => item.Title.ToLower().Contains(title.ToLower()));
    }
    
    public static IQueryable<Media> FilterByIsDeleted(this IQueryable<Media> items, bool? isDeleted)
    {
        return isDeleted is null 
            ? items
            : items.Where(item => item.IsDeleted == isDeleted);
    }
    
    public static IQueryable<Media> FilterByAlias(this IQueryable<Media> items, string? alias)
    {
        if(string.IsNullOrEmpty(alias))
            return items;
        return items.Where(item => item.Alias.ToLower().Contains(alias.ToLower()));
    }
    
    public static IQueryable<Media> FilterByGenreAlias(this IQueryable<Media> items, IReadOnlyCollection<string> genreAliases)
    {
        if(!genreAliases.Any())
            return items;
        return items.Where(item => item.Genres.Select(x => x.Alias).Count(genreAliases.Contains) == genreAliases.Count);
    }

    public static IQueryable<Media> FilterByReleaseDate(
        this IQueryable<Media> items,
        DateOnly? minReleaseDate,
        DateOnly? maxReleaseDate)
    {
        minReleaseDate ??= DateOnly.MinValue;
        maxReleaseDate ??= DateOnly.MaxValue;
        return items.Where(item => 
            item.ReleaseDate >= minReleaseDate 
            && item.ReleaseDate <= maxReleaseDate);
    }

    public static IQueryable<Media> FilterByRating(
        this IQueryable<Media> items,
        double? minRating = 0,
        double? maxRating = 10) =>
            items.Where(x => x.Rating >= minRating && x.Rating <= maxRating);
}