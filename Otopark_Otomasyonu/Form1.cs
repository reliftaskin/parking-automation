using MongoDB.Driver.Core.Configuration;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=RUM-PC;Initial Catalog=arac_otopark;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            frm_arac_kaydı Kayıt = new frm_arac_kaydı();
            Kayıt.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_arac_yerleri Yer = new frm_arac_yerleri (); 
            Yer.ShowDialog();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_arac_cikis  Çıkış=new frm_arac_cikis(); 
            Çıkış.ShowDialog(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
