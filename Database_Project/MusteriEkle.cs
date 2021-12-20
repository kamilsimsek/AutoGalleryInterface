using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class MusteriEkle : Form
    {
        
        public MusteriEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=galeri_db;user ID= postgres; password=2001");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Dikkat!";
            Aciklama.ToolTipIcon = ToolTipIcon.Warning;
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(label9, "İstediğiniz kadar açıklama ekleyebilirsiniz..");
            
        }

        private void musteri_Ekleme_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("select * from musteriekle_ArabaSat(@p1,@p2,@p3,@p4)",baglanti);
            
       
            komut1.Parameters.AddWithValue("@p1", int.Parse(arabaIDText.Text));
            komut1.Parameters.AddWithValue("@p2", adsoyadtxt.Text);
            komut1.Parameters.AddWithValue("@p3", mailtxt.Text);
            komut1.Parameters.AddWithValue("@p4", telefontxt.Text);
            
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori ekleme gerçekleşti.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
          



        }
    }
}
