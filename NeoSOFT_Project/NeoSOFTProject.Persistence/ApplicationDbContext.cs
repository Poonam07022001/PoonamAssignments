using Microsoft.EntityFrameworkCore;
using NeoSOFTProject.Domain.Entities;

namespace NeoSOFTProject.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
