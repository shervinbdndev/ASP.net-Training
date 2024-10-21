using Zhenic.Models;

namespace Zhenic.Repositories {

    public class ArchiveRepository : IArchiveRepository {

        private readonly AppDbContext _context;

        public ArchiveRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Archive> GetArchives() {
            return _context.Archives.ToList();
        }

        public void AddArchive(Archive archive) {
            _context.Archives.Add(archive);
        }

        public void Save() {
            _context.SaveChanges();
        }
    }
}