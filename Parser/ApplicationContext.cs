using System;
using Microsoft.EntityFrameworkCore;

namespace Parser
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AvitoProduct> products;
        public DbSet<Seller> sellers;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlitedemo.db");
        }
    }
}
