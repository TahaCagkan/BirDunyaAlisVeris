using DAL.EntityFramework.Context;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SeedData
{
    public class ECommerceSeedData
    {
        public static void Seed()
        {
            BirDunyaDbContext db = new BirDunyaDbContext();
            //List<MasterCategory> masters = new List<MasterCategory>
            //{
            //     new MasterCategory{  Name="Giyim"}
            //};
            db.MasterCategory.Add(new MasterCategory { Name = "Giyim" });
            db.SaveChanges();
            List<Category> categories = new List<Category>
            {
                new Category{ Name="Kadın",MasterCategoryId=1,
                    CategoryImage="/Image/ImageCategory/banner-2.jpg"},//1
                new Category{ Name="Erkek",MasterCategoryId=1,
                CategoryImage="/Image/ImageCategory/banner-1.jpg"},//2
                new Category{ Name="Cocuk",MasterCategoryId=1,
                CategoryImage="/Image/ImageCategory/banner-3.jpg"},//3
            };
            db.Category.AddRange(categories);
            List<Product> products = new List<Product>()
            {
                new Product{Name="Çanta",Price=150,Stok=1000 },//1
                new Product{Name="Ayakkabı",Price=50,Stok=150 },//2
                new Product{Name="Mont Erkek",Price=10,Stok=75 },//3
                new Product{Name="Gömlek Erkek",Price=125,Stok=25 },//4
                new Product{Name="Takım Elbise",Price=52,Stok=35 },//5
                new Product{Name="Bluz Kadın",Price=85,Stok=45 },//6
                new Product{Name="Bluz2 Kadın",Price=24,Stok=55 },//7
                new Product{Name="Kaşkol",Price=25,Stok=75 },//8
                new Product{Name="Şapka",Price=35,Stok=35 },//9
                new Product{Name="Kazak",Price=75,Stok=87 },//10
                new Product{Name="Çanta Kadın",Price=12,Stok=70 },//11
                new Product{Name="Takım Kadın",Price=15,Stok=30 },//12
            };
            db.Product.AddRange(products);
            db.SaveChanges();

            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory{ CategoryId=2,ProductId=1},
                new ProductCategory{ CategoryId=2,ProductId=2},
                new ProductCategory{ CategoryId=2,ProductId=3},
                new ProductCategory{ CategoryId=2,ProductId=4},
                new ProductCategory{ CategoryId=2,ProductId=5},
                new ProductCategory{ CategoryId=1,ProductId=6},
                new ProductCategory{ CategoryId=1,ProductId=7},
                new ProductCategory{ CategoryId=1,ProductId=8},
                new ProductCategory{ CategoryId=1,ProductId=9},
                new ProductCategory{ CategoryId=1,ProductId=10},
                new ProductCategory{ CategoryId=1,ProductId=11},
                new ProductCategory{ CategoryId=1,ProductId=12},
            };
            db.ProductCategory.AddRange(productCategories);
            db.SaveChanges();

            List<ProductImage> productImages = new List<ProductImage>
            {
                new ProductImage{ ProductId=1, ImageUrl="/Image/ImageProduct/man-1.jpg"},
                new ProductImage{ ProductId=1, ImageUrl="/Image/ImageProduct/product-7.jpg"},
                new ProductImage{ ProductId=2, ImageUrl="/Image/ImageProduct/product-9.jpg"},
                new ProductImage{ ProductId=2, ImageUrl="/Image/ImageProduct/man-2.jpg"},
                new ProductImage{ ProductId=3, ImageUrl="/Image/ImageProduct/man-3.jpg"},
                new ProductImage{ ProductId=4, ImageUrl="/Image/ImageProduct/man-4.jpg"},
                new ProductImage{ ProductId=3, ImageUrl="/Image/ImageProduct/product-8.jpg"},
                new ProductImage{ ProductId=5, ImageUrl="/Image/ImageProduct/man-large.jpg"},
                new ProductImage{ ProductId=6, ImageUrl="/Image/ImageProduct/product-1.jpg"},
                new ProductImage{ ProductId=6, ImageUrl="/Image/ImageProduct/product-2.jpg"},
                new ProductImage{ ProductId=6, ImageUrl="/Image/ImageProduct/women-1.jpg"},
                new ProductImage{ ProductId=6, ImageUrl="/Image/ImageProduct/women-2.jpg"},
                new ProductImage{ ProductId=6, ImageUrl="/Image/ImageProduct/women-3.jpg"},
                new ProductImage{ ProductId=7, ImageUrl="/Image/ImageProduct/product-3.jpg"},
                new ProductImage{ ProductId=8, ImageUrl="/Image/ImageProduct/product-4.jpg"},
                new ProductImage{ ProductId=9, ImageUrl="/Image/ImageProduct/product-5.jpg"},
                new ProductImage{ ProductId=10, ImageUrl="/Image/ImageProduct/product-6.jpg"},
                new ProductImage{ ProductId=11, ImageUrl="/Image/ImageProduct/women-4.jpg"},
                new ProductImage{ ProductId=12, ImageUrl="/Image/ImageProduct/women-large.jpg"},
            };
            db.ProductImage.AddRange(productImages);
            db.SaveChanges();
        }
    }
}
