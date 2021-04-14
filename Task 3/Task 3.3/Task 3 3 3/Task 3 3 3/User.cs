using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_3_3
{
    public class User
    {
        public string Name { get; }

        public User(string name) => Name = name;

        public void OrderPizza(Pizzeria pizzeria, PizzaType pizzaType)
        {
            Console.WriteLine($"{Name}: Заказываю пиццу \"{pizzaType}\"");

            //event subscription
            pizzeria.PizzaIsReady += GetPizza;

            // ordering pizza
            pizzeria.Order(pizzaType);
        }
        public void GetPizza(Pizzeria pizzeria)
        {
            // getting pizza
            Pizza pizza = pizzeria.TastyPizza;
            Console.WriteLine($"{Name}: Пицца \"{pizza.Type}\" получена");

            // unsubscribe from an event
            pizzeria.PizzaIsReady -= GetPizza;
        }
    }
}
