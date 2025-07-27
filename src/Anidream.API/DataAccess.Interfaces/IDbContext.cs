using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces;

public interface IDbContext
{
    DbSet<Media> Media { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}