using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class CartController : Controller
    {
        static PizzaObj context = new PizzaObj();
        List<Pizza> Pizzas = context.GetPizzas();
        public IActionResult Index()
        { if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return View("CartEmpty");
            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Cost * item.Quantity);
                return View();
            }
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                foreach(Pizza p in Pizzas)
                {
                    if(p.Id==id)
                        cart.Add(new Item { Product = context.GetPizzaById(id), Quantity = 1 });
                }
                
           
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExists(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    foreach (Pizza p in Pizzas)
                    {
                        if (p.Id == id)
                            cart.Add(new Item { Product = context.GetPizzaById(id), Quantity = 1 });
                    }
                    Console.WriteLine("cart added successfully one");
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        private int isExists(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult clearCart()
        {
            List<Item> cart = new List<Item>();
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Payment()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.total = cart.Sum(item => item.Product.Cost * item.Quantity);
            return View();
        }
        public IActionResult Pay()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.total = cart.Sum(item => item.Product.Cost * item.Quantity);
            clearCart();
            return RedirectToAction("Index", "Home");
        }
    }
}
