using Microsoft.EntityFrameworkCore;
using Quickstart.Repository.Entities;

namespace Quickstart.Repository.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            bool x = true;
            if (x)
                Database.EnsureCreated();
            else
                Database.EnsureDeleted();
        }
    }
}
