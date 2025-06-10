using BankSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystemAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

  
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet <BankCard> BankCards { get; set; }
        public DbSet <Branch> branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(a=>a.AccountNumber).IsUnique();
        }
    }
}
