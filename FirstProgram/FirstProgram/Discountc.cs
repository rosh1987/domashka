using System;


namespace DiscountСalculator 
{
    class Discountc : IDiscount
    {
        public int DiscountCardValue { get; set; }
        public DateTime? StartDiscountDate { get; set; }
        public DateTime? EndDiscountDate { get; set; }
        public int ProductPrice { get; set; }


        public int CalculateDiscountPrice()
        {
            return DiscountCardValue != 0 &&
                    StartDiscountDate.HasValue &&
                    EndDiscountDate.HasValue &&
                    StartDiscountDate <= DateTime.UtcNow &&
                    EndDiscountDate >= DateTime.UtcNow
                ? ProductPrice - DiscountCardValue
                : ProductPrice;
        }

        public string GetSellInformation()
        {
            return DiscountCardValue != 0 && StartDiscountDate.HasValue && EndDiscountDate.HasValue
                    ? $"На данный товар действует подарочная карта на сумму {DiscountCardValue} р. в период с {StartDiscountDate.Value.ToShortDateString()} по {EndDiscountDate.Value.ToShortDateString()}. " +
                        $"Сумма с учётом подарочной карты - {CalculateDiscountPrice()}р."
                    : $"На данный товар не действует скидок и подарочных карт";
        }



    }
}