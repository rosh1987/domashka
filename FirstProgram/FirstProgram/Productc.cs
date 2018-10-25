using System;

namespace DiscountСalculator
{
    public class Product : IDiscount
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int DiscountValue { get; set; }
        public int DiscountCardValue { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }

        public int CalculateDiscountPrice()
        {
            if (DiscountCardValue == 0)
            {
                return DiscountValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - (Price * DiscountValue / 100)
                : Price;
            }
            else {
                return DiscountCardValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - DiscountCardValue
                : Price;
            }

        }

        public string GetSellInformation()
        {
            if (DiscountValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue)
            {
                return $"На данный товар действует скидка {DiscountValue}% в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом скидки - {CalculateDiscountPrice()}р.";
            }
            else
            {
                return DiscountCardValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                    ? $"На данный товар действует подарочная карта на сумму {DiscountCardValue} р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом подарочной карты - {CalculateDiscountPrice()}р."
                    : $"На данный товар не действует скидок и подарочных карт";
            }
        }

    }
}
