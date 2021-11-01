using Core.DTOs;
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
                using (var transaction = context.Database.BeginTransaction())
                {
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
                        //Commit kalici hale getir
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        //Rollback geri al
                        transaction.Rollback();
                        throw;
                    }
                }                          
            });

            var result = context.Product
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductImage)
                .FirstOrDefault(x => x.Id == product.Id);

            return Task.FromResult(result);
        }

        public async Task<List<ProductDTO>> GetCategoryById(int id,int take,int skip)
        {
            var products =
                (from p in context.Product
                join ct in context.ProductCategory on p.Id equals ct.ProductId
                join c in context.Category on ct.CategoryId equals c.Id
                where c.Id == id
                select new ProductDTO
                { 
                    productId = p.Id,
                    productName = p.Name,
                    productStok = p.Stok,
                    productPrice = p.Price,
                    categoryName = c.Name,
                    categoryId = c.Id,
                    productImage = (from pImg in context.ProductImage
                                    where pImg.ProductId == p.Id
                                    select pImg.ImageUrl).FirstOrDefault()
                }).Skip(skip).Take(take);
            return await products.ToListAsync(); 
        }

        public Task<int> ProductCategoryCount(int categoryId)
        {
            var result = (from p in context.Product
                         join ct in context.ProductCategory on p.Id equals ct.ProductId
                         where ct.CategoryId == categoryId && p.Active == true && p.Delete == false
                         select p).Count();

            return Task.FromResult(result);

         
        }
    }
}
