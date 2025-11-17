using System;
using System.Collections.Generic;

namespace RestaurantOrderSystem
{
    public class Restaurant
    {
        private List<IMenuItem> menu = new List<IMenuItem>();
        private List<Order> orders = new List<Order>();
        private int nextOrderId = 1;

        public void AddMenuItem(IMenuItem item)
        {
            if (item != null)
            {
                menu.Add(item);
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine(" МЕНЮ РЕСТОРАНУ");

            if (menu.Count == 0)
            {
                Console.WriteLine("(меню порожнє)");
            }
            else
            {
                int i = 1;
                foreach (IMenuItem item in menu)
                {
                    if (item is Dish d)
                    {
                        Console.WriteLine($"{i}. {d.Name} ({d.Category}) - {d.Price} грн");
                    }
                    else if (item is Drink dr)
                    {
                        string alc = dr.IsAlcoholic ? "алкогольний" : "без алкоголю";
                        Console.WriteLine($"{i}. {dr.Name} ({dr.VolumeMl} мл, {alc}) - {dr.Price} грн");
                    }

                    i++;
                }
            }
        }

        public Order CreateOrder(int tableNumber)
        {
            Order order = new Order(nextOrderId, tableNumber);
            orders.Add(order);
            nextOrderId++;

            Console.WriteLine($"Створено нове замовлення для столика №{tableNumber} (ID: {order.Id})");
            return order;
        }

        public Order FindOrderById(int id)
        {
            foreach (Order order in orders)
            {
                if (order.Id == id)
                {
                    return order;
                }
            }

            return null;
        }

        public void PrintAllOrders()
        {
            Console.WriteLine(" УСІ ЗАМОВЛЕННЯ ");

            if (orders.Count == 0)
            {
                Console.WriteLine("(немає замовлень)");
            }
            else
            {
                foreach (Order order in orders)
                {
                    order.PrintShortInfo();
                }
            }
        }

        public IMenuItem GetFirstMenuItem()
        {
            if (menu.Count > 0)
            {
                return menu[0]; 
            }

            return null;
        }
    }
}

