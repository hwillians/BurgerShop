﻿using DomainModelBurger;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
	public interface IRepositoryMenu
	{
		public IQueryable<Menu> GetMenus();

		public Task<Menu> GetMenuAsync(int id);

		public Task<Menu> CreateMenuAsync(Menu menu);

		public Task<Menu> EditMenuAsync(int id, Menu menu);

		public Task DeleteMenuAsync(int id);
	}
}