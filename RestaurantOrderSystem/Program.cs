using System;

namespace RestaurantOrderSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Створюємо ресторан
            Restaurant restaurant = new Restaurant();

            // Додаємо позиції в меню
            restaurant.AddMenuItem(new Dish("Борщ", 120, "Перше"));
            restaurant.AddMenuItem(new Dish("Салат овочевий", 90, "Салат"));
            restaurant.AddMenuItem(new Drink("Кава", 60, 200, false));
            restaurant.AddMenuItem(new Drink("Червоне вино", 150, 150, true));

            // Виводимо меню
            restaurant.PrintMenu();
            Console.WriteLine();

            // Створюємо замовлення для столика 5
            Order order1 = restaurant.CreateOrder(5);

            // Додаємо позиції в замовлення
            order1.AddItem(new Dish("Борщ", 120, "Перше"));
            order1.AddItem(new Drink("Кава", 60, 200, false));

            Console.WriteLine($"Поточна сума: {order1.GetTotalPrice()} грн");
            Console.WriteLine();

            // Робота зі статусами
            Console.WriteLine($"Статус замовлення: {order1.Status}");
            order1.ChangeStatus(OrderStatus.InProgress);
            order1.ChangeStatus(OrderStatus.Ready);
            order1.ChangeStatus(OrderStatus.Paid);

            Console.WriteLine();
            order1.PrintDetails();

            // Друге замовлення
            Order order2 = restaurant.CreateOrder(3);
            order2.AddItem(new Dish("Салат овочевий", 90, "Салат"));

            Console.WriteLine();
            restaurant.PrintAllOrders();
            Console.WriteLine();

            // Пошук замовлення за ID
            Console.WriteLine("Пошук замовлення з ID = 1:");
            Order found = restaurant.FindOrderById(1);
            if (found != null)
            {
                found.PrintDetails();
            }
            else
            {
                Console.WriteLine("Замовлення не знайдено.");
            }

            Console.WriteLine();

            // Демонстрація upcast / downcast
            Console.WriteLine("=== Демонстрація upcast / downcast ===");

            // upcast: конкретний клас -> IMenuItem
            IMenuItem item = restaurant.GetFirstMenuItem();

            if (item != null)
            {
                Console.WriteLine($"Upcast: тепер це IMenuItem з назвою: {item.Name}");

                // Спроба downcast до Drink
                Drink drink = item as Drink;
                if (drink != null)
                {
                    Console.WriteLine($"Це напій. Об'єм: {drink.VolumeMl} мл");
                }
                else
                {
                    // Якщо це не Drink, пробуємо як Dish
                    Dish dish = item as Dish;
                    if (dish != null)
                    {
                        Console.WriteLine($"Це страва. Категорія: {dish.Category}");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу, щоб завершити...");
            Console.ReadKey();
        }
    }
}

