using CommonAttribute;
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
        [Range(0, 200)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(30)]
        public string Description { get; set; }
        [Required]
        [PositiveNumber]
        public int StockPiled { get; set; }
        
    }  
}
