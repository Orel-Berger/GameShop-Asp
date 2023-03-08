using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using static WebFinal.Models.Game;

namespace WebFinal.Models.ViewModels
{
    //View Model that take model game with his Category Properties
    public class GameVM
    {
        public Game Game { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
