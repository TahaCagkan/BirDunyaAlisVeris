using BLL.Abstract;
using Core.BLL.ResultBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.Models;

namespace WebUI_BirDunyaAlisVeris.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        //[Authorize(Roles ="Admin,User")]
        [Authorize]
        public IActionResult CategoryDetail(int id,int page = 1)
        {
            var totalProduct = productService.ProductCategoryCount(id).data;
            //pagination icin
            int take =2;
            var pageCount =Math.Ceiling(Convert.ToDecimal(totalProduct) / take);
            ViewBag.PageCount = pageCount;
            int skip = take*(page-1);
            ShopDetailModel model = new ShopDetailModel();
            //var result = categoryService.GetList(x => x.Id == id, null, "ProductCategory");
            var result = productService.GetCategoryById(id,take,skip);
            switch (result.resultType)
            {
                case ResultType.Success:
                    model.Products = result.data;
                    break;
                case ResultType.Error:
                    break;
                case ResultType.Warning:
                    break;
                case ResultType.Notfound:
                    break;
                default:
                    break;
            }
            return View();
        }
    }
}
