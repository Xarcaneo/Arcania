using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arcania.Models
{
    public class Character
    {
        [Required]
        public int Id { get; set; }
        public int RaceId { get; set; }
        [ForeignKey("RaceId")]
        public Race? Race { get; set; }
        public string? Gender { get; set; }
    }
}
