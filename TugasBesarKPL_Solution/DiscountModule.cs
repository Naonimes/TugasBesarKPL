using System;
using System.Collections.Generic;
using System.Linq;

namespace TugasBesarKPL_Solution
{
    // Class baru untuk menyimpan data promo kalender
    public class CustomPromo
    {
        public DateTime Tanggal { get; set; }
        public string NamaPromo { get; set; }
        public decimal Multiplier { get; set; }
        public string Deskripsi { get; set; }
    }

    public class DiscountModule
    {
        private readonly Dictionary<DayOfWeek, (string namaPromo, decimal multiplier)> _promoTable =
            new Dictionary<DayOfWeek, (string, decimal)>
            {
                { DayOfWeek.Friday,   ("Jumat Berkah - Diskon 20%", 0.8m) },
                { DayOfWeek.Saturday, ("Akhir Pekan - Diskon 10%", 0.9m) },
                { DayOfWeek.Sunday,   ("Akhir Pekan - Diskon 10%", 0.9m) }
            };

        // Database sementara untuk promo kalender
        private List<CustomPromo> _customPromos = new List<CustomPromo>();

        // Method 1: Kompatibilitas untuk PaymentUI (Berbasis Nama Hari)
        public (string namaPromo, decimal multiplier) GetActivePromo(DayOfWeek hariIni)
        {
            if (_promoTable.TryGetValue(hariIni, out var promo))
            {
                return promo;
            }
            return ("Tidak ada promo aktif", 1.0m);
        }

        // Method 2: Khusus untuk DiscountUI (Berbasis Tanggal Kalender)
        public (string namaPromo, decimal multiplier) GetActivePromo(DateTime tanggalIni)
        {
            // Cek promo custom yang ditambahkan manual lewat UI
            var custom = _customPromos.FirstOrDefault(p => p.Tanggal.Date == tanggalIni.Date);
            if (custom != null)
            {
                return (custom.NamaPromo, custom.Multiplier);
            }

            // Jika tidak ada promo custom, kembalikan ke promo mingguan bawaan
            return GetActivePromo(tanggalIni.DayOfWeek);
        }

        public decimal HitungTotal(decimal nominal, decimal multiplier)
        {
            decimal hasil = nominal * multiplier;
            return Math.Round(hasil);
        }

        public void TambahPromoCustom(DateTime tgl, string nama, decimal multiplier, string deskripsi)
        {
            _customPromos.Add(new CustomPromo { Tanggal = tgl.Date, NamaPromo = nama, Multiplier = multiplier, Deskripsi = deskripsi });
        }

        public List<CustomPromo> GetCustomPromos() => _customPromos;
    }
}