using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarkAPI.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}
