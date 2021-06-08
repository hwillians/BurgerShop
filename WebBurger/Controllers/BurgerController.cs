using DomainModelBurger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBurger.Repository;

namespace WebBurger.Controllers
{
    public class BurgerController : Controller
    {
        private IRepositoryBurger repository;

        public BurgerController(IRepositoryBurger repositoryBurger)
        {
            repository = repositoryBurger;
        }
        // GET: BurgerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BurgerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Burger burger)
        {
            if (ModelState.IsValid) 
            {
                var b = await repository.CreateBurgerAsync(burger);
                return RedirectToAction(nameof(Details), b.ProductId);             
            }
            return View();
        }

        // GET: BurgerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Burger burger)
        {
            if (ModelState.IsValid)
            {
                var b = await repository.EditBurgerAsync(id, burger);
                return RedirectToAction(nameof(Details), b.ProductId);
            }
            return View();
        }

        // GET: BurgerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await repository.DeleteburgerAsync(id);
            return View();

        }
    }
}
