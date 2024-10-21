using Zhenic.Models;
using Microsoft.AspNetCore.Mvc;
using Zhenic.Repositories;

namespace Zhenic.Controllers {
    
    public class ArchiveController : Controller {

        private readonly IArchiveRepository _archiveRepository;
        private readonly IWebHostEnvironment _environment;

        public ArchiveController(IArchiveRepository archiveRepository, IWebHostEnvironment environment) {
            _archiveRepository = archiveRepository;
            _environment = environment;
        }

        public IActionResult Index() {
            
            var archives = _archiveRepository.GetArchives();

            return View(archives);
        }

        public IActionResult Create() {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArchiveViewModel model) {

            if (ModelState.IsValid) {
                
                if (model.Image != null) {

                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    var fileName = Path.GetFileName(model.Image.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                    if (!Directory.Exists(uploads)) {
                        
                        Directory.CreateDirectory(uploads);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create)) {

                        model.Image.CopyTo(fileStream);
                    }

                    var archive = new Archive {
                        Title = model.Title,
                        ImagePath = filePath,
                        Date = model.Date
                    };

                    _archiveRepository.AddArchive(archive);
                    _archiveRepository.Save();

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
    }
}