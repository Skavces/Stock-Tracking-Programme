using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using Stok_Takip_Programı;

namespace Stok_Takip_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        public SQLiteConnection GetConnection()
        {
            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        public void LoadProducts()
        {
            using (var conn = GetConnection())
            {
                NewMethod(conn);
            }

            void NewMethod(SQLiteConnection conn)
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Urunler";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürünler yüklenemedi: " + ex.Message);
                }
            }
        }

        private void UrunleriYukle()
        {
            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Urunler";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }

            if (dataGridView1.Columns.Contains("UrunID"))
            {
                dataGridView1.Columns["UrunID"].Name = "UrunID";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçilen ürünü silmek istediğinize emin misiniz?",
                                                      "Ürün Sil",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int secilenID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);

                    string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "database", "stok.db");
                    string connectionString = $"Data Source={dbPath};Version=3;";

                    using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Urunler WHERE UrunID = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", secilenID);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }

                    MessageBox.Show("Ürün başarıyla silindi.");
                    UrunleriYukle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form5 ekleForm = new Form5();
            ekleForm.ShowDialog();

            LoadProducts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];

                int urunID = Convert.ToInt32(row.Cells["UrunID"].Value);
                string urunAdi = row.Cells["UrunAdi"].Value.ToString();
                double alisFiyat = Convert.ToDouble(row.Cells["AlisFiyati"].Value);
                double satisFiyat = Convert.ToDouble(row.Cells["SatisFiyati"].Value);
                int stokAdet = Convert.ToInt32(row.Cells["StokAdedi"].Value);

                Form7 frm7 = new Form7(urunID, urunAdi, alisFiyat, satisFiyat, stokAdet);
                frm7.ShowDialog();

                UrunleriYukle();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek ürünü seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.AramaYapildi += UrunAra;
            form6.ShowDialog();
        }

        private void UrunAra(string urunAdi)
        {
            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Urunler WHERE UrunAdi = @urunAdi COLLATE NOCASE";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@urunAdi", urunAdi);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TumUrunleriYukle();
        }

        private void TumUrunleriYukle()
        {
            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Urunler";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
