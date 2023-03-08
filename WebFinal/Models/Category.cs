using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebFinal.Models
{
    // Model for Category with properties
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CategoryDate { get; set; } = DateTime.Now;
    }
}
