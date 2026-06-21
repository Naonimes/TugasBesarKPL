using System;
using System.Collections.Generic;

namespace TugasBesarKPL_Solution
{
    // 1. Membuat cetakan data (Model) untuk item menu
    public class MenuItem
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
    }

    public class MenuModule
    {
        // 2. Database sekarang menyimpan objek MenuItem
        private Dictionary<string, List<MenuItem>> databaseMenu = new Dictionary<string, List<MenuItem>>();

        public MenuModule()
        {
            // Data default saat aplikasi pertama kali dijalankan
            databaseMenu["MKN"] = new List<MenuItem>
            {
                new MenuItem { Kode = "MKN-01", Nama = "Nasi Goreng", Harga = 18000 },
                new MenuItem { Kode = "MKN-02", Nama = "Mie Tek-Tek", Harga = 15000 },
                new MenuItem { Kode = "MKN-03", Nama = "Mie Dog-Dog", Harga = 15000 }
            };

            databaseMenu["MNM"] = new List<MenuItem>
            {
                new MenuItem { Kode = "MNM-01", Nama = "Es Teh Manis", Harga = 5000 },
                new MenuItem { Kode = "MNM-02", Nama = "Kopi Susu", Harga = 12000 },
                new MenuItem { Kode = "MNM-03", Nama = "Matcha Latte", Harga = 15000 }
            };
        }

        public List<MenuItem> AmbilMenu(string kategori)
        {
            return databaseMenu.ContainsKey(kategori) ? databaseMenu[kategori] : new List<MenuItem>();
        }

        // Fungsi cerdas untuk menambah menu & auto-generate kode
        public void TambahMenu(string kategori, string namaBaru, int hargaBaru)
        {
            if (!databaseMenu.ContainsKey(kategori))
            {
                databaseMenu[kategori] = new List<MenuItem>();
            }

            var daftarMenu = databaseMenu[kategori];

            // Mencari angka terbesar dari kode yang sudah ada
            int maxId = 0;
            foreach (var item in daftarMenu)
            {
                string[] parts = item.Kode.Split('-'); // Memecah "MKN-01" jadi ["MKN", "01"]
                if (parts.Length == 2 && int.TryParse(parts[1], out int id))
                {
                    if (id > maxId) maxId = id;
                }
            }

            // Generate kode baru (Misal maxId 3, maka +1 jadi 4. Format D2 membuatnya jadi "04")
            int nextId = maxId + 1;
            string kodeBaru = $"{kategori}-{nextId:D2}";

            // Masukkan ke database
            daftarMenu.Add(new MenuItem { Kode = kodeBaru, Nama = namaBaru, Harga = hargaBaru });
        }
    }
}