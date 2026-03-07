using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;  // for NotMapped

namespace Bookstore.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public IList<string> RoleNames { get; set; } = null!;
    }
}
