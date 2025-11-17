using System;
using System.Collections.Generic;

namespace RestaurantOrderSystem
{
    public class Order
    {
        private List<IMenuItem> items = new List<IMenuItem>();

        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(int id, int tableNumber)
        {
            Id = id;
            TableNumber = tableNumber;
            Status = OrderStatus.New; 
        }

        public void AddItem(IMenuItem item)
        {
            if (item == null)
                return;

            items.Add(item);
            Console.WriteLine($"Додано позицію: {item.Name}");
        }

        public double GetTotalPrice()
        {
            double sum = 0;
            foreach (IMenuItem item in items)
            {
                sum += item.Price;
            }
            return sum;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"> Змінено статус: {Status}");
        }

        public void PrintShortInfo()
        {
            Console.WriteLine($"ID: {Id} | Стіл: {TableNumber} | Статус: {Status} | Сума: {GetTotalPrice()} грн");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Замовлення ID: {Id} для столика №{TableNumber}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine("Позиції:");

            if (items.Count == 0)
            {
                Console.WriteLine("  (немає позицій)");
            }
            else
            {
                int i = 1;
                foreach (IMenuItem item in items)
                {
                    Console.WriteLine($"{i}. {item.Name} - {item.Price} грн");
                    i++;
                }
            }

            Console.WriteLine($"Загальна сума: {GetTotalPrice()} грн");
        }
    }
}

