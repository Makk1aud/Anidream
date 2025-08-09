using Anidream.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Anidream.Api.Application.Utils.Interfaces.Data;

public interface IDbContext
{
    DbSet<Media> Media { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}