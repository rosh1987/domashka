using System;


namespace DiscountСalculator
{
    class DiscauntProduct : IDiscount
    {
        public int PriceProduct { get; set; }
        public string NameProduct { get; set; }
        public DateTime? StartDateDiscount { get; set; }
        public DateTime? EndDateDiscount { get; set; }
        public int DiscountValueCard { get; set; }

        public DiscauntProduct(string name, int price, int discountValue, DateTime? startSellDate, DateTime? endSellDate)
        {
            NameProduct = name;
            PriceProduct = price;
            StartDateDiscount = startSellDate;
            EndDateDiscount = endSellDate;
            DiscountValueCard = discountValue;
        }

        public int CalculateDiscountPrice()
        {
            return DiscountValueCard != 0 &&
                    StartDateDiscount.HasValue &&
                    EndDateDiscount.HasValue &&
                    StartDateDiscount <= DateTime.UtcNow &&
                    EndDateDiscount >= DateTime.UtcNow
                ? PriceProduct - DiscountValueCard
                : PriceProduct;
        }

        public string GetSellInformation()
        {
            return DiscountValueCard != 0 && StartDateDiscount.HasValue && EndDateDiscount.HasValue
                    ? $"На данный товар действует подарочная карта на сумму {DiscountValueCard} р. в период с {StartDateDiscount.Value.ToShortDateString()} по {EndDateDiscount.Value.ToShortDateString()}. " +
                        $"Сумма с учётом подарочной карты - {CalculateDiscountPrice()}р."
                    : $"На данный товар не действует подарочных карт ";
        }
    }
}
