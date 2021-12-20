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
    public partial class MusteriListele : Form
    {
        public MusteriListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; database=galeri_db;user ID= postgres; password=2001");

        
    private void Form4_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sorgu = "select * from musteri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                NpgsqlCommand deletecom = new NpgsqlCommand("select * from musterisil(@p1)",baglanti);
                deletecom.Parameters.AddWithValue("@p1", int.Parse(silText.Text));
                deletecom.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarı ile silindi !");
            }
            catch(Exception)
            {
                MessageBox.Show("Müşterinin ilişiği kesilemedi ! ");
            }
        }
    }
}
