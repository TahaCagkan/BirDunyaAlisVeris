using Core.BLL.ResultBusiness;
using Core.DTOs;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        //IProductDAL ona ozgu method var GenericRepostiory tasiyamayiz,kendi Service interface de tutulur
        ResultService<Product> AddProduct(Product product, string[] imageUrl, object user, params int[] categories);
        ResultService<List<ProductDTO>> GetCategoryById(int id, int take, int skip);
        ResultService<int> ProductCategoryCount(int categoryId);

    }
}
