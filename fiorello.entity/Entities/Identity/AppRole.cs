using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace fiorello.entity.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
      

        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
