using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFinal.Models
{
    // Model for Comment with properties
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [ValidateNever]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public int Rating { get; set; }
    
        [Required]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        [ValidateNever]
        public Game Game { get; set; }

    }
}
