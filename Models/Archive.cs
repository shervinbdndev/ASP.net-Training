using System.ComponentModel.DataAnnotations;

namespace Zhenic.Models {
    public class Archive {
        public int Id {get;set;}

        [StringLength(50)]
        public required string Title {get;set;}

        public required DateTime Date {get;set;}

        public required string ImagePath {get;set;}
    }
}