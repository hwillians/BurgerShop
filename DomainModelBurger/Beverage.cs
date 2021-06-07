using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelBurger
{
    [Table("Beverage")]
    public class Beverage : Product
    {
        [Required]
        public double Millimeter { get; set; }
        [Required]
        public bool IsCarbonated { get; set; }
    }
}
