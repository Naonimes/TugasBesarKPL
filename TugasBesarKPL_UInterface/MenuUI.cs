using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TugasBesarKPL_Solution;

namespace TugasBesarKPL_UInterface
{
    public class MenuUI : UserControl
    {
        private MenuModule _logic = new MenuModule();
        private FlowLayoutPanel gridMenu;
        private Label lblKategori;
        private Panel pnlInput, pnlKeranjang;
        private TextBox txtNama, txtHarga;
        private string kategoriSaatIni = "MKN";

        // UBAH LABEL JADI TEXTBOX BIAR BISA DI-SCROLL
        private TextBox txtInfoKeranjang;

        public MenuUI()
        {
            Button btnMkn = new Button { Text = "Makanan", Location = new Point(20, 15), Width = 180, Height = 40, BackColor = Color.White };
            Button btnMnm = new Button { Text = "Minuman", Location = new Point(210, 15), Width = 180, Height = 40, BackColor = Color.White };
            lblKategori = new Label { Location = new Point(20, 60), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Italic) };

            gridMenu = new FlowLayoutPanel { Location = new Point(20, 85), Width = 390, Height = 340, AutoScroll = true };

            pnlKeranjang = new Panel { Location = new Point(20, 435), Size = new Size(390, 85), BackColor = Color.LightYellow, BorderStyle = BorderStyle.FixedSingle, Visible = false };

            // KONFIGURASI TEXTBOX SCROLL BARU
            txtInfoKeranjang = new TextBox
            {
                Location = new Point(5, 5),
                Size = new Size(265, 70),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.LightYellow, // Warna sama dengan panel biar menyatu
                BorderStyle = BorderStyle.None, // Hilangkan garis pinggir
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnSubmitOrder = new Button { Text = "SUBMIT", Location = new Point(280, 20), Width = 100, Height = 40, BackColor = Color.OrangeRed, ForeColor = Color.White, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            btnSubmitOrder.Click += (s, e) =>
            {
                AppSession.MejaTargetPesanan = "";
                AppSession.PindahKeOrder?.Invoke();
            };
            pnlKeranjang.Controls.AddRange(new Control[] { txtInfoKeranjang, btnSubmitOrder });

            Button btnBukaForm = new Button { Text = "➕ Tambah Menu Baru", Location = new Point(20, 530), Width = 390, Height = 40, BackColor = Color.LightSkyBlue, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            pnlInput = new Panel { Location = new Point(20, 575), Size = new Size(390, 80), BackColor = Color.WhiteSmoke, BorderStyle = BorderStyle.FixedSingle, Visible = false };
            txtNama = new TextBox { Location = new Point(10, 12), Width = 200, Font = new Font("Segoe UI", 10), PlaceholderText = "Nama Menu..." };
            txtHarga = new TextBox { Location = new Point(10, 45), Width = 200, Font = new Font("Segoe UI", 10), PlaceholderText = "Harga (misal: 15000)" };
            Button btnSimpan = new Button { Text = "ADD", Location = new Point(220, 11), Width = 150, Height = 58, BackColor = Color.MediumSeaGreen, ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            pnlInput.Controls.AddRange(new Control[] { txtNama, txtHarga, btnSimpan });

            btnBukaForm.Click += (s, e) => pnlInput.Visible = !pnlInput.Visible;
            btnSimpan.Click += BtnSimpan_Click;
            btnMkn.Click += (s, e) => RenderMenu("MKN");
            btnMnm.Click += (s, e) => RenderMenu("MNM");

            this.Controls.AddRange(new Control[] { btnMkn, btnMnm, lblKategori, gridMenu, pnlKeranjang, btnBukaForm, pnlInput });
            RenderMenu("MKN");
        }

        public void RefreshMode()
        {
            if (!string.IsNullOrEmpty(AppSession.MejaTargetPesanan))
            {
                pnlKeranjang.Visible = true;
                UpdateInfoKeranjang();
            }
            else
            {
                pnlKeranjang.Visible = false;
            }
        }

        private void UpdateInfoKeranjang()
        {
            if (string.IsNullOrEmpty(AppSession.MejaTargetPesanan) || !AppSession.KeranjangMeja.ContainsKey(AppSession.MejaTargetPesanan)) return;

            int totalItem = AppSession.KeranjangMeja[AppSession.MejaTargetPesanan].Count;
            decimal totalHarga = 0;

            var daftarPesanan = AppSession.KeranjangMeja[AppSession.MejaTargetPesanan]
                .GroupBy(m => new { m.Nama, m.Harga })
                .Select(g =>
                {
                    decimal subtotal = g.Count() * g.Key.Harga;
                    totalHarga += subtotal;
                    return $"{g.Count()}x {g.Key.Nama} (Rp {subtotal:N0})";
                });

            string teksMenu = string.Join("\r\n", daftarPesanan); // Ubah pemisah koma menjadi baris baru (enter)

            // Gunakan \r\n untuk membuat enter di TextBox Windows Forms
            txtInfoKeranjang.Text = $"Pesanan: {AppSession.MejaTargetPesanan} | Total: Rp {totalHarga:N0}\r\n------------------------\r\n{teksMenu}";
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNama.Text) && int.TryParse(txtHarga.Text, out int hargaAngka))
            {
                _logic.TambahMenu(kategoriSaatIni, txtNama.Text, hargaAngka);
                txtNama.Clear(); txtHarga.Clear(); pnlInput.Visible = false; RenderMenu(kategoriSaatIni);
            }
        }

        private void RenderMenu(string katID)
        {
            kategoriSaatIni = katID;
            gridMenu.Controls.Clear();
            lblKategori.Text = katID == "MKN" ? "Kategori: Makanan" : "Kategori: Minuman";

            foreach (var item in _logic.AmbilMenu(katID))
            {
                string hargaK = (item.Harga / 1000) + "K";
                Button btnItem = new Button { Text = $"{item.Nama}\n{hargaK}\n{item.Kode}\n\n[+ Pesan]", Width = 115, Height = 110, BackColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9) };

                btnItem.Click += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(AppSession.MejaTargetPesanan))
                    {
                        AppSession.KeranjangMeja[AppSession.MejaTargetPesanan].Add(item);
                        UpdateInfoKeranjang();
                    }
                    else
                    {
                        MessageBox.Show("Buat meja baru di menu Order dan klik '+ Tambah Pesanan' terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                gridMenu.Controls.Add(btnItem);
            }
        }
    }
}