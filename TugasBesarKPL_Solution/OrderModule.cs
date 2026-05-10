using System;
using System.Diagnostics;
using System.Text.Json;
using System.Collections.Generic;

namespace TugasBesarKPL
{
    public class OrderModule
    {
        public enum OrderState { Draft, Paid, Cooking, Served }
        public OrderState CurrentState { get; private set; } = OrderState.Draft;

        
        public void NextState()
        {
            
            if (CurrentState == OrderState.Served)
                throw new InvalidOperationException("Pesanan sudah selesai, tidak bisa ganti status.");

            CurrentState++;
        }

       
        public string LoadConfig()
        {
        
            Stopwatch sw = Stopwatch.StartNew();

         
            string jsonString = "{\"StoreName\": \"Kafe Kita\", \"TaxRate\": 0.11}";
            var config = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            sw.Stop();
            Console.WriteLine($"[Performance] LoadConfig selesai: {sw.ElapsedMilliseconds} ms");

            return config["StoreName"].GetString();
        }
    }
}