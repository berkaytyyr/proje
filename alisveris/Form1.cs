using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alisveris
{
    public partial class alisveris : Form
    {
        double toplamfiyat = 0;

        public alisveris()
        {
            InitializeComponent();
        }


        private void btnekle_Click_1(object sender, EventArgs e)
        {

            string urun = "";
            string miktar = "";
            double urunfiyat = 0;
            double miktar2 = 0;




            foreach (RadioButton rb in gburun.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    urun = rb.Text;
                    break;
                }
            }

            foreach (RadioButton rb in gbmiktar.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    miktar = rb.Text;
                    break;
                }
            }

            if (urun == "" || miktar == "")
            {
                MessageBox.Show("Lütfen ürün ve miktar seçiniz!");
                return;
            }



            if ((urun == "Su" || urun == "Yağ" || urun == "Bal" || urun == "Ekmek" || urun == "Süt" ||
               urun == "Meyvesuyu" || urun == "Kola" || urun == "İcetea" || urun == "Kek" || urun == "Cips" ||
                urun == "Çikolata" || urun == "Makarna") && (
                miktar == "1 tane" || miktar == "2 tane" || miktar == "3 tane" || miktar == "6 tane"))
            {
                if (miktar == "1 tane")
                    miktar2 = 1;
                if (miktar == "2 tane")
                    miktar2 = 2;
                if (miktar == "3 tane")
                    miktar2 = 3;
                if (miktar == "6 tane")
                    miktar2 = 5;
            }

            else if ((urun == "Elma" || urun == "Ayva" || urun == "Armut" || urun == "Portakal" || urun == "Karpuz" ||
                   urun == "Kavun" || urun == "Maydonoz" || urun == "Biber" || urun == "Salatalık" || urun == "Domates") && (
               miktar == "500g" || miktar == "1kg" || miktar == "2kg" || miktar == "5kg" || miktar == "10kg" || miktar == "15kg"))
            {
                if (miktar == "500g")
                    miktar2 = (0.5);
                else if (miktar == "1kg")
                    miktar2 = 1;
                else if (miktar == "2kg")
                    miktar2 = 2;
                else if (miktar == "5kg")
                    miktar2 = 5;
                else if (miktar == "10kg")
                    miktar2 = 10;
                else if (miktar == "15kg")
                    miktar2 = 15;
            }
            else
            {
                foreach (RadioButton rb in gburun.Controls.OfType<RadioButton>())
                    rb.Checked = false;

                foreach (RadioButton rb in gbmiktar.Controls.OfType<RadioButton>())
                    rb.Checked = false;
                MessageBox.Show("Lütfen geçerli miktar seçiniz!");

            }



            if (urun == "Elma")
                urunfiyat = miktar2 * 5;
            else if (urun == "Armut")
                urunfiyat = miktar2 * 7;
            else if (urun == "Ayva")
                urunfiyat = miktar2 * 10;
            else if (urun == "Portakal")
                urunfiyat = miktar2 * 8;
            else if (urun == "Karpuz")
                urunfiyat = miktar2 * 15;
            else if (urun == "Kavun")
                urunfiyat = miktar2 * 7;
            else if (urun == "Maydonoz")
                urunfiyat = miktar2 * 7;
            else if (urun == "Biber")
                urunfiyat = miktar2 * 10;
            else if (urun == "Salatalık")
                urunfiyat = miktar2 * 15;
            else if (urun == "Domates")
                urunfiyat = miktar2 * 10;
            else if (urun == "Su")
                urunfiyat = miktar2 * 15;
            else if (urun == "Yağ")
                urunfiyat = miktar2 * 50;
            else if (urun == "Bal")
                urunfiyat = miktar2 * 100;
            else if (urun == "Ekmek")
                urunfiyat = miktar2 * 15;
            else if (urun == "Süt")
                urunfiyat = miktar2 * 20;
            else if (urun == "Meyvesuyu")
                urunfiyat = miktar2 * 15;
            else if (urun == "Kola")
                urunfiyat = miktar2 * 10;
            else if (urun == "İcetea")
                urunfiyat = miktar2 * 25;
            else if (urun == "Kek")
                urunfiyat = miktar2 * 15;
            else if (urun == "Cips")
                urunfiyat = miktar2 * 7;
            else if (urun == "Çikolata")
                urunfiyat = miktar2 * 30;
            else if (urun == "Makarna")
                urunfiyat = miktar2 * 35;

            toplamfiyat = (toplamfiyat + urunfiyat);


            if (urunfiyat != 0)
            {
                lstsepet.Items.Add("ÜRÜN:  " + urun + "        MİKTAR:  " + miktar + "        FİYAT:  " + urunfiyat);

            }
            else
            {
                MessageBox.Show("Lütfen geçerli miktar seçiniz!");

                foreach (RadioButton rb in gburun.Controls.OfType<RadioButton>())
                    rb.Checked = false;

                foreach (RadioButton rb in gbmiktar.Controls.OfType<RadioButton>())
                    rb.Checked = false;
            }
            lbltop.Text = toplamfiyat.ToString();
        }

        private void btncikar_Click_1(object sender, EventArgs e)
        {
            if (lstsepet.SelectedIndex >= 0)
            {

                string secili = lstsepet.SelectedItem.ToString();
                string[] parcalar = secili.Split(new string[] { "FİYAT: " }, StringSplitOptions.None);
                double fiyat = 0;
                if (parcalar.Length > 1)
                {
                    double.TryParse(parcalar[1], out fiyat);
                }
                toplamfiyat -= fiyat;
                lbltop.Text = toplamfiyat.ToString();
                lstsepet.Items.RemoveAt(lstsepet.SelectedIndex);
            }
        }
    }
}

