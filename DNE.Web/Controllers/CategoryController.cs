using Microsoft.AspNetCore.Mvc;

namespace DNE.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
