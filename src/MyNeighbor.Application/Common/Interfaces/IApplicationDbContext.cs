using MyNeighbor.Domain.Housing;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace MyNeighbor.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Building> Buildings { get; }
        DbSet<Apartment> Apartments { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
