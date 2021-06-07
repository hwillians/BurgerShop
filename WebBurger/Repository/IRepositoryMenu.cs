using DomainModelBurger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
    public interface IRepositoryMenu
    {
        public IQueryable<Menu> GetMenus();
    }
}
