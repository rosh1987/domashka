using System;


namespace DiscountСalculator 
{
    class Discountc : Product
    {
        public new int DiscountValue { get; set; }
        public new DateTime? StartSellDate { get; set; }
        public new DateTime? EndSellDate { get; set; }
        public new int Price { get; set; }


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
                    : $"На данный товар не действует подарочных карт ";
        }



    }
}