using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TugasBesarKPL_Solution
{
    public class OrderConfig
    {
        public string NamaKafe { get; set; }
        public decimal PPN { get; set; }
    }

    public class OrderModule
    {
        private Dictionary<string, int> orderStates = new Dictionary<string, int>();

        public OrderConfig LoadConfig()
        {
            try
            {
                string jsonString = File.ReadAllText("config_order.json");
                return JsonSerializer.Deserialize<OrderConfig>(jsonString);
            }
            catch
            {
                return new OrderConfig { NamaKafe = "Kafe Kita (Default)", PPN = 0.11m };
            }
        }

        public void TambahMejaBaru(string namaMeja)
        {
            if (!orderStates.ContainsKey(namaMeja))
            {
                orderStates[namaMeja] = 0;
                AppSession.KeranjangMeja[namaMeja] = new List<MenuItem>();
            }
        }

        public void HapusMeja(string namaMeja)
        {
            if (orderStates.ContainsKey(namaMeja))
            {
                orderStates.Remove(namaMeja);
                if (AppSession.KeranjangMeja.ContainsKey(namaMeja))
                {
                    AppSession.KeranjangMeja.Remove(namaMeja);
                }
            }
        }

        public List<string> GetAllMeja() => new List<string>(orderStates.Keys);
        public int GetState(string meja) => orderStates.ContainsKey(meja) ? orderStates[meja] : 0;

        // FUNGSI BARU: Untuk memaksa pindah status ke "PAID" dari UI Payment
        public void SetStatePaid(string meja)
        {
            if (orderStates.ContainsKey(meja)) orderStates[meja] = 1;
        }

        public bool BisaMaju(string meja) => GetState(meja) < 3;

        public void MajukanStatus(string meja)
        {
            if (BisaMaju(meja)) orderStates[meja]++;
        }

        public string GetStateText(int state)
        {
            string[] states = { "DRAFT", "PAID", "COOKING", "SERVED" };
            return states[state];
        }
    }
}