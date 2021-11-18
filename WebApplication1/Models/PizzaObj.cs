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
                new Pizza{Id=1001,Name="Margeretta",Image="https://static.toiimg.com/thumb/56868564.cms?imgsize=1948751&width=800&height=800",Cost=100},
                new Pizza{Id=1002,Name="cheese and corn pizza",Image="https://image.shutterstock.com/image-photo/colorful-sliced-pizza-mozzarella-cheese-260nw-269459642.jpg",Cost=150},
            };
        }
        public List<Pizza> GetPizzas() =>Pizzas;
        public Pizza GetPizzaById(int id) =>Pizzas.Single(x => x.Id == id);
        public void AddPizza(Pizza c) => Pizzas.Add(c);
        public void EditPizza(Pizza c, int id) => Pizzas[Pizzas.FindIndex(x => x.Id == id)] = c;
        public void DeletePizza(int id) => Pizzas.Remove(Pizzas.Single(x => x.Id == id));
        
    }
}
