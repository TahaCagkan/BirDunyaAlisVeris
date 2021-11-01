using BLL.Abstract;
using Core.BLL.ResultBusiness;
using Entity.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_BirDunyaAlisVeris.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public TestController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Deneme()
        {
            ResultService<List<Category>> result = categoryService.GetList(x => x.Active == true);

            switch (result.resultType)
            {
                case ResultType.Success:
                    return Ok(result.data);
                case ResultType.Error:
                    break;
                case ResultType.Warning:
                    break;
                case ResultType.Notfound:
                    break;
                default:
                    break;
            }
            return NotFound();
        }
    }
}
