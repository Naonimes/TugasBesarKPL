namespace TugasBesarKPL_Solution.Forms
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNamaMenu = new TextBox();
            txtHarga = new TextBox();
            cmbKategori = new ComboBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnRefresh = new Button();
            dgvMenu = new DataGridView();
            lblJudul = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(41, 98);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 0;
            label1.Text = "Nama Menu";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(41, 144);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 1;
            label2.Text = "Harga";

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(41, 196);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 2;
            label3.Text = "Kategori";

            // txtNamaMenu
            txtNamaMenu.Location = new Point(175, 95);
            txtNamaMenu.Name = "txtNamaMenu";
            txtNamaMenu.Size = new Size(270, 31);
            txtNamaMenu.TabIndex = 3;

            // txtHarga
            txtHarga.Location = new Point(175, 141);
            txtHarga.Name = "txtHarga";
            txtHarga.Size = new Size(270, 31);
            txtHarga.TabIndex = 4;

            // cmbKategori
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(175, 193);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(270, 33);
            cmbKategori.TabIndex = 5;

            // btnTambah
            btnTambah.Location = new Point(41, 253);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(112, 34);
            btnTambah.TabIndex = 6;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = true;
            btnTambah.Click += btnTambah_Click;

            // btnEdit
            btnEdit.Location = new Point(175, 253);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;

            // btnHapus
            btnHapus.Location = new Point(312, 253);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(112, 34);
            btnHapus.TabIndex = 8;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            btnHapus.Click += btnHapus_Click;

            // btnRefresh
            btnRefresh.Location = new Point(449, 253);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // dgvMenu
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(40, 318);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 62;
            dgvMenu.Size = new Size(897, 264);
            dgvMenu.TabIndex = 10;

            // lblJudul
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJudul.Location = new Point(387, 33);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(252, 38);
            lblJudul.TabIndex = 11;
            lblJudul.Text = "Kelola Data Menu";

            // MenuForm
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 594);
            Controls.Add(lblJudul);
            Controls.Add(dgvMenu);
            Controls.Add(btnRefresh);
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(btnTambah);
            Controls.Add(cmbKategori);
            Controls.Add(txtHarga);
            Controls.Add(txtNamaMenu);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MenuForm";
            Text = "Manajemen Menu Restoran";
            Load += MenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNamaMenu;
        private TextBox txtHarga;
        private ComboBox cmbKategori;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnRefresh;
        private DataGridView dgvMenu;
        private Label lblJudul;
    }
}