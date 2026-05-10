using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TugasBesarKPL_Solution
{
    public class MenuModule
    {
        // Teknik 1: Parameterization / Generics
        public class DataStorage<T>
        {
            private List<T> _data = new List<T>();

            public void AddData(T item)
            {
                // Defensive Programming / DbC
                if (item == null)
                    throw new ArgumentNullException(nameof(item), "Data tidak boleh kosong!");

                _data.Add(item);
            }

            public int Count => _data.Count;
        }

        // Teknik 2: Table-Driven Construction
        private readonly Dictionary<string, string> _categoryCodes = new Dictionary<string, string>
        {
            { "Makanan", "MKN-01" },
            { "Minuman", "MNM-02" },
            { "Snack", "SNK-03" },
            { "Dessert", "DST-04" }
        };

        public string GetCategoryCode(string categoryName)
        {
            // Defensive Programming / DbC
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Nama kategori tidak boleh kosong.");

            Stopwatch sw = Stopwatch.StartNew();

            string result = _categoryCodes.ContainsKey(categoryName)
                ? _categoryCodes[categoryName]
                : "UNKNOWN";

            sw.Stop();

            Console.WriteLine($"[Performance] GetCategoryCode selesai: {sw.ElapsedTicks} ticks");

            return result;
        }
    }
}
