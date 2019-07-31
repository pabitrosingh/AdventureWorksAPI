using Microsoft.AspNetCore.Mvc;
namespace AdventureWorksAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
           //return  Content("API Services..!!");
        }
    }
}