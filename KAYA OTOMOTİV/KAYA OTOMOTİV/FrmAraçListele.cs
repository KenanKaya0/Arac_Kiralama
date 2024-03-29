﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAYA_OTOMOTİV
{
    public partial class FrmAraçListele : Form
    {
        Araç_Kiralama arackiralama = new Araç_Kiralama();
        public FrmAraçListele()
        {
            InitializeComponent();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            Plakatxt.Text = satır.Cells["plaka"].Value.ToString();
            Markacombo.Text = satır.Cells["marka"].Value.ToString();
            Sericombo.Text = satır.Cells["seri"].Value.ToString();
            Yıltxt.Text = satır.Cells["yil"].Value.ToString();
            Renktxt.Text = satır.Cells["renk"].Value.ToString();
            Kmtxt.Text = satır.Cells["km"].Value.ToString();
            Yakıtcombo.Text = satır.Cells["yakıt"].Value.ToString();
            Ücrettxt.Text = satır.Cells["kiraücreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();
        }

        private void FrmAraçListele_Load(object sender, EventArgs e)
        {
            YenileAraçlarListesi();
            try
            {
                comboBox1.SelectedIndex = 0;
            }
            catch
            {
                ;
            }
        }

        private void YenileAraçlarListesi()
        {
            string cümle = "select *from araç";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update araç set marka=@marka,seri=@seri,yil=@yil,renk=@renk,km=@km,yakıt=@yakıt,kiraücreti=@kiraücreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", Yıltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraücreti", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            YenileAraçlarListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from araç where plaka='"+satır.Cells["plaka"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            YenileAraçlarListesi();
            pictureBox2.ImageLocation = "";
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
        }

        private void Markacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sericombo.Items.Clear();
                if (Markacombo.SelectedIndex == 0)
                {
                    Sericombo.Items.Add("Astra");
                    Sericombo.Items.Add("Vectra");
                    Sericombo.Items.Add("Corsa");
                    Sericombo.Items.Add("Crossland");
                    Sericombo.Items.Add("gt");
                }
                else if (Markacombo.SelectedIndex == 1)
                {
                    Sericombo.Items.Add("Focus");
                    Sericombo.Items.Add("Fiesta");
                    Sericombo.Items.Add("Puma");
                    Sericombo.Items.Add("Crossland");
                    Sericombo.Items.Add("Tourneo");
                    Sericombo.Items.Add("Mustang");
                }
                else if (Markacombo.SelectedIndex == 2)
                {
                    Sericombo.Items.Add("A3");
                    Sericombo.Items.Add("A8");
                    Sericombo.Items.Add("Q8");
                    Sericombo.Items.Add("RS");
                    Sericombo.Items.Add("TT");
                }
                else if (Markacombo.SelectedIndex == 3)
                {
                    Sericombo.Items.Add("E36");
                    Sericombo.Items.Add("M5");
                    Sericombo.Items.Add("X5");
                    Sericombo.Items.Add("320");
                }
                else if (Markacombo.SelectedIndex == 4)
                {
                    Sericombo.Items.Add("C180");
                    Sericombo.Items.Add("E200");
                    Sericombo.Items.Add("G63");
                }
            }
            catch
            {
                ;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedIndex==0)
                {
                    YenileAraçlarListesi();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    string cümle = "select *from araç where durumu='BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string cümle = "select *from araç where durumu= 'DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch
            {
                ;
            }
        }
    }
}
