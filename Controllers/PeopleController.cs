using Zhenic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Zhenic.Controllers {
    public class PeopleController: Controller {
        
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var people = _context.People.ToList();
            return View(people);
        }
    }
}