using BLL.Abstract;
using BLL.Concrete;
using Core.BLL.ResultBusiness;
using DAL.Concrete;
using DAL.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI_BirDunyaAlisVeris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
           // BirDunyaDbContext db = new BirDunyaDbContext();
           // ICategoryService categoryService = 
           //     new CategoryManager(
           //         new EfCategoryRepository(db)
           //         ,new EfDatabaseloggerRepository(db)
           //     );
           //ResultService  result = categoryService.GetList();
            return View();
        }
    }
}
