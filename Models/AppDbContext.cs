using Microsoft.EntityFrameworkCore;

namespace Zhenic.Models {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Person> People {get;set;}
        public DbSet<Archive> Archives {get;set;}
    }
}