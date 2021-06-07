using Dal;
using DomainModelBurger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBurger.Repository
{
    public class RepositoryBurger : IRepositoryBurger
    {
        private BurgerContext context;
        public RepositoryBurger(BurgerContext context)
        {
            this.context = context;
        }
        public IQueryable<Burger> GetBurgers()
        {
            return this.context.Burgers;
        }
    }
}
