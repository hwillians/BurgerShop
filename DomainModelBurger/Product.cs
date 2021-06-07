using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModelBurger
{
    public abstract class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(30)]
        public string Description { get; set; }
        [Required]
        public int StockPiled { get; set; }
        
    }  
}
