using System;


namespace DiscountСalculator 
{
    class ProductDiscount : Product, IDiscount
    {
        public new string Name { get; set; }
        public new int DiscountValue { get; set; }
        public new int Price { get; set; }
        public new DateTime? StartSellDate { get; set; }
        public new DateTime? EndSellDate { get; set; }

        public ProductDiscount(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public new int CalculateDiscountPrice()
        {
            return DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - DiscountValue
                : Price;
        }

        public new string GetSellInformation()
        {
            return DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                    ? $"На данный товар действует подарочная карта на сумму {DiscountValue} р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом подарочной карты - {CalculateDiscountPrice()}р."
                    : $"На данный товар не действует подарочных карт";
        }

        public void CreateProductDiscount()
        {
            Console.WriteLine("Введите сумму подарочной карты (10, 50 и 100 рублей)");

            int.TryParse(Console.ReadLine(), out var discountValue);

            while (discountValue > 100)
            {
                Console.WriteLine("Сумма подарочной карты не может быть больше 100");

                int.TryParse(Console.ReadLine(), out discountValue);
            }

            DiscountValue = discountValue;

            Console.WriteLine("Введите дату начала действия подарочной карты");

            DateTime.TryParse(Console.ReadLine(), out var startSellDate);

            if (startSellDate != DateTime.MinValue)
            {
                StartSellDate = startSellDate;
            }

            Console.WriteLine("Введите дату окончания действия подарочной");

            DateTime.TryParse(Console.ReadLine(), out var endSellDate);

            if (endSellDate != DateTime.MinValue)
            {
                EndSellDate = endSellDate;
            }

            Console.WriteLine($"Вы успешно добавили новый продукт: {Name}, стоимость - {Price}р. {GetSellInformation()}");
        }
    }
}