using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelBurger
{
    [Table("Menu")]
    public class Menu : Product
    {    
        [Required]
        public Beverage Beverage { get; set; }        
        [Required]
        public Side Side { get; set; }       
        public Dessert Dessert { get; set; }       
        [Required]
        public Burger Burger { get; set; }     
    }
}
