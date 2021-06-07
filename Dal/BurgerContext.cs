using DomainModelBurger;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class BurgerContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public BurgerContext() : base()
        {

        }
        public BurgerContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LOCALDB)\MSSQLLocalDB;Initial Catalog=BurgerDb;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
