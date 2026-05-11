using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TugasBesarKPL
{
    public class PaymentModule
    {
        // Teknik 1: API
        public async Task<bool> VerifyPaymentAsync(double amount)
        {
            // Defensive Programming (DbC)
            if (amount <= 0) throw new ArgumentException("Jumlah pembayaran tidak boleh 0.");

            Stopwatch sw = Stopwatch.StartNew(); // Performance Testing
            await Task.Delay(300); // Simulasi delay internet
            sw.Stop();

            Console.WriteLine($"[Performance] Verifikasi Pembayaran API selesai: {sw.ElapsedMilliseconds} ms");
            return true;
        }

        // Teknik 2: Code Reuse / Library (SHA256 Cryptography)
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
