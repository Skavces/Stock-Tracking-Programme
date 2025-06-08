using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Stok_Takip_Programı
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private int UrunID;

        public Form7(int urunID, string urunAdi, double alisFiyat, double satisFiyat, int stokAdet)
        {
            InitializeComponent();
            this.UrunID = urunID;

            textBox1.Text = urunAdi;
            textBox2.Text = alisFiyat.ToString();
            textBox3.Text = satisFiyat.ToString();
            textBox4.Text = stokAdet.ToString();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text;
            double alisFiyat = double.Parse(textBox2.Text);
            double satisFiyat = double.Parse(textBox3.Text);
            int stokAdet = int.Parse(textBox4.Text);

            string dbPath = Path.Combine(Application.StartupPath, "database", "stok.db");
            string connectionString = $"Data Source={dbPath};Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Urunler SET UrunAdi=@adi, AlisFiyati=@alis, SatisFiyati=@satis, StokAdedi=@stok WHERE UrunID=@id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@adi", urunAdi);
                    cmd.Parameters.AddWithValue("@alis", alisFiyat);
                    cmd.Parameters.AddWithValue("@satis", satisFiyat);
                    cmd.Parameters.AddWithValue("@stok", stokAdet);
                    cmd.Parameters.AddWithValue("@id", UrunID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Ürün başarıyla güncellendi.");
            this.Close();
        }
    }
}
