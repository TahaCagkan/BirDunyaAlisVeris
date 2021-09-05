using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EntityFramework.Mapping
{
    public class ProductImageMap : IEntityTypeConfiguration<ProductImage>
    {

            public void Configure(EntityTypeBuilder<ProductImage> builder)
            {
                //Teke cok iliski
                //builder.HasOne(x => x.Product)
                //       .WithMany(x => x.ProductImage)
                //       .HasForeignKey(x => x.ProductId);
            }
        
    }
}
