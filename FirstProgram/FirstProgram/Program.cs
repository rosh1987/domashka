﻿using System;

namespace DiscountСalculator
{
    class Program
    {
        public static object Price { get; private set; }

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

            Console.WriteLine("Вы хотите воспользоваться скидкой? 1 - скидкой, 2 - подарочной картой");

            int.TryParse(Console.ReadLine(), out var answerSell);

            if (answerSell == 1)
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
                Console.WriteLine("Введите сумму подарочной карты");

                int.TryParse(Console.ReadLine(), out var discountValue);

                while (discountValue > price)
                {
                    Console.WriteLine("Сумма подарочной карты не может быть больше цены товара!");

                    int.TryParse(Console.ReadLine(), out discountValue);
                }

                product.DiscountValue = discountValue;
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

                if (answerSell == 1) Console.WriteLine("Вы успешно добавили новый продукт:" + product.Name + ", стоимость " + product.Price + "р." + product.GetSellInformation());
                else
                {
                    var discount = new DiscauntProduct(product.Name, product.Price, product.DiscountValue, product.StartSellDate, product.EndSellDate);
                    Console.WriteLine("Вы успешно добавили новый продукт:" + discount.NameProduct + ", стоимость " + discount.PriceProduct + "р." + discount.GetSellInformation());
                }
        }
    }
}
