using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Common.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Post> Posts { get; set; }

        public ApplicationUser()
        {
            Posts = new List<Post>();
        }
    }
}
