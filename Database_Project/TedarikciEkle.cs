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
    public partial class TedarikciEkle : Form
    {
        public TedarikciEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=galeri_db;user ID= postgres; password=2001");
        private void tedarEkle_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("select * from tedarikciekleme(@p1,@p2)", baglanti);



            komut1.Parameters.AddWithValue("@p1", int.Parse(ıdText.Text));
            komut1.Parameters.AddWithValue("@p2", isimText.Text);
       


            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tedarikçi ekleme gerçekleşti.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from tedarikci";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
