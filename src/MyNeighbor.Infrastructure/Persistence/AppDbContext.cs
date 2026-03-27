using Microsoft.EntityFrameworkCore;
using MyNeighbor.Application.Common.Interfaces;
using MyNeighbor.Domain.Common;
using MyNeighbor.Domain.Housing;

namespace MyNeighbor.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Apartment> Apartments => Set<Apartment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
