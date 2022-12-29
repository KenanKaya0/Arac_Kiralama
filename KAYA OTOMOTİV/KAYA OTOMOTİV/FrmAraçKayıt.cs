using System;
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
    public partial class FrmAraçKayıt : Form
    {
        Araç_Kiralama arackiralama = new Araç_Kiralama();
        public FrmAraçKayıt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string cümle = "insert into araç(plaka,marka,seri,yil,renk,km,yakıt,kiraücreti,resim,tarih,durumu) values (@plaka,@marka,@seri,@yil,@renk,@km,@yakıt,@kiraücreti,@resim,@tarih,@durumu)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", Plakatxt.Text);
            komut2.Parameters.AddWithValue("@marka", Markacombo.Text);
            komut2.Parameters.AddWithValue("@seri", Sericombo.Text);
            komut2.Parameters.AddWithValue("@yil", Yıltxt.Text);
            komut2.Parameters.AddWithValue("@renk", Renktxt.Text);
            komut2.Parameters.AddWithValue("@km", Kmtxt.Text);
            komut2.Parameters.AddWithValue("@yakıt", Yakıtcombo.Text);
            komut2.Parameters.AddWithValue("@kiraücreti", int.Parse(Ücrettxt.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");

            arackiralama.ekle_sil_güncelle(komut2, cümle);
            Sericombo.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";
        }
    }
}
