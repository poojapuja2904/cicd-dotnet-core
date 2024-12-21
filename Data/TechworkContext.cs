using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using techwork_after_america_return.Data.Entities;

namespace techwork_after_america_return.Data
{
    public class TechworkContext : DbContext //it is in coreframework namespace
    {
        private readonly IConfiguration _config;
        public TechworkContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    //    public DbSet<OrderItem> Items { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseSqlServer(_config["ConnectionStrings:TechworkContextDb"]);
         } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "123"

                });
         

        }

        
    }
}//we have to tell what database has to do in startup techworkcontext in services

//override provides new implementation of methods which is declared in parent class or super class speak()

/*base.OnModelCreating(modelBuilder);
modelBuilder.Entity<Product>()
    .Property(p => p.Title)
    .HasMaxLength(50);*/

