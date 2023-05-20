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

namespace Otopark_Otomasyonu
{
    public partial class frm_arac_kaydı : Form
    {
        public frm_arac_kaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=RUM-PC;Initial Catalog=arac_otopark;Integrated Security=True");

       
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_arac_kaydı_Load(object sender, EventArgs e)
        {
            BoşAraçlar();
        }

        private void BoşAraçlar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from arac_durumu WHERE durumu= 'BOŞ'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboParkYeri.Items.Add(read["parkyeri"].ToString());
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into arac_otopark_kaydı(TC,Ad,Soyad,Telefon,Plaka,ParkYeri,Tarih) values(@TC,@Ad,@Soyad,@Telefon,@Plaka,@ParkYeri,@Tarih) ", baglanti );
            komut.Parameters.AddWithValue("TC", txtTc.Text);
            komut.Parameters.AddWithValue("Ad", txtAd.Text);
            komut.Parameters.AddWithValue("Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("Telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("Plaka", txtPlaka.Text);
            komut.Parameters.AddWithValue("ParkYeri", comboParkYeri.Text);
            komut.Parameters.AddWithValue("Tarih", DateTime.Now.ToString());

            komut.ExecuteNonQuery();
            //SqlCommand komut2 = new SqlCommand("update arac_durumu set durumu = 'DOLU' where parkyeri = '" + comboParkYeri.SelectedItem + "'", baglanti);
            if (comboParkYeri.SelectedItem != null)
            {
                string parkYeri = comboParkYeri.SelectedItem.ToString();
                SqlCommand komut2 = new SqlCommand("update arac_durumu set durumu='DOLU' where parkyeri=@parkYeri", baglanti);
                komut2.Parameters.AddWithValue("@parkYeri", parkYeri);
                komut2.ExecuteNonQuery();
            }
            
            baglanti.Close();
            MessageBox.Show("Araç Kaydı Oluşturuldu", "Kaydet");
            comboParkYeri.Items.Clear();
            BoşAraçlar();
            foreach (Control item in grupKişi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }


    }
}
