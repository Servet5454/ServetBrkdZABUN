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
    public partial class HizliButonUrunEkle : Form
    {
        Database1Entities context = new Database1Entities();
        public HizliButonUrunEkle()
        {
            InitializeComponent();
        }

        private void tUrunBul_TextChanged(object sender, EventArgs e)
        {
            if (tUrunBul.Text != "")
            {
                string urunadi = tUrunBul.Text;
                var urunler = context.Urun.Where(p => p.UrunAd.Contains(urunadi)).ToList();// contains olayı dinamik olarak ürünleri getirdi bunu e ticarette kullanacağım...
                gridhizliurun.DataSource = urunler;
            }
        }

        private void gridhizliurun_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)//mousa çift tıklayınca yapılacak olan işlemler
        { //hızlı buton güncelleme
            if (gridhizliurun.Rows.Count > 0)
            {

                //datagridden lazım olan bilgileri burada topluyoruz...
                string barkod = gridhizliurun.CurrentRow.Cells["Barkod"].Value.ToString();
                if (barkod.Length > 20) // burada sürekli validation hatası aldım 20 haneyi geçmesede hata verdi bunu çözmek için bu yöntemi denedim ve çözdüm :)
                {
                    barkod = barkod.Substring(0, 20); // Barkod değerini 20 karaktere kısaltma
                }
                string urunadi = gridhizliurun.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble(gridhizliurun.CurrentRow.Cells["SatisFiyat"].Value);
                int urunid = Convert.ToInt32(lbutonid.Text);

                //data gridden aldığımız bilgileri hhızlıurunler tablosuna butonid sine göre basıyoruz...
                var guncellenecekurun = context.HizliUrunler.Find(urunid);
                guncellenecekurun.Barkod = barkod;
                guncellenecekurun.UrunAdi = urunadi;
                guncellenecekurun.Fiyat = fiyat;             

                context.SaveChanges();
                MessageBox.Show("Güncelleme İşlemi Başarılı Bir Şekilde Yapılmıştır.");
                SatisAnaEkran anaekran = (SatisAnaEkran)Application.OpenForms["SatisAnaEkran"];
                if(anaekran != null)
                {
                    Button btn = anaekran.Controls.Find("bH" + urunid, true).FirstOrDefault() as Button;
                    btn.Text = urunadi + "\n" + fiyat.ToString("C2");
                    
                }
            }
        }

        private void chtumu_CheckedChanged(object sender, EventArgs e) //check box ta değişiklik olursa burası yapılacak
        {
            if(chtumu.Checked) //işaretliyse burası yapılacak
            {
                gridhizliurun.DataSource = context.Urun.ToList();
            }
            else
            {
                gridhizliurun.DataSource=null;
            }
        }
    }
}
