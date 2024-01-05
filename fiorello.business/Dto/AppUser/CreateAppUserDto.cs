using fiorello.entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Dto.AppUser
{
    public class CreateAppUserDto: IdentityUser<string>
    {
        [Required]
        public string NameSurname { get; set; }

        public Gender Gender { get; set; }
        public string FilePath { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
