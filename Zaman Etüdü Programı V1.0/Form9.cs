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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void pROJEKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }

        private void aKIŞŞEMASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }

        private void gÖRÜNTÜİŞLEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dEĞERLENDİRMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.Show();
        }

        private void sONUÇLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            this.Hide();
            f11.Show();
        }
        OleDbConnection baglanti3 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = görüntüisleme.mdb");
        private void button6_Click(object sender, EventArgs e)
        {
            baglanti3.Open();
            OleDbCommand komut3 = new OleDbCommand("insert into Tablo1 ([projekodu],[projeadı],[faaliyet],[operatör],[başlangıçzamanı],[bitişzamanı],[saatfark],[dakikafark],[saniyefark],[saniyetoplam],[normalzaman]) values ('" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + baslangiczaman + "','" + bitiszaman + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + hesap + "','" + normzaman + "')", baglanti3);
            komut3.ExecuteNonQuery();
            baglanti3.Close();
            MessageBox.Show("Sisteme kayıt başarılı!");

            listBox1.Items.Add(comboBox4.Text + "\t" + comboBox1.Text + "\t" + comboBox2.Text + "\t" + comboBox3.Text + "\t" + baslangiczaman + "\t" + bitiszaman + "\t" + textBox3.Text + "\t" + textBox4.Text + "\t" + textBox5.Text);

            comboBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            textBox3.Clear();
            textBox4.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox4.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            textBox3.Clear();
            textBox4.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox4.Focus();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = akissemasi.mdb");
        OleDbConnection baglanti2 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = projekayit.mdb");
        private void Form9_Load(object sender, EventArgs e)
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

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
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


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        double zamanhesabi = 0;
        double hesap = 0, saatfark, dakikafark, saniyefark, sayac, toplamsonuc, normzaman;
        string baslangiczaman, bitiszaman;
        private void button1_Click(object sender, EventArgs e)
        {
            string st1 = Convert.ToString(comboBox5.Text);
            string dk1 = Convert.ToString(comboBox6.Text);
            string sn1 = Convert.ToString(comboBox7.Text);
            string st2 = Convert.ToString(comboBox10.Text);
            string dk2 = Convert.ToString(comboBox9.Text);
            string sn2 = Convert.ToString(comboBox8.Text);

            baslangiczaman = st1 + ":" + dk1 + ":" + sn1;
            bitiszaman = st2 + ":" + dk2 + ":" + sn2;
            
            double saat1 = Convert.ToDouble(comboBox5.Text);
            double dak1 = Convert.ToDouble(comboBox6.Text);
            double san1 = Convert.ToDouble(comboBox7.Text);

            double saat2 = Convert.ToDouble(comboBox10.Text);
            double dak2 = Convert.ToDouble(comboBox9.Text);
            double san2 = Convert.ToDouble(comboBox8.Text);

            if (saat1>=saat2)
            {
                saatfark = saat1 - saat2;
            }
            else 
            {
                saatfark = saat2 - saat1;
            }

            if (dak1>=dak2)
            {
                dakikafark = dak1 - dak2;
            }
            else
            {
                dakikafark = dak2 - dak1;
            }

            if (san1>=san2)
            {
                saniyefark = san1 - san2;
            }
            else
            {
                saniyefark = san2 - san1;
            }

            hesap = (saatfark * 3600) + (dakikafark * 60) + saniyefark;
            sayac = sayac + 1;

            toplamsonuc = toplamsonuc + hesap;

            normzaman = toplamsonuc / sayac;

            textBox3.Text = saatfark.ToString();
            textBox4.Text = dakikafark.ToString();
            textBox5.Text = saniyefark.ToString();
        }
    }
}
