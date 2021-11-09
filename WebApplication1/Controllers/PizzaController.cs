using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PizzaController : Controller
    {
        static PizzaObj context = new PizzaObj();
        public IActionResult Index()
        {
            List<Pizza> Pizzas = context.GetPizzas();
            //return View(customers);

            return View(context.GetPizzas());
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Pizza c)
        {
            context.AddPizza(c);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id) => View(context.GetPizzaById(id));
        [HttpPost]
        public IActionResult Edit(int id, Pizza c)
        {
            context.EditPizza(c, c.Id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(context.GetPizzaById(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, Pizza c)
        {
            context.DeletePizza(id);
            return RedirectToAction("index");
        }
    }
}
