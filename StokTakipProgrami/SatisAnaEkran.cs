using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipProgrami
{
    public partial class SatisAnaEkran : Form
    {
        public SatisAnaEkran()
        {
            InitializeComponent();
        }
        Database1Entities context = new Database1Entities();

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SatisAnaEkran_Load(object sender, EventArgs e)
        {

        }

        private void bN1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = tNumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    tNumarator.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);

                }
            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }
        private void bNx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = tNumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    tNumarator.Text += b.Text;
                }
            }
            else if (b.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);

                }
            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }

        private void bN2_Click(object sender, EventArgs e)
        {

        }

        private void bN3_Click(object sender, EventArgs e)
        {

        }

        private void tGenelToplam_Click(object sender, EventArgs e)
        {

        }

        private void tBarkod_KeyDown(object sender, KeyEventArgs e) //Barkod enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    tMiktar.Text = barkod;
                    tBarkod.Clear();
                    tBarkod.Focus();
                }
                else
                {
                   if(context.Urun.Any(p=>p.Barkod == barkod))
                    {
                        var urun =context.Urun.Where(p=>p.Barkod == barkod).FirstOrDefault();
                        int satirsayisi =gridSatislistesi.Rows.Count;
                        double miktar =Convert.ToDouble(tMiktar.Text);
                        bool eklenmismi = false;
                        if(satirsayisi > 0)
                        {
                            for (int i = 0; i < satirsayisi; i++)
                            {
                                if (gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                                {
                                    gridSatislistesi.Rows[i].Cells["Miktar"].Value = miktar +Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value);
                                    gridSatislistesi.Rows[i].Cells["Toplam"].Value =Math.Round( Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Fiyat"].Value),2); //burada virgülden sonra 2 hane gözükmesi için yuvarlama yaptım...
                                    eklenmismi |= true;
                                }

                            }
                        }
                        if( !eklenmismi)
                        {
                            gridSatislistesi.Rows.Add();
                            gridSatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                            gridSatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd;
                            gridSatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                            gridSatislistesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                            gridSatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                            gridSatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                            gridSatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat,2);
                            gridSatislistesi.Rows[satirsayisi].Cells["AlisFiyat"].Value = urun.AlisFiyat;
                            gridSatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;

                        }
                    }
                    


                    
                }
            }

        }

        private void tBarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void tMiktar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBarkod_TextChanged_1(object sender, EventArgs e)
        {

        }
    }


}

