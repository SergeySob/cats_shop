using Microsoft.AspNetCore.Mvc;

namespace cats_shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatItemsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetCatPosition([FromQuery] int position)
        {
            var DataBase = new DataBase();
            var cat = await DataBase.getCatPosition(position);
            return Ok(cat);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCatPosition([FromQuery] int position)
        {
            var DataBase = new DataBase();
            var cat = await DataBase.removeCatPosition(position);
            if (cat == true)
            {
                return Content("Позиция удалена");
            }
            else
            {
                return BadRequest("Произошла ошибка");
            }
        }
    }
}
    