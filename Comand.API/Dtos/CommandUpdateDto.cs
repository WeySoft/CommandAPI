using System.ComponentModel.DataAnnotations;

namespace Comand.API.Dtos
{
    public class CommandUpdate
    {   
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}