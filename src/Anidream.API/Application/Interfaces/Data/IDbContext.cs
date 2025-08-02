using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Data;

public interface IDbContext
{
    DbSet<Media> Media { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}