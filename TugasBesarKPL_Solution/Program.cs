using System;

namespace TugasBesarKPL
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear(); 
                Console.WriteLine("=== SISTEM MANAJEMEN KAFE ===");
                Console.WriteLine("1. Demo Modul Pesanan");
                Console.WriteLine("2. Demo Modul Katalog Menu");
                Console.WriteLine("3. Demo Modul Diskon");
                Console.WriteLine("0. Keluar Aplikasi");
                Console.Write("Pilih menu (0-3): ");

                string pilihan = Console.ReadLine();

                Console.WriteLine("\n----------------------------");

                switch (pilihan)
                {
                    case "1":
                        Console.WriteLine("[Menjalankan Modul Pesanan...]");
                        OrderModule order = new OrderModule();
                        Console.WriteLine($"Status Awal: {order.CurrentState}");
                        order.NextState();
                        break;

                    case "2":
                        Console.WriteLine("[Menjalankan Modul Katalog Menu...]");
                        MenuModule menu = new MenuModule();
                        string kode = menu.GetCategoryCode("Makanan");
                        Console.WriteLine($"Kode pencarian Makanan: {kode}");
                        break;

                    case "3":
                        Console.WriteLine("[Menjalankan Modul Diskon...]");
                        DiscountModule discount = new DiscountModule();
                        double hargaAkhir = discount.CalculateDiscount(100000, DayOfWeek.Friday);
                        Console.WriteLine($"Harga setelah diskon hari Jumat: Rp{hargaAkhir}");
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid, silakan coba lagi.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nTekan ENTER untuk kembali ke menu utama...");
                    Console.ReadLine();
                }
            }
        }
    }
}