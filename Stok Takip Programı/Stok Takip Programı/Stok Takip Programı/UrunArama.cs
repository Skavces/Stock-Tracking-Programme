using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stok_Takip_Programı
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public delegate void AramaYapHandler(string urunAdi);
        public event AramaYapHandler AramaYapildi;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                AramaYapildi?.Invoke(textBox1.Text.Trim());
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün adı girin.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void form6_Load(object sender, EventArgs e)
        {

        }
    }
}
