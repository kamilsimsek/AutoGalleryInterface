using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class AnaMenu : Form
    {
        
        public AnaMenu()
        {
            InitializeComponent();
            tasarımDuzen();
        }
        

        private void tasarımDuzen()
        {
            panelAracMenu.Visible = false;
            panelMusteriMenu.Visible = false;
            panelTedarikciMenu.Visible = false;

        }
        private void menuSakla()
        {
            if (panelAracMenu.Visible == true) panelAracMenu.Visible = false;
            if (panelMusteriMenu.Visible == true) panelMusteriMenu.Visible = false;
        }
        private void menuGoster(Panel slideMenu)
        {
            if(slideMenu.Visible==false)
            {
                
                slideMenu.Visible = true;
            }
            else
            {
                slideMenu.Visible = false;
            }
        }

        private void slideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            menuGoster(panelAracMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            childForm(new AracEkle());
            menuSakla();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuSakla();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            childForm(new AracListele());
            menuSakla();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            menuGoster(panelMusteriMenu);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            childForm(new MusteriEkle());
            menuSakla();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menuSakla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            childForm(new MusteriListele());
            menuSakla();
        }
        private Form activeForm = null;
        private void childForm(Form chForm)
        {
            if(activeForm!=null)
            {
                activeForm.Close();

            }
            activeForm = chForm;
            chForm.TopLevel = false;
            chForm.FormBorderStyle = FormBorderStyle.None;
            chForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(chForm);
            panelChild.Tag = chForm;
            chForm.BringToFront();
            chForm.Show();

        }

        private void tedarikciAna_Click(object sender, EventArgs e)
        {
            menuGoster(panelTedarikciMenu);
        }

        private void panelChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tedarikciEkle_Click(object sender, EventArgs e)
        {
            childForm(new TedarikciEkle());
            menuSakla();
        }
    }
}
