using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebFinal.Models
{
    public class Game
    {  
        // Model for Game with properties
            [Key]
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public string Publisher { get; set; }

            [Required]
             public DateTime PublishDate { get; set; } = DateTime.Now;
            [Required]
            [Range(0, 10000)]
            public double Price { get; set; }

            [ValidateNever]
            public string ImageUrl { get; set; }

            [Required]
            public int CategoryId { get; set; }
            [ForeignKey("CategoryId")]
            [ValidateNever]
            public Category Category { get; set;}
            [ValidateNever]
     
            public List<Comment>? Comments { get; set;}       
    }
}
