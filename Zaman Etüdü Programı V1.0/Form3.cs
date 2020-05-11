using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Zaman_Etüdü_Programı_V1._0
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pROJEKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void aKIŞŞEMASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void dEĞERLENDİRMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void sONUÇLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = akissemasi.mdb");
        OleDbConnection baglanti2 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = projekayit.mdb");
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox1.Items.Clear();
            baglanti2.Open();
            OleDbDataReader oku1;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", baglanti2);
            oku1 = komut2.ExecuteReader();
            while (oku1.Read())
            {
                comboBox4.Items.Add(oku1["projekodu"]);
                comboBox1.Items.Add(oku1["projeadı"]);
            }
            baglanti2.Close();

            baglanti.Open();
            OleDbDataReader oku;
            OleDbCommand komut = new OleDbCommand("select * from tablo1", baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["faaliyet"]);
                comboBox3.Items.Add(oku["operatörismi"]);
            }
            baglanti.Close();

            MessageBox.Show("Hesapla komutu ardından lütfen kaydet düğmesine basın!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            axWindowsMediaPlayer1.URL = dosyayolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        string startTime;
        string stopTime;
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 3)
            {
                startTime = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                textBox1.Text = startTime;
                int bas = textBox1.Text.Length;
                if (bas == 5)
                {
                    textBox1.Text = "00:" + startTime;
                }
            }

            if (e.newState == 2)
            {
                
                stopTime = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                textBox2.Text = stopTime;
                int bas2 = textBox2.Text.Length;
                if (bas2 == 5)
                {
                    textBox2.Text = "00:" + stopTime;
                }
            }
        }

        double toplamson = 0;
        int sayac = 0;
        string sonucc;
        double normzaman = 0;

        public static string d1, d2, d3;

        double sonuclar = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            TimeSpan fark = Convert.ToDateTime(textBox2.Text) - Convert.ToDateTime(textBox1.Text);
            textBox3.Text = fark.Hours.ToString();
            textBox4.Text = fark.Minutes.ToString();
            textBox5.Text = fark.Seconds.ToString();    

            d1 = textBox3.Text;
            d2 = textBox4.Text;
            d3 = textBox5.Text;

            double a1 = Convert.ToDouble(textBox3.Text);
            double a2 = Convert.ToDouble(textBox4.Text);
            double a3 = Convert.ToDouble(textBox5.Text);

            double son1 = a1 * 3600;
            double son2 = a2 * 60;

            sonuclar = son1 + son2 + a3;
            sayac = sayac + 1;
            
            toplamson = toplamson + sonuclar;

            normzaman = toplamson / sayac;

            sonucc = Convert.ToString(sonuclar);
            MessageBox.Show("Sonuçlar=" + sonucc);
            MessageBox.Show("Toplam Saniye=" + toplamson);
            MessageBox.Show("Normal Zaman= "+normzaman);
            MessageBox.Show("İşlem Adedi=" + sayac);

            listBox1.Items.Add(comboBox4.Text + "\t" + comboBox1.Text + "\t" + comboBox2.Text + "\t" + comboBox3.Text + "\t" + textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + textBox4.Text + "\t" + textBox5.Text);
        }
        OleDbConnection baglanti3 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = görüntüisleme.mdb");
        
        private void button6_Click(object sender, EventArgs e)
        {
            
            baglanti3.Open();
            OleDbCommand komut3 = new OleDbCommand("insert into Tablo1 ([projekodu],[projeadı],[faaliyet],[operatör],[başlangıçzamanı],[bitişzamanı],[saatfark],[dakikafark],[saniyefark],[saniyetoplam],[normalzaman]) values ('" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + toplamson + "','" + normzaman + "')", baglanti3);
            komut3.ExecuteNonQuery();
            baglanti3.Close();
            MessageBox.Show("Sisteme Kayıt Başarılı!");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
