using BankingApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Infrastructure.Context
{
    public class BankingDbContext :DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

    }
}
