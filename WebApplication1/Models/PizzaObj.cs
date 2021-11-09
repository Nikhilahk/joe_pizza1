using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PizzaObj
    {
        public List<Pizza> Pizzas { get; set; }
        public PizzaObj()
        {
            Pizzas = new List<Pizza> {
                new Pizza{Id=1001,Name="Margeretta",Image="https://d3nn873nee648n.cloudfront.net/900x600/19095/120-MZ895546.jpg",Cost=80},
                new Pizza{Id=1002,Name="cheesy pizza",Image="https://d3nn873nee648n.cloudfront.net/900x600/19095/120-MZ895546.jpg",Cost=100},
            };
        }
        public List<Pizza> GetPizzas() =>Pizzas;
        public Pizza GetPizzaById(int id) =>Pizzas.Single(x => x.Id == id);
        public void AddPizza(Pizza c) => Pizzas.Add(c);
        public void EditPizza(Pizza c, int id) => Pizzas[Pizzas.FindIndex(x => x.Id == id)] = c;
        public void DeletePizza(int id) => Pizzas.Remove(Pizzas.Single(x => x.Id == id));
        
    }
}
