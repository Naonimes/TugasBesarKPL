using System;

namespace TugasBesarKPL
{
    class Program
    {
        static void Main()
        {
            DiscountModule discount = new DiscountModule();

            double hasil = discount.CalculateDiscount(
                100000,
                DayOfWeek.Friday
            );

            Console.WriteLine("Harga akhir: " + hasil);
        }
    }
}