using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TugasBesarKPL
{
    public class PaymentModule
    {
        public async Task<bool> VerifyPaymentAsync(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Jumlah pembayaran tidak boleh 0.");

            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(300);
            sw.Stop();

            Console.WriteLine($"[Performance] Verifikasi Pembayaran API selesai: {sw.ElapsedMilliseconds} ms");
            return true;
        }

        public string GenerateReceiptId(string data)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(bytes).Replace("-", "").Substring(0, 8);
            }
        }
    }
}