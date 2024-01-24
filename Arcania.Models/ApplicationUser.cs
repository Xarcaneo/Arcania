using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Arcania.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Name { get; set; }
    }
}
