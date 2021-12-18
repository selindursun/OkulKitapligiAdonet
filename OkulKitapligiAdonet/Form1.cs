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

namespace OkulKitapligiAdonet
{
    public partial class FormYazarlar : Form
    {
        public FormYazarlar()
        {
            InitializeComponent();
        }
        //SqlConnection:Sql veritabanına bağlantı için kullanılır.
        String SqlBaglantiCumlesi = @"Server=DESKTOP-2JRJO3S;Database=OKULKITAPLIGI;Trusted_Connection=True;";
        SqlConnection baglanti = new SqlConnection();


        private void btnEkle_Click(object sender, EventArgs e)
        {
            switch (btnEkle.Text)
            {
                case "EKLE":
                    try
                    {
                        //txtYazar'ın içi boşsa
                        if (string.IsNullOrEmpty(txtYazar.Text))
                        {
                            MessageBox.Show("Lütfen yazar bilgisini girin.");
                        }
                        else
                        {
                            //ekleme yapaacağız
                            string insertCumlesi = $"insert into Yazarlar (KayitTarihi, YazarAdSoyad,SilindiMi) values (getdate(),'{txtYazar.Text.Trim()}',0)";
                            SqlCommand insertkomut = new SqlCommand(insertCumlesi, baglanti);
                            BaglantiyiAc();
                            insertkomut.ExecuteNonQuery();
                            MessageBox.Show("Yazar eklendi.");
                            TumYazarlariGetir();
                            BaglantiyiKapat();

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("HATA: " + ex.Message); ;
                    }
                    Temizle();
                    break;
                case "GÜNCELLE":
                    try
                    {
                        if (!string.IsNullOrEmpty(txtYazar.Text))
                        {
                            using (baglanti)
                            {
                                DataGridViewRow satir = dataGridViewYazarlar.SelectedRows[0];
                                int YazarId = Convert.ToInt32(satir.Cells["YazarId"].Value);
                                String updateSorguCumlesi = $"Update Yazarlar Set YazarAdSoyad='{txtYazar.Text.Trim()}' where YazarId={YazarId}";
                                SqlCommand updateCommand = new SqlCommand(updateSorguCumlesi, baglanti);
                                BaglantiyiAc();
                                updateCommand.ExecuteNonQuery();
                                MessageBox.Show("Yazar Güncellendi");
                                TumYazarlariGetir();
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Güncelleme sırasında hata oluştu", "UYARI: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    Temizle();
                    break;
                default:
                    break;

            }


        }

        private void Temizle()
        {
            btnEkle.Text = "EKLE";
            txtYazar.Clear();
        }

        private void BaglantiyiAc()
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.ConnectionString = SqlBaglantiCumlesi;
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA:" + ex.Message); ;
            }
        }
        private void BaglantiyiKapat()
        {
            try
            {
                if (baglanti.State != ConnectionState.Closed)
                {
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA: " + ex.Message);
            }
        }
        private void TumYazarlariGetir()
        {
            try
            {
                //SqlCommand: Sorgularımızı ve prosedürlerimize air komutları alan nesnedir.
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;
                string sorgu = "Select * from Yazarlar where SilindiMi=0 order by YazarId desc";
                komut.CommandText = sorgu;
                BaglantiyiAc();
                //DataSQLADAPTER nesnesi, sorgu çalışınca oluşan dataların aktarılması işlemini yapar. 
                SqlDataAdapter adaptor = new SqlDataAdapter(komut);
                //Adaptorun içindeki verileri sanalTabloya alıyoruz.
                DataTable sanalTablo = new DataTable();
                adaptor.Fill(sanalTablo);
                dataGridViewYazarlar.DataSource = sanalTablo;
                dataGridViewYazarlar.Columns["SilindiMi"].Visible = false;
                dataGridViewYazarlar.Columns["YazarAdSoyad"].Width = 220;
                dataGridViewYazarlar.Columns["KayitTarihi"].Width = 150;
                BaglantiyiKapat();



            }
            catch (Exception ex)
            {

                MessageBox.Show($"Beklenmedik bir hata oluştu! HATA: {ex.Message}",
                     "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormYazarlar_Load(object sender, EventArgs e)
        {
            //DataGridView'e sağ tıklanınca gelecek olan contextmenustrşp ataması aşağıda yapıldı
            dataGridViewYazarlar.ContextMenuStrip = contextMenuStrip1;
            //Çoklu satır seçimi aşağıda engellendi.
            dataGridViewYazarlar.MultiSelect = false;
            //Bir hücreye tıklandığında satırı tamamen seçme işlemi aşağıda yapıldı.
            dataGridViewYazarlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TumYazarlariGetir();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Seçili satır varsa
            if (dataGridViewYazarlar.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dataGridViewYazarlar.SelectedRows[0];
                String yazarAdSoyad = Convert.ToString(satir.Cells["YazarAdSoyad"].Value);
                btnEkle.Text = "GÜNCELLE";
                txtYazar.Text = yazarAdSoyad;
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi için tablodan bir yazar seçmelisiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilenSatir = dataGridViewYazarlar.SelectedRows[0];
            int yazarId = (int)secilenSatir.Cells["YazarId"].Value;
            string secilenYazar = Convert.ToString(secilenSatir.Cells["YazarAdSoyad"].Value);
            //Yazarın kitabı varsa Kitaplar tablosunda yazarId foregin key dir.BU yüzden yazarı silmemize izin vermez.Önce yazarın kitaplarını silmemiz gerekir.
            SqlCommand komut = new SqlCommand($"select*from Kitaplar where YazarId={yazarId}", baglanti);

            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataTable sanalTablo = new DataTable();
            BaglantiyiAc();
            adaptor.Fill(sanalTablo);
            if (sanalTablo.Rows.Count > 0)
            {
                MessageBox.Show($"{secilenYazar} isimle yazarın Kitaplar tablosunda {sanalTablo.Rows.Count.ToString()} adet kitabı bulunmaktadır. Bu yazarı silmek istiyorsanız önce kitaplarını silmelisiniz.");
            }
            else
            {
                //Kitabı yok.Bu yüzden Foreign key patlaması yaşanmaz silebiliriz.
                //Emin mi diye tekrar soralım. DialogResult ile.
                DialogResult cevap = MessageBox.Show($"{secilenYazar} adlı yazarı silmek istediğinizden emin misiniz?", "ONAY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    //silme işlemini yap
                    SqlCommand deletekomut = new SqlCommand($"delete from Yazarlar where YazarId={yazarId}", baglanti);
                    BaglantiyiAc();
                    deletekomut.ExecuteNonQuery();
                    MessageBox.Show("Yazar silindi");
                    TumYazarlariGetir();
                }

            }


        }
        private void silpasifeÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Kullanıcı yazarın silindiğini zannedecek fakat biz pasife çekeceğiz.
            try
            {
                using (baglanti)
                {
                    DataGridViewRow secilenSatir = dataGridViewYazarlar.SelectedRows[0];
                    int SecilenyazarId = (int)secilenSatir.Cells["YazarId"].Value;
                    string SecilenYazar = Convert.ToString(secilenSatir.Cells["YazarAdSoyad"].Value);
                    SqlCommand updateCommand = new SqlCommand($"Update Yazarlar Set SilindiMi=1 where YazarId={SecilenyazarId}", baglanti);
                    BaglantiyiAc();
                    int sonuc = updateCommand.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Pasife çek gerçekleşti.");
                        TumYazarlariGetir();
                    }
                    else
                    {
                        MessageBox.Show("hata:");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pasife çek silme işleminde hata: " + ex.Message);

            }



        }

        private void silbaşkaBirYöntemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Bu yöntem yukarıdakiler gibi kullanışlı değildir.
            try
            {

                DataGridViewRow secilenSatir = dataGridViewYazarlar.SelectedRows[0];
                int yazarId = (int)secilenSatir.Cells["YazarId"].Value;
                string yazar = Convert.ToString(secilenSatir.Cells["YazarAdSoyad"].Value);
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                DialogResult cevap = MessageBox.Show($"{yazar} adlı yazarı silmek istediğinize emin misiniz?", "ONAY", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    komut.CommandText = $"Delete from Yazarlar where YazarId=@yzrid";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@yzrid", yazarId);
                    BaglantiyiAc();
                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Silindi");
                        TumYazarlariGetir();
                    }
                    else
                    {
                        MessageBox.Show("HATA:Silinemedi!");
                        BaglantiyiKapat();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA: " + ex.Message);
            }
        }
    }
}
