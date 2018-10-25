using System;

namespace DiscountСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить новый продукт? 1 - да, 2 - нет");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 1)
                return;

            CreateProduct();

            Console.ReadLine();
        }

        private static void CreateProduct()
        {
            var product = new Product();

            Console.WriteLine("Введите название продукта");

            product.Name = Console.ReadLine();

            Console.WriteLine("Введите стоимость продукта");

            int.TryParse(Console.ReadLine(), out var price);

            while (price == 0)
            {
                Console.WriteLine("Стоимость продукта не была введена или она была введена с ошибкой. Пожалуйста, введите стоимость продукта ещё раз");

                int.TryParse(Console.ReadLine(), out price);
            }

            product.Price = price;

            Console.WriteLine("Вы хотите воспользоватся следующими видами скидок: 1 - процентной скидкой, 2 - подарочной картой?");

            int.TryParse(Console.ReadLine(), out var answer);

            if (answer != 2)
            {

                Console.WriteLine("Введите значение скидки на товар (в % от общей стоимости)");

                int.TryParse(Console.ReadLine(), out var discountValue);

                while (discountValue > 100)
                {
                    Console.WriteLine("Значение скидки не может быть больше 100");

                    int.TryParse(Console.ReadLine(), out discountValue);
                }

                product.DiscountValue = discountValue;
            }
            else
            {
                Console.WriteLine("Введите сумму подароной карты");

                int.TryParse(Console.ReadLine(), out var discountCardValue);

                while (discountCardValue > price)
                {
                    Console.WriteLine("Сумма подарочной карты не должна быть больше стоимости продукта");

                    int.TryParse(Console.ReadLine(), out discountCardValue);
                }

                product.DiscountCardValue = discountCardValue;

            }

                Console.WriteLine("Введите дату начала действия скидки/подарочной карты");

                DateTime.TryParse(Console.ReadLine(), out var startSellDate);

                if (startSellDate != DateTime.MinValue)
                {
                    product.StartSellDate = startSellDate;
                }

                Console.WriteLine("Введите дату окончания действия скидки/подарочной карты");

                DateTime.TryParse(Console.ReadLine(), out var endSellDate);

                if (endSellDate != DateTime.MinValue)
                {
                    product.EndSellDate = endSellDate;
                }

                Console.WriteLine($"Вы успешно добавили новый продукт: {product.Name}, стоимость - {product.Price}р. {product.GetSellInformation()}");
        }
    }
}
