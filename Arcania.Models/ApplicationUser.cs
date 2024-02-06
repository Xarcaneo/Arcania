using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arcania.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public bool HasCharacter { get; set; } = false;

        public int? CharacterId { get; set; }
        [ForeignKey("CharacterId")]
        public Character? Character { get; set; }
    }
}
