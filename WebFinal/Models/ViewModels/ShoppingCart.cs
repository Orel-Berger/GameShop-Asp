using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Models;

namespace WebFinal.Models
{
    //View Model that take model game with his Comments Properties
    public class ShoppingCart
    {
        public Game Game { get; set; }
        public int totalComments { get; set; }
    }
}
