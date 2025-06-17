using Demo_Design_Pattern_MediaTor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo_Design_Pattern_MediaTor.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
