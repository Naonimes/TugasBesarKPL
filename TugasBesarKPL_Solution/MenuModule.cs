using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TugasBesarKPL_Solution
{
    public class MenuItem
    {
        public string NamaMenu { get; set; }
        public int Harga { get; set; }
        public string Kategori { get; set; }
        public string KodeKategori { get; set; }

        public MenuItem(string namaMenu, int harga, string kategori, string kodeKategori)
        {
            NamaMenu = namaMenu;
            Harga = harga;
            Kategori = kategori;
            KodeKategori = kodeKategori;
        }
    }

    public class MenuModule
    {
        public class DataStorage<T>
        {
            private readonly List<T> _data = new List<T>();

            public void AddData(T item)
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "Data tidak boleh kosong!");

                _data.Add(item);
            }

            public List<T> GetAllData()
            {
                return _data;
            }

            public void RemoveData(T item)
            {
                _data.Remove(item);
            }

            public int Count => _data.Count;
        }

        private readonly DataStorage<MenuItem> _menuStorage = new DataStorage<MenuItem>();

        private readonly Dictionary<string, string> _categoryCodes = new Dictionary<string, string>
        {
            { "Makanan", "MKN-01" },
            { "Minuman", "MNM-02" },
            { "Snack", "SNK-03" },
            { "Dessert", "DST-04" }
        };

        public string GetCategoryCode(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Nama kategori tidak boleh kosong.");

            Stopwatch sw = Stopwatch.StartNew();

            string result = _categoryCodes.ContainsKey(categoryName)
                ? _categoryCodes[categoryName]
                : "UNKNOWN";

            sw.Stop();

            Debug.WriteLine($"[Performance] GetCategoryCode selesai: {sw.ElapsedTicks} ticks");

            return result;
        }

        public void TambahMenu(string namaMenu, int harga, string kategori)
        {
            if (string.IsNullOrWhiteSpace(namaMenu))
                throw new ArgumentException("Nama menu tidak boleh kosong.");

            if (namaMenu.Length > 50)
                throw new ArgumentException("Nama menu maksimal 50 karakter.");

            if (harga <= 0)
                throw new ArgumentException("Harga harus lebih dari 0.");

            string kodeKategori = GetCategoryCode(kategori);

            MenuItem menu = new MenuItem(namaMenu, harga, kategori, kodeKategori);
            _menuStorage.AddData(menu);
        }

        public List<MenuItem> GetDaftarMenu()
        {
            return _menuStorage.GetAllData();
        }

        public void HapusMenu(MenuItem menu)
        {
            if (menu == null)
                throw new ArgumentNullException(nameof(menu), "Menu tidak boleh kosong.");

            _menuStorage.RemoveData(menu);
        }
    }
}