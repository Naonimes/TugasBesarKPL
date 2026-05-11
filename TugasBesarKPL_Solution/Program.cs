using System;
using TugasBesarKPL_Solution;

namespace TugasBesarKPL
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== DEMO INTERAKTIF TUGAS BESAR KPL ===");
                Console.WriteLine("1. [Demo] Automata Pesanan");
                Console.WriteLine("2. [Demo] Generics & Table-Driven (Menu)");
                Console.WriteLine("3. [Demo] Hitung Diskon Otomatis");
                Console.WriteLine("4. [Demo] API Tarik Data Member");
                Console.WriteLine("5. [Demo] API & Library Kriptografi (Pembayaran)");
                Console.WriteLine("0. Keluar Aplikasi");
                Console.Write("Pilih modul yang ingin didemokan (0-5): ");

                string pilihan = Console.ReadLine();
                Console.WriteLine("\n-----------------------------------------");

                try
                {
                    switch (pilihan)
                    {
                        case "1":
                            Console.WriteLine("--- SIMULASI STATUS PESANAN ---");
                            OrderModule order = new OrderModule();
                            Console.WriteLine($"Status Awal: {order.CurrentState}");
                            Console.WriteLine("Memproses pesanan...");
                            order.NextState();
                            Console.WriteLine($"Status Sekarang: {order.CurrentState} (Berubah karena Automata)");
                            break;

                        case "2":
                            Console.WriteLine("--- SIMULASI KATALOG MENU ---");
                            MenuModule menu = new MenuModule();

                            var storage = new MenuModule.DataStorage<string>();
                            storage.AddData("Nasi Goreng");
                            storage.AddData("Es Teh Manis");
                            Console.WriteLine($"Berhasil menyimpan {storage.Count} menu menggunakan Generics.");

                            Console.Write("Ketik kategori yang ingin dicari kodenya (Makanan/Minuman/Snack/Dessert): ");
                            string inputKategori = Console.ReadLine();
                            string kode = menu.GetCategoryCode(inputKategori);
                            Console.WriteLine($"Kode Kategori untuk '{inputKategori}' adalah: {kode}");
                            break;

                        case "3":
                            Console.WriteLine("--- SIMULASI KASIR DISKON ---");
                            DiscountModule discount = new DiscountModule();

                            Console.Write("Masukkan total belanja pelanggan (Misal: 150000): Rp ");
                            if (double.TryParse(Console.ReadLine(), out double totalBelanja))
                            {
                                double hargaAkhir = discount.CalculateDiscount(totalBelanja, DayOfWeek.Friday);
                                Console.WriteLine($"Harga setelah diskon spesial Hari Jumat: Rp {hargaAkhir}");
                            }
                            else
                            {
                                Console.WriteLine("Input tidak valid!");
                            }
                            break;

                        case "4":
                            Console.WriteLine("--- SIMULASI API MEMBER ---");
                            MemberModule member = new MemberModule();
                            Console.WriteLine("Sedang menghubungi server (API) untuk menarik data...");

                            string dummyName = await member.GenerateDummyMemberAsync();
                            Console.WriteLine($"Berhasil! Member yang mendaftar hari ini adalah: {dummyName}");
                            break;

                        case "5":
                            Console.WriteLine("--- SIMULASI PEMBAYARAN & STRUK ---");
                            PaymentModule payment = new PaymentModule();

                            Console.Write("Masukkan nominal pembayaran: Rp ");
                            if (double.TryParse(Console.ReadLine(), out double amountPaid))
                            {
                                Console.WriteLine("Memverifikasi pembayaran (Simulasi API Delay)...");
                                // Ini memanggil teknik 1: API (asynchronous)
                                bool isSuccess = await payment.VerifyPaymentAsync(amountPaid);

                                if (isSuccess)
                                {
                                    // Ini memanggil teknik 2: Code Reuse / Library (SHA256)
                                    string receiptData = $"Trx-{DateTime.Now.Ticks}-{amountPaid}";
                                    string receiptId = payment.GenerateReceiptId(receiptData);
                                    Console.WriteLine($"Pembayaran Berhasil! ID Struk Anda (SHA256): {receiptId}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input nominal tidak valid!");
                            }
                            break;

                        case "0":
                            isRunning = false;
                            Console.WriteLine("Demo selesai.");
                            break;

                        default:
                            Console.WriteLine("Pilihan tidak ada di menu.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[Defensive Programming Aktif] Mencegah Error: {ex.Message}");
                }

                if (isRunning)
                {
                    Console.WriteLine("\n-----------------------------------------");
                    Console.WriteLine("Tekan ENTER untuk kembali ke menu utama...");
                    Console.ReadLine();
                }
            }
        }
    }
}