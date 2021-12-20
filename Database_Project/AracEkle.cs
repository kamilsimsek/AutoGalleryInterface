using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class AracEkle : Form
    {
        public AracEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=galeri_db;user ID= postgres; password=2001");

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void arac_Ekleme_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("select * from arabaekleme(@p1,@p2,@p3,@p4,@p5)", baglanti);


           
            komut1.Parameters.AddWithValue("@p1", int.Parse(tedarikciText.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(modelText.Text));
            komut1.Parameters.AddWithValue("@p3", int.Parse(kateKodText.Text));
            komut1.Parameters.AddWithValue("@p4", arabaFiyatText.Text);
            komut1.Parameters.AddWithValue("@p5", kmText.Text);


            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç ekleme gerçekleşti.");
        }

        private void close_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
