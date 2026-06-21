using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TugasBesarKPL
{
    public class DiscountModule
    {
        private readonly Dictionary<DayOfWeek, double> _dailyDiscounts =
            new Dictionary<DayOfWeek, double>
        {
            { DayOfWeek.Monday, 0.10 },
            { DayOfWeek.Friday, 0.20 },
            { DayOfWeek.Sunday, 0.05 }
        };

        public double CalculateDiscount(double totalHarga, DayOfWeek hari)
        {
            if (totalHarga < 0)
            {
                throw new ArgumentException("Total harga tidak boleh negatif");
            }

            Stopwatch sw = Stopwatch.StartNew();

            double discountRate =
                _dailyDiscounts.ContainsKey(hari)
                ? _dailyDiscounts[hari]
                : 0;

            double finalPrice =
                Math.Round(totalHarga - (totalHarga * discountRate), 2);

            sw.Stop();

            Console.WriteLine($"Waktu eksekusi: {sw.ElapsedTicks}");

            return finalPrice;
        }
    }
}