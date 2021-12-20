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
    public partial class AracListele : Form
    {
        public AracListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=galeri_db;user ID= postgres; password=2001");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from satilik_araba";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand updatecom = new NpgsqlCommand("select * from arabaguncelle(@p1,@p2)", baglanti);
            updatecom.Parameters.AddWithValue("@p1", int.Parse(ıdText.Text));
            updatecom.Parameters.AddWithValue("@p2", fiyatText.Text);

            updatecom.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarı ile güncellendi !");
        }
    }
}
