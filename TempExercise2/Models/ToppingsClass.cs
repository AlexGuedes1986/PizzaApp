using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempExercise2.Models
{
    public static class ToppingsClass
    {
        
        public static List<Pizza> Toppings()
        {
            List<Pizza> list = new List<Pizza>() {                
               new Pizza { Topping="Pepperoni", Price=2.34M},
               new Pizza { Topping = "Bacon", Price = 2.11M},
               new Pizza { Topping ="Beef", Price = 3.12M},
               new Pizza { Topping = "Turkey", Price = 3.09M},
               new Pizza { Topping ="Salami", Price = 1.89M},
               new Pizza { Topping = "Ham", Price = 2.16M} 
            };
            return list;
        }

         //"Pepperoni"," Bacon", "Beef", "Turkey", "Salami", "Ham"
    }
}