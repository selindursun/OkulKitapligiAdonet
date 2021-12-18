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
            try
            {
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
                    BaglantiyiKapat();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA: " + ex.Message); ;
            }
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

                MessageBox.Show("HATA: "+ex.Message);
            }
        }

        private void FormYazarlar_Load(object sender, EventArgs e)
        {

        }
    }
}
