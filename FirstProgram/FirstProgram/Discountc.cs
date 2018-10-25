using System;


namespace DiscountСalculator 
{
    class Discountc : IDiscount
    {
        public int DiscountCardValue { get; set; }
        public DateTime? StartSellDate { get; set; }
        public DateTime? EndSellDate { get; set; }
        public int Price { get; set; }


        public int CalculateDiscountPrice()
        {
            return DiscountCardValue != 0 &&
                    StartSellDate.HasValue &&
                    EndSellDate.HasValue &&
                    StartSellDate <= DateTime.UtcNow &&
                    EndSellDate >= DateTime.UtcNow
                ? Price - DiscountCardValue
                : Price;
        }

        public string GetSellInformation()
        {
            return DiscountCardValue != 0 && StartSellDate.HasValue && EndSellDate.HasValue
                    ? $"На данный товар действует подарочная карта на сумму {DiscountCardValue} р. в период с {StartSellDate.Value.ToShortDateString()} по {EndSellDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом подарочной карты - {CalculateDiscountPrice()}р."
                    : $"На данный товар не действует скидок и подарочных карт";
        }



    }
}