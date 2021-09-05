using DAL.EntityFramework.Mapping;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.EntityFramework.Context
{
    public class BirDunyaDbContext : IdentityDbContext<AppUser,AppRole,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server  =DESKTOP-0TJT8G1; Database = BirDunyaDb; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys()))
            {
                //foreign key iliskiler silinmez
                item.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ProductCategory>().HasKey(x => new {x.CategoryId, x.ProductId });
            modelBuilder.Entity<AppRole>().HasData
                (
                    new AppRole {Name="Admin", NormalizedName="ADMIN",Id=1 }
                );
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<MasterCategory> MasterCategory { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<DatabaseLogger> DatabaseLogger { get; set; }


    }
}
