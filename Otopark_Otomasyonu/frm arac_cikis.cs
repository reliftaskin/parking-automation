using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otopark_Otomasyonu
{
    public partial class frm_arac_cikis : Form
    {
        public frm_arac_cikis()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=RUM-PC;Initial Catalog=arac_otopark;Integrated Security=True");


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frm_arac_cikis_Load(object sender, EventArgs e)
        {
            DoluYerler();
            Plakalar();
            timer1.Enabled = true;
        }

        private void Plakalar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from arac_otopark_kaydı", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboPlaka.Items.Add(read["Plaka"].ToString());
            }
            baglanti.Close();
        }

        private void DoluYerler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from arac_durumu where durumu ='DOLU'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboParkYeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void comboPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from arac_otopark_kaydı where Plaka='"+comboPlaka.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri.Text = read["ParkYeri"].ToString();
            }
            baglanti.Close();
        }

        private void comboParkYeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from arac_otopark_kaydı where ParkYeri='" + comboParkYeri.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri2.Text = read["ParkYeri"].ToString();
                txtTc.Text = read["TC"].ToString();
                txtAd.Text = read["Ad"].ToString();
                txtSoyad.Text = read["Soyad"].ToString();
                label12.Text= read["Tarih"].ToString();
                txtPlaka.Text = read["Plaka"].ToString();
            }
            baglanti.Close();
            DateTime geliş, çıkış;
            geliş = DateTime.Parse(label12.Text);
            çıkış = DateTime.Parse(label13.Text);
            TimeSpan fark = çıkış - geliş;
            label14.Text = fark.TotalHours.ToString("0.00");
            label15.Text = (double.Parse(label14.Text) * (10)).ToString("0.00");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text=DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from arac_otopark_kaydı where plaka='" + txtPlaka.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update arac_durumu set durumu = 'BOŞ' where parkyeri = '" + txtParkYeri2.Text + "'", baglanti);
            komut2.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("Araç Çıkışı Yapıldı");
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    txtParkYeri.Text = "";
                    comboParkYeri.Text= "";
                    comboPlaka.Text= "";

                }
            }
            comboPlaka.Items.Clear();
            comboParkYeri.Items.Clear();
            DoluYerler();
            Plakalar();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
