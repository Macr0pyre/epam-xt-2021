using System;

namespace Task_3_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria();

            User user1 = new User("Иван");
            User user2 = new User("Андрей");
            User user3 = new User("Дмитрий");

            user1.OrderPizza(pizzeria, PizzaType.Classic);
            user2.OrderPizza(pizzeria, PizzaType.Margarita);
            user3.OrderPizza(pizzeria, PizzaType.Pepperoni);
        }
    }
}
