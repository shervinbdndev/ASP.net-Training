using Zhenic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Details(int id) {
            var person = _context.People.FirstOrDefault(p => p.Id == id);

            if (person == null) {
                return NotFound();
            }

            return View(person);
        }

        public async Task<IActionResult> Edit(int id) {
            var person = await _context.People.FindAsync(id);

            if (person == null) {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person person) {
            
            if (id != person.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(person);
                    
                    await _context.SaveChangesAsync();

                } catch (DbUpdateConcurrencyException) {

                    if (!_context.People.Any(e => e.Id == id)) {

                        return NotFound();

                    } else {
                        
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person) {
            if (ModelState.IsValid) {
                _context.People.Add(person);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Delete(int id) {
            var person = _context.People.Find(id);

            if (person == null) {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id) {
            var person = _context.People.Find(id);

            _context.People.Remove(person);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}