using Zhenic.Models;

namespace Zhenic.Repositories {

    public interface IArchiveRepository {
        IEnumerable<Archive> GetArchives();
        void AddArchive(Archive archive);
        void Save();
    }
}