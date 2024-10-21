using Microsoft.AspNetCore.Mvc;

namespace Zhenic.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {

            return View();
        }
    }
}