using Microsoft.VisualStudio.TestTools.UnitTesting;
using TugasBesarKPL;
using System;
using System.Threading.Tasks;

namespace TugasBesarKPL.Tests
{
    [TestClass]
    public class MemberModuleTests
    {
        [TestMethod]
        public void AddPoints_ShouldBecomeSilver_WhenTotalPoints1000()
        {
            var member = new MemberModule();
            member.AddPoints(1000);
            Assert.AreEqual(MemberModule.MemberTier.Silver, member.Tier);
        }

        [TestMethod]
        public void AddPoints_ShouldBecomeGold_WhenTotalPointsReach5000()
        {
            var member = new MemberModule();
            member.AddPoints(1000); // Jadi Silver
            member.AddPoints(4000); // Nambah 4000, total 5000, jadi Gold
            Assert.AreEqual(MemberModule.MemberTier.Gold, member.Tier);
        }

        [TestMethod]
        public void AddPoints_ShouldThrowException_WhenPointsAreNegative()
        {
            var member = new MemberModule();
            bool isExceptionThrown = false;

            try
            {
                // Kita tes memasukkan poin minus
                member.AddPoints(-50);
            }
            catch (ArgumentException)
            {
                // Jika kode utama berhasil menolak poin minus (DbC jalan), 
                // maka akan masuk ke sini.
                isExceptionThrown = true;
            }

            // Pastikan error benar-benar terjadi
            Assert.IsTrue(isExceptionThrown, "DbC gagal: Exception tidak dilempar untuk poin negatif!");
        }

        [TestMethod]
        public async Task GenerateDummyMemberAsync_ShouldReturnName_WhenApiSuccess()
        {
            var member = new MemberModule();
            var result = await member.GenerateDummyMemberAsync();

            // Pastikan result tidak null dan bukan fallback "Guest"
            Assert.IsNotNull(result);
            Assert.AreNotEqual("Guest", result);
        }

        [TestMethod]
        public async Task GenerateDummyMemberAsync_ShouldReturnDefaultName_WhenApiFails()
        {
            // ARRANGE
            // Kita sengaja masukkan URL yang salah/ngaco untuk mensimulasikan gagal koneksi
            string fakeUrl = "https://url-salah-ini-pasti-gagal.com";
            var memberModule = new MemberModule();

            // ACT
            // Memanggil fungsi dengan URL yang salah
            string result = await memberModule.GenerateDummyMemberAsync(fakeUrl);

            // ASSERT
            // Pastikan hasilnya bukan error/crash, tapi kembali ke nama default "Guest"
            Assert.AreEqual("Guest", result);
        }
    }
}