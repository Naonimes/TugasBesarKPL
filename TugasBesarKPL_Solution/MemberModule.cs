using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TugasBesarKPL
{
    public class MemberModule
    {
        public enum MemberTier { Bronze, Silver, Gold }
        public MemberTier Tier { get; private set; } = MemberTier.Bronze;
        public int TotalPoints { get; private set; } = 0;

        private static readonly HttpClient client = new HttpClient();

        public void AddPoints(int points)
        {
            if (points < 0) throw new ArgumentException("Poin tidak bisa minus!");

            TotalPoints += points;
            UpdateTierAutomata();
        }

        private void UpdateTierAutomata()
        {
            if (TotalPoints >= 5000 && Tier != MemberTier.Gold)
            {
                Tier = MemberTier.Gold;
            }
            else if (TotalPoints >= 1000 && Tier == MemberTier.Bronze)
            {
                Tier = MemberTier.Silver;
            }
        }

        public async Task<string> GenerateDummyMemberAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                sw.Stop();
                Console.WriteLine($"[Performance] API GenerateDummyMember selesai: {sw.ElapsedMilliseconds} ms");

                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    var nameElement = doc.RootElement.GetProperty("results")[0].GetProperty("name");
                    string? first = nameElement.GetProperty("first").GetString();
                    string? last = nameElement.GetProperty("last").GetString();
                    return $"{first} {last}";
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                Console.WriteLine($"[Error] API Call Gagal: {ex.Message}");
                return "Guest";
            }
        }
    }
}