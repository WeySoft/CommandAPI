using System.ComponentModel.DataAnnotations;

namespace Comand.API.Models
{
    public class Command
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}