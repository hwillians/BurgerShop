using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelBurger
{
    [Table("Burger")]
    public class Burger : Product
    {
        [Required]
        public int Weight { get; set; }
        [Required]
        public int BeefWeight { get; set; }      
    }
}
