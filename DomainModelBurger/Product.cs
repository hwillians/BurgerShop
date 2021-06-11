using CommonAttribute;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	public abstract class Product
	{
		public int ProductId { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		[Range(0, 99.99)]
		[Column(TypeName = "decimal(4,2)")]
		public decimal Price { get; set; }

		[Required]
		[StringLength(50)]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required]
		[PositiveNumber]
		[DisplayName("Stock piled")]
		public int StockPiled { get; set; } = 0;
	}
}