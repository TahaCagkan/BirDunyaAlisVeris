using DAL.Abstract;
using DAL.EntityFramework.Context;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EfProductRepository : EfRepository<Product, BirDunyaDbContext>, IProductDAL
    {
        private readonly BirDunyaDbContext context;
        public EfProductRepository(BirDunyaDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Product Tablosunun sadece iliskileri degistigi zaman bu method elden gecer
        /// </summary>
        /// <param name="product">Product Insert</param>
        /// <param name="imageUrl">ProductImage Tablosu Instert</param>
        /// <param name="categories">ProductCategor Tablosu</param>
        /// <returns>Iliskisel Product tablosu</returns>
        public Task<Product> AddProduct(Product product, string[] imageUrl, int[] categories)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            //arka arakaya tekrar eden foreach ekleme yapailcaksa cozum
            strategy.Execute(() =>
            {
                var transaction = context.Database.BeginTransaction();

                try
                {
                    context.Product.Add(product);
                    if (context.SaveChanges() > 0) 
                    {
                        //Kategoriye bagli urunler
                        foreach (var item in categories)
                        {
                            context.ProductCategory.Add(new ProductCategory { CategoryId = item, ProductId = product.Id });
                        }
                        foreach (var item in imageUrl)
                        {
                            context.ProductImage.Add(new ProductImage { ImageUrl = item, ProductId = product.Id });

                        }
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            });

            var result = context.Product
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductImage)
                .FirstOrDefault(x => x.Id == product.Id);

            return Task.FromResult(result);
        }
    }
}
