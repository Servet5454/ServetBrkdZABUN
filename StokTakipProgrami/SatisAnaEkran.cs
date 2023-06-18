using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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

        private void SatisAnaEkran_Load(object sender, EventArgs e) //Anasatış ekranının ilk yükleneceği yer burası
        {
            hizliButonUrunGetir(); //metodu çağıırıyoruz
            b5.Text =5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
            
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
                    if (context.Urun.Any(p => p.Barkod == barkod)) //normal barkodlu urun varsa buradsa getiriyorum...
                    {
                        var urun = context.Urun.Where(p => p.Barkod == barkod).FirstOrDefault();
                        UrunGetir(urun, barkod, Convert.ToDouble(tMiktar.Text));
                    }
                    else//yoksa terazili urunu getiriyorum...
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (context.Terazi.Any(p => p.TeraziOnEk == onek))
                        {
                            string TeraziBarkodNo = barkod.Substring(2, 5);
                            if (context.Urun.Any(p => p.Barkod == TeraziBarkodNo))
                            {
                                var teraziurunu = context.Urun.Where(p => p.Barkod == TeraziBarkodNo).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetir(teraziurunu, TeraziBarkodNo, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("Manav Ürün Ekleme Sayfası");
                            }

                        }
                        else
                        {
                            Console.Beep(900, 2000);
                            MessageBox.Show("Ürün Ekleme Sayfası");
                        }

                    }
                }
                gridSatislistesi.ClearSelection();
                GenelToplam();

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

        private void tMiktar_TextChanged_1(object sender, EventArgs e)
        {

        }
       

        private void gridSatislistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                gridSatislistesi.Rows.Remove(gridSatislistesi.CurrentRow);
                gridSatislistesi.ClearSelection();
                GenelToplam();
                tBarkod.Focus();
            }
        }
       
        
        #region Metotlar

        private void bh_MouseDown(object sender, MouseEventArgs e)// bu metoda hızlı tuşların sağ tık işlemini bağlayacağım ve böylelikle tek bir yerden işlemleri halledeceğim bu metoda alttaki sil click i bağlı
        {
            if(e.Button == MouseButtons.Right)
            {
                Button btn =(Button)sender;
                if (!btn.Text.StartsWith("-")) // burada tire ile başlamıyorsaya bağladık mevzuyu...
                {
                    int buttonid =Convert.ToInt32(btn.Name.ToString().Substring(2,btn.Name.Length - 2));
                    ContextMenuStrip strip = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + buttonid.ToString();
                    sil.Click += Sil_Click; //burada 
                    strip.Items.Add( sil );
                    this.ContextMenuStrip = strip;
                }

            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int buttonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));//Sonunda Butonid ye ulaştık :)
            var guncellenecekurun = context.HizliUrunler.Find(buttonid);
            guncellenecekurun.Barkod = "-";
            guncellenecekurun.UrunAdi = "-";
            guncellenecekurun.Fiyat = 0;
            context.SaveChanges();
            double fiyat =0;
            Button btn = this.Controls.Find("bH" + buttonid, true).FirstOrDefault() as Button;
            btn.Text = "-" + "\n" + fiyat.ToString("C2");

        }

        private void GenelToplam()
        {

            double toplam = 0;
            for (int i = 0; i < gridSatislistesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Toplam"].Value);
            }
            tGenelToplam.Text = toplam.ToString("C2");
            tMiktar.Text = "1";
            tBarkod.Clear();
            tBarkod.Focus();

        }
        private void UrunGetir(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridSatislistesi.Rows.Count;
            //double miktar = Convert.ToDouble(tMiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridSatislistesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value);
                        gridSatislistesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Fiyat"].Value), 2); //burada virgülden sonra 2 hane gözükmesi için yuvarlama yaptım...
                        eklenmismi |= true;
                    }

                }
            }
            if (!eklenmismi)
            {
                gridSatislistesi.Rows.Add();
                gridSatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridSatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd;
                gridSatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatislistesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridSatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridSatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridSatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                gridSatislistesi.Rows[satirsayisi].Cells["AlisFiyat"].Value = urun.AlisFiyat;
                gridSatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;

            }
        }
        private void hizliButonUrunGetir()
        {
            var hizliurun =context.HizliUrunler.ToList();
            foreach (var item in hizliurun)
            {
                Button bH = this.Controls.Find("bH" + item.Id,true).FirstOrDefault() as Button;
                if(bH != null)
                {
                    double fiyat =Islemler.DoubleYap(item.Fiyat.ToString()); //double yap olarak static bir metot oluşturup oradan çeviri yapıyorumm...
                    bH.Text = item.UrunAdi + "\n" + fiyat.ToString("C2");
                }
            }
        }

        private void Temizle()
        {
            
            tBarkod.Clear();
            txtOdenen.Clear();
            txtparaustu.Clear();
            tGenelToplam.Text = 0.ToString("C2");
            chSatisIadeIslemi.Checked = false;
            tNumarator.Clear();
            tMiktar.Text = "1";
            gridSatislistesi.Rows.Clear();
            tBarkod.Focus();
        }
        private void SatisYap(string odemesekli)
        {
            int satirsayisi = gridSatislistesi.Rows.Count;
            bool satisiade = chSatisIadeIslemi.Checked;
            double alisfiyattoplam = 0;
            if(satirsayisi > 0)
            {
                try
                {
                    int? islemno = context.Islem.First().IslemNo;
                    Satis satis = new Satis();
                    for (int i = 0; i < satirsayisi; i++)
                    {
                        satis.IslemNo = islemno;
                        satis.UrunAdi = gridSatislistesi.Rows[i].Cells["UrunAdi"].Value.ToString().Substring(0, Math.Min(50, gridSatislistesi.Rows[i].Cells["UrunAdi"].Value.ToString().Length));
                        satis.UrunGrup = gridSatislistesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                        satis.Barkod = gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString();
                        satis.Birim = gridSatislistesi.Rows[i].Cells["Birim"].Value.ToString();
                        satis.AlisFiyat = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["AlisFiyat"].Value.ToString());
                        satis.SatisFiyat = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Fiyat"].Value.ToString());
                        satis.Miktar = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString());
                        satis.Toplam = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Toplam"].Value.ToString());
                        satis.KdvTutari = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["KdvTutari"].Value.ToString())
                            * Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString());
                        satis.OdemeSekli = odemesekli;
                        satis.Iade = satisiade;
                        satis.Tarih = DateTime.Now;
                        satis.Kullanici = lblKullanici.Text;
                        context.Satis.Add(satis);
                       

                    }
                    context.SaveChanges(); //buradaki hatada kaldım...
                    MessageBox.Show("yapıldı");
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                
            }


        }

        #endregion
        private void Numaratorx_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == ",")
            {
                int virgul = tNumarator.Text.Count(p => p == ',');
                if (virgul < 1)
                {
                    tNumarator.Text += btn.Text;
                }
            }
            else if (btn.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);
                }
            }
            else
            {
                tNumarator.Text += btn.Text;
            }
        }

        private void HizliButtonClick(object sender, EventArgs e) //hızlı butona basılınca yapılaacak işlemler ortak hepsi birlikte
        {
            Button btn = (Button)sender; //butona çeviriyorum 
            int butonid = Convert.ToInt32(btn.Name.ToString().Substring(2, btn.Name.Length - 2));//burada butonların başlarındaki 2 harfi almıyorum sadece elimde buton no gibi numara değerşleri kalıyor...
            if (btn.Text.ToString().StartsWith("-"))
            {
                HizliButonUrunEkle hizliButonUrunEkle = new HizliButonUrunEkle();
                hizliButonUrunEkle.lbutonid.Text = butonid.ToString();
                hizliButonUrunEkle.ShowDialog();
            }
            else
            {

                var urunbarkod = context.HizliUrunler.Where(p => p.Id == butonid).Select(p => p.Barkod).FirstOrDefault();//burada ide si barkodid nosuna eşit olanı getir dedik ama select yaparak ne istediysek sadece onu aldık...
                var urun = context.Urun.Where(p => p.Barkod == urunbarkod).FirstOrDefault();
                UrunGetir(urun, urunbarkod, Convert.ToDouble(tMiktar.Text));
                GenelToplam();

            }

        }
        private void ParaUstuHesapla_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            double sonuc = Islemler.DoubleYap(btn.Text) - Islemler.DoubleYap(tGenelToplam.Text);
            txtparaustu.Text = sonuc.ToString("C2");
        }

       

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void bAdet_Click(object sender, EventArgs e)
        {
            if(tNumarator.Text != "")
            {
                tMiktar.Text =tNumarator.Text;
                tNumarator.Clear();
                tBarkod.Clear();
                tBarkod.Focus();

            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if(tNumarator.Text != "")
            {
                double sonuc =Islemler.DoubleYap(tNumarator.Text) - Islemler.DoubleYap(tGenelToplam.Text);
                txtparaustu.Text =sonuc.ToString("C2");
                tNumarator.Clear();
                tBarkod.Focus();
              
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void bBarkod_Click(object sender, EventArgs e)
        {
            if(tNumarator.Text != "")
            {
                if(context.Urun.Any(p=>p.Barkod == tNumarator.Text))
                {
                    var urun = context.Urun.Where(p=>p.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunGetir(urun,tNumarator.Text,Convert.ToDouble(tMiktar.Text));
                    tNumarator.Clear();
                    tBarkod.Focus();
                }
                else
                {
                    MessageBox.Show("ürün ekleme sayfası");
                }
            }
        }

        private void btnDiger_Click(object sender, EventArgs e)
        {
            if(tNumarator.Text != (""))
            {
                int satirsayisi = gridSatislistesi.Rows.Count;
                gridSatislistesi.Rows.Add();
                gridSatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = "111111111116";
                gridSatislistesi.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                gridSatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridSatislistesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridSatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridSatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridSatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                GenelToplam();
                tBarkod.Focus();
            }
        }

        private void btniade_Click(object sender, EventArgs e)
        {
            if(chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Checked = false;
                chSatisIadeIslemi.Text = "Satış Yapılıyor";
            }
            else
            {
                chSatisIadeIslemi.Checked = true;
                chSatisIadeIslemi.Text = "İade Yapılıyor";

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void bNakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");
        }
    }


}

