using BLL.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.Models;

namespace WebUI_BirDunyaAlisVeris.ViewComponents
{
    public class BasketViewComponent
     : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly UserManager<AppUser> userManager;
        private readonly IBasketService basketService;

        public BasketViewComponent(ICategoryService categoryService,
            UserManager<AppUser> userManager,
            IBasketService basketService)
        {
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.basketService = basketService;
        }

        public IViewComponentResult Invoke()
        {
            HeaderModel model = new HeaderModel();

            if (User.Identity.IsAuthenticated)
            {
                var user = userManager.FindByNameAsync(User.Identity.Name).Result;
                var basket = basketService.GetList(x => x.AppUserId == user.Id, null, "Product").data;
                var count = basket.Sum(x => x.Count);
                // var price = basket.Sum(x => x.Product.Price);
                model.count = count;
                model.Baskets = basket;
            }
            return View(model);
        }
    }
}
