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
    public class BeverageController : Controller
    {
        private IRepositoryBeverage repository;

        public BeverageController(IRepositoryBeverage repositoryBeverage)
        {
            repository = repositoryBeverage;
        }
        // GET: Beverage
        public ActionResult Index()
        {
            return View();
        }

        // GET: Beverage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beverage/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Beverage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                var b = repository.CreateBeverage(beverage);
                return RedirectToAction(nameof(Details),b.ProductId);
                
            }

            return View();
        }

        // GET: Beverage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beverage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Beverage beverage)
        {
            if (ModelState.IsValid) 
            {
                var b = repository.EditBeverage(id, beverage);
                return RedirectToAction(nameof(Details),b.ProductId);
            }

            return View();
        }

        // GET: Beverage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beverage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            repository.DeleteBeverage(id);
            return View();
        }
    }
}
