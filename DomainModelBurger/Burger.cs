using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModelBurger
{
	[Table("Burgers")]
	public class Burger : Product
	{
		[Required]
		[Range(10, 200)]
		public int Weight { get; set; }

		[Required]
		[DisplayName("Beef weight")]
		[Range(0, 200)]
		public int BeefWeight { get; set; }
	}
}