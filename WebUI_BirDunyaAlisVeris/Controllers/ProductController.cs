using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index(int id)
        {
            var product = productService.GetList(x =>x.Id == id ,null, "ProductCategory", "ProductImage").data.FirstOrDefault();
            return View(product);
        }
    }
}
