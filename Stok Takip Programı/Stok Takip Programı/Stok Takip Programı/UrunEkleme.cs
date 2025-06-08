using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Stok_Takip_Programı
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private SQLiteConnection GetConnection()
        {
            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text.Trim();
            string alis = textBox2.Text.Trim();
            string satis = textBox3.Text.Trim();
            string stok = textBox4.Text.Trim();

            if (urunAdi == "" || alis == "" || satis == "" || stok == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Urunler (UrunAdi, AlisFiyati, SatisFiyati, StokAdedi) VALUES (@adi, @alis, @satis, @stok)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@adi", urunAdi);
                        cmd.Parameters.AddWithValue("@alis", Convert.ToDouble(alis));
                        cmd.Parameters.AddWithValue("@satis", Convert.ToDouble(satis));
                        cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(stok));
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ürün başarıyla eklendi!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

    }
}