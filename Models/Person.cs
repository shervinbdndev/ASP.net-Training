using System.ComponentModel.DataAnnotations;

namespace Zhenic.Models {
    public class Person {
        public int Id {get;set;}
        
        [StringLength(100)]
        public required string FirstName {get;set;}

        [StringLength(100)]
        public required string LastName {get;set;}

        public int Age {get;set;}
        public int Code {get;set;}
    }
}