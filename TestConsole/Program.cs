using BLL.Concrete;
using DAL.Concrete;
using DAL.EntityFramework.Context;
using Entity.POCO;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager manager =
            //    new ProductManager(
            //        new EfProductRepository(
            //            new BirDunyaDbContext()));

            //manager.Insert(
            //    new Product
            //    { Name = "testBLL", Price = 54, Stok = 654 });
            //EfProductRepository rpo = new EfProductRepository(new BirDunyaDbContext());

            //var p = rpo.AddProduct(new Product
            //{ Name = "Tavuk1", Description = "Yatan Tavuk", Price = 25, Stok = 1000 },
            //"TestUrl", 1, 2, 3).Result;
            //Console.WriteLine();
            //EfCategoryRepository repo = new EfCategoryRepository();
            //EfProductRepository efProductRepository = new EfProductRepository();
            //EfRepository<ProductCategory, BiDunyaDbContext> db = new EfRepository<ProductCategory, BirDunyaDbContext>(new BirDunyaDbContext());
            //var result = db.GetList(filter: null, "Product", "Category").Result;

            //Console.WriteLine();

            //var r = db.Insert(new ProductCategory { CategoryId = 1, ProductId = 1 }).Result;
            //var r1 = db.Insert(new ProductCategory { CategoryId = 1, ProductId = 2 }).Result;
            //var r11 = db.Insert(new ProductCategory { CategoryId = 2, ProductId = 3 }).Result;





            //var result = db.Insert(new Product { Name = "Peynir", Price = 45, Stok = 100, Description = "Keçi Peyniri" }).Result;
            //var result1 = db.Insert(new Product { Name = "Tereyağ", Price = 200, Stok = 150, Description = "Organik Tereyağ" }).Result;
            //var result11 = db.Insert(new Product { Name = "Kuzu Kaburga", Price = 150, Stok = 75, Description = "Gezen Kuzu" }).Result;




            //var result = db.Insert(new Category { MasterCategoryId = 1, Name = "Süt Ürünleri" }).Result;
            //var result1 = db.Insert(new Category { MasterCategoryId = 1, Name = "Et Ürünleri" }).Result;
            //var result11 = db.Insert(new Category { MasterCategoryId = 1, Name = "Kuru Gıda" }).Result;
            //var result111 = db.Insert(new Category { MasterCategoryId = 1, Name = "Atıştırmalık" }).Result;
            //var result = db.Insert(new MasterCategory { Name = "GIDA" }).Result;
            //var mcategory = db.Get(1).Result;
            //var mcategory = db.Get(x => x.Created ==).Result;
            //var mcategory = db.Get(x => x.Id == 1).Result;
            //var mcategory = db.Get(x => x.Name == "GIDA").Result;
            //var r = db.Delete(mcategory).Result;
            //mcategory.Name = "GIDA";
            //var r = db.Update(mcategory).Result;
            //db.Update()
            //db.Get(x => x.Name == "").Wait();
            //db.Get(x => x.MasterCategoryId == 1);
            //db.Insert(new Product());
            //db.Insert(new Product());
            //db.Delete(new Product());

            //List<Product> products = new List<Product>() {

            //new Product(),
            //new Product(),
            //new Product()};


            //foreach (var item in products)
            //{
            //    db.Insert(item);
            //}
            //db.Commit();//Database burada kayıt edilir.
            //datagridview = db.GetList();
            //EfRepository<Product> test = new EfRepository<Product>();
        }
    }
}
