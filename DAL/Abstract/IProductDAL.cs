using Core.DAL;
using Core.DTOs;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IProductDAL:IGenericRepository<Product>
    {
        //Task<Product> AddProduct(Product product, List<Category> categories);
        Task<Product> AddProduct(Product product, string[] imageUrl,params int[] categories);
        Task<List<ProductDTO>> GetCategoryById(int id, int take, int skip);
        Task<int> ProductCategoryCount(int categoryId);

    }
}
