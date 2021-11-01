using BLL.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.Models;

namespace WebUI_BirDunyaAlisVeris.Controllers
{
    public class BasketController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IBasketService basketService;

        public BasketController(
            UserManager<AppUser> userManager,
            IBasketService basketService)
        {
            this.userManager = userManager;
            this.basketService = basketService;
        }
        public async Task<JsonResult> AddBasket(int id, string Name)
        {
            var user = await userManager.FindByNameAsync(Name);
            Basket basket = new Basket
            {
                AppUserId = user.Id,
                ProductId = id,
                Count = 1
            };
            var result = basketService.InsertBasket(basket);
            var resultModel = basketService.GetList(x => x.AppUserId == user.Id, null, "Product").data;
            var count = resultModel.Sum(x => x.Count);
            BasketViewModel model = new BasketViewModel()
            {
                Product = resultModel.Select(x => new Product
                {
                    Name = x.Product.Name,
                    Price = x.Product.Price
                }).ToList(),
                Count = count
            };
            return Json(model);
        }

    }
}
