using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EntityFramework.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.ProductImage)
                   .WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
                   //.OnDelete(DeleteBehavior.Restrict);


            //builder.Property(x => x.Name).HasMaxLength(100).IsRequired().HasColumnType("nvarchar(100)").HasColumnName("ProdcutName");
        }
    }
}
