using System;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double price;
        private int nightsCount;
        private double discount;
        private double total;

        public double Price
        {
            get => price;
            set
            {
                if (value < 0) throw new ArgumentException();
                price = value;
                Notify(nameof(Price));
                Notify(nameof(Total));
            }
        }

        public int NightsCount
        {
            get => nightsCount;
            set
            {
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }

        public double Discount
        {
            get => discount;
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException();
                discount = value;
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }

        public double Total
        {
            get => Price * NightsCount * (1 - Discount / 100);
            set
            {
                var newTotalDiscount = (1 - (value / (Price * NightsCount))) * 100;
                if (newTotalDiscount >= 0 && newTotalDiscount <= 100)
                {
                    Discount = newTotalDiscount;
                    total = value;
                    Notify(nameof(Discount));
                }
                else throw new ArgumentException();
            }
        }



    }
}
