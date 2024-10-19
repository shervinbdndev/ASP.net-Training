using Microsoft.AspNetCore.Mvc;

namespace Zhenic.Controllers {
    public class PeopleController: Controller {
        public IActionResult Index() {
            ViewBag.Message = "List of People";
            return View();
        }

        public IActionResult Details(int id) {
            ViewBag.PersonId = id;
            return View();
        }
    }
}