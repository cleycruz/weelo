using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Owner> Owners { get; }

    DbSet<OwnersList> OwnersLists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
