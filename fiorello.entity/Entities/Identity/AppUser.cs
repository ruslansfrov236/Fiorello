using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fiorello.entity.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        [Required]
        public string NameSurname { get; set; }

        public Gender Gender { get; set; }  
        public string FilePath { get; set; }
        [NotMapped] 
        public IFormFile FormFile { get; set; }
    }
}
