using DomainModelBurger;
using System.Collections.Generic;
using System.Linq;

namespace Dal
{
	public static class BurgerContextExtension
	{
		public static void Initialize(this BurgerContext context, bool dropAlways = false)
		{
			//To drop database or not
			if (dropAlways)
				context.Database.EnsureDeleted();

			context.Database.EnsureCreated();

			//if db has been already seeded
			if (context.Products.Any())
				return;

			#region Burger

			var burgers = new List<Burger>()
			{
				new Burger
				{
					Name = "American",
					Price = (decimal)9.99,
					Description = "Burger American",
					StockPiled = 100,
					Weight = 50,
					BeefWeight = 30,
				},
				new Burger
				{
					Name = "BBQ",
					Price = (decimal)11.99,
					Description = "Burger BBQ",
					StockPiled = 120,
					Weight = 70,
					BeefWeight = 25,
				},
				new Burger
				{
					Name = "Double Beef",
					Price = (decimal)12.99,
					Description = "Burger Double beef",
					StockPiled = 200,
					Weight = 100,
					BeefWeight = 50,
				},
			};
			context.Burgers.AddRange(burgers);

			#endregion Burger

			#region Side

			var sides = new List<Side>()
			{
				new Side
				{
					Name = "Salade",
					Price = (decimal)4.99,
					Description = "Salade",
					StockPiled = 100,
					Weight = 50,
					SaltWeight = 20,
				},
				new Side
				{
					Name = "Frite",
					Price = (decimal)5.99,
					Description = "Frite",
					StockPiled = 120,
					Weight = 70,
					SaltWeight = 25,
				},
			};
			context.Sides.AddRange(sides);

			#endregion Side

			#region Dessert

			var desserts = new List<Dessert>()
			{
				new Dessert
				{
					Name = "Cookie",
					Price = (decimal)2.99,
					Description = "Cookie",
					StockPiled = 40,
					Millimeter = 20.1,
					IsFrozen = false,
				},
				new Dessert
				{
					Name = "Glace",
					Price = (decimal)4.99,
					Description = "Glace",
					StockPiled = 40,
					Millimeter = 50.1,
					IsFrozen = true,
				},
			};
			context.Desserts.AddRange(desserts);

			#endregion Dessert

			#region Beverage

			var beverages = new List<Beverage>()
			{
				new Beverage
				{
					Name = "Coca-cola",
					Price = (decimal)3.99,
					Description = "Coca-cola",
					StockPiled = 30,
					Millimeter = 20.1,
					IsCarbonated = true,
				},
				new Beverage
				{
					Name = "Eau",
					Price = (decimal)3.99,
					Description = "Eau",
					StockPiled = 30,
					Millimeter = 19.1,
					IsCarbonated = false,
				},
			};
			context.Beverages.AddRange(beverages);

			#endregion Beverage

			#region Menu

			var menus = new List<Menu>()
			{
				new Menu
				{
					Name = "Menu American",
					Price = (decimal)15.99,
					Description = "Menu American",
					StockPiled = 200,
					Burger = burgers[0],
					Dessert = desserts[0],
					Side = sides[1],
					Beverage = beverages[0],
				},
				new Menu
				{
					Name = "Menu BBQ",
					Price = (decimal)15.99,
					Description = "Menu BBQ",
					StockPiled = 200,
					Burger = burgers[1],
					Dessert = desserts[1],
					Side = sides[0],
					Beverage = beverages[1],
				},
			};
			context.Menus.AddRange(menus);

			#endregion Menu

			context.SaveChanges();
		}
	}
}