using System;
using System.Windows.Forms;

namespace TugasBesarKPL_Solution.Forms
{
    public partial class MenuForm : Form
    {
        private readonly MenuModule menuModule = new MenuModule();
        private MenuItem selectedMenu = null;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            cmbKategori.Items.Clear();
            cmbKategori.Items.AddRange(new string[]
            {
                "Makanan",
                "Minuman",
                "Snack",
                "Dessert"
            });

            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKategori.Text = "Makanan";

            SetupDataGridView();
            RefreshDataMenu();

            dgvMenu.CellClick += dgvMenu_CellClick;
        }

        private void SetupDataGridView()
        {
            dgvMenu.AutoGenerateColumns = false;
            dgvMenu.Columns.Clear();

            dgvMenu.Columns.Add("NamaMenu", "Nama Menu");
            dgvMenu.Columns.Add("Harga", "Harga");
            dgvMenu.Columns.Add("Kategori", "Kategori");
            dgvMenu.Columns.Add("KodeKategori", "Kode Kategori");

            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.MultiSelect = false;
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.ReadOnly = true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                string namaMenu = txtNamaMenu.Text.Trim();
                string kategori = cmbKategori.Text;

                if (!int.TryParse(txtHarga.Text, out int harga))
                {
                    MessageBox.Show("Harga harus berupa angka.");
                    return;
                }

                menuModule.TambahMenu(namaMenu, harga, kategori);

                MessageBox.Show("Menu berhasil ditambahkan.");
                ClearInput();
                RefreshDataMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMenu == null)
                {
                    MessageBox.Show("Pilih menu yang ingin diedit.");
                    return;
                }

                string namaMenu = txtNamaMenu.Text.Trim();
                string kategori = cmbKategori.Text;

                if (string.IsNullOrWhiteSpace(namaMenu))
                {
                    MessageBox.Show("Nama menu tidak boleh kosong.");
                    return;
                }

                if (!int.TryParse(txtHarga.Text, out int harga))
                {
                    MessageBox.Show("Harga harus berupa angka.");
                    return;
                }

                if (harga <= 0)
                {
                    MessageBox.Show("Harga harus lebih dari 0.");
                    return;
                }

                selectedMenu.NamaMenu = namaMenu;
                selectedMenu.Harga = harga;
                selectedMenu.Kategori = kategori;
                selectedMenu.KodeKategori = menuModule.GetCategoryCode(kategori);

                MessageBox.Show("Menu berhasil diperbarui.");
                ClearInput();
                RefreshDataMenu();
                selectedMenu = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMenu == null)
                {
                    MessageBox.Show("Pilih menu yang ingin dihapus.");
                    return;
                }

                menuModule.HapusMenu(selectedMenu);

                MessageBox.Show("Menu berhasil dihapus.");
                ClearInput();
                RefreshDataMenu();
                selectedMenu = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataMenu();
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var daftarMenu = menuModule.GetDaftarMenu();

            if (e.RowIndex >= daftarMenu.Count)
            {
                return;
            }

            selectedMenu = daftarMenu[e.RowIndex];

            txtNamaMenu.Text = selectedMenu.NamaMenu;
            txtHarga.Text = selectedMenu.Harga.ToString();
            cmbKategori.Text = selectedMenu.Kategori;
        }

        private void RefreshDataMenu()
        {
            dgvMenu.Rows.Clear();

            foreach (MenuItem menu in menuModule.GetDaftarMenu())
            {
                dgvMenu.Rows.Add(
                    menu.NamaMenu,
                    menu.Harga,
                    menu.Kategori,
                    menu.KodeKategori
                );
            }
        }

        private void ClearInput()
        {
            txtNamaMenu.Clear();
            txtHarga.Clear();
            cmbKategori.Text = "Makanan";
        }
    }
}