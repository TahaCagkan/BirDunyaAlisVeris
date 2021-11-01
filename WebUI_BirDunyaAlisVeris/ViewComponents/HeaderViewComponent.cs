using BLL.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_BirDunyaAlisVeris.DTOs;
using WebUI_BirDunyaAlisVeris.Models;

namespace WebUI_BirDunyaAlisVeris.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly UserManager<AppUser> userManager;
        private readonly IBasketService basketService;

        public HeaderViewComponent(ICategoryService categoryService, UserManager<AppUser> userManager,
            IBasketService basketService)
        {
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.basketService = basketService;
        }
        public IViewComponentResult Invoke()
        {
            HeaderModel model = new HeaderModel();
            var result = categoryService.GetList();
            switch (result.resultType)
            {
                case Core.BLL.ResultBusiness.ResultType.Success:
                    List<Category> cat = result.data;
                    //disari vermemek icin Category DTO yapildi
                    List<CategoryDTO> cDTO = new List<CategoryDTO>();
                    foreach (var item in cat)
                    {
                        CategoryDTO categoryDTO = new CategoryDTO
                        {
                            CategoryImage = item.CategoryImage,
                            Id = item.Id,
                            MasterCategoryId = item.MasterCategoryId,
                            Name = item.Name
                        };
                        //her olusturdugumuz kategoriyi bos gondermemek icin doldurduk 
                        cDTO.Add(categoryDTO);
                    }
                    model.Categories = cDTO;
                    break;
                case Core.BLL.ResultBusiness.ResultType.Error:
                    break;
                case Core.BLL.ResultBusiness.ResultType.Warning:
                    break;
                case Core.BLL.ResultBusiness.ResultType.Notfound:
                    break;
                default:
                    break;
            }
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
