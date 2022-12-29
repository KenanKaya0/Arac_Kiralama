using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAYA_OTOMOTİV
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMüşteriEkle ekle = new FrmMüşteriEkle();
            this.Hide();
            ekle.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMüşteriListele listele = new FrmMüşteriListele();
            listele.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmAraçKayıt kayıt = new FrmAraçKayıt();
            kayıt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAraçListele araclistele = new FrmAraçListele();
            araclistele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSözleşme sözleşme = new FrmSözleşme();
            sözleşme.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmSatış satış = new FrmSatış();
            satış.ShowDialog();

        }
    }
}
