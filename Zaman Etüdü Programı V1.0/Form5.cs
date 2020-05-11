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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void sONUÇLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
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

        private void gÖRÜNTÜİŞLEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
        OleDbConnection b1 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = projekayit.mdb");
        OleDbConnection b2 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = akissemasi.mdb");
        private void Form5_Load(object sender, EventArgs e)
        {
            b1.Open();
            OleDbDataReader oku;
            OleDbCommand komut = new OleDbCommand("select * from tablo1", b1);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["projekodu"]);
                comboBox2.Items.Add(oku["projeadı"]);
            }
            b1.Close();

            b2.Open();
            OleDbDataReader oku2;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", b2);
            oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox3.Items.Add(oku2["faaliyet"]);
                comboBox4.Items.Add(oku2["operatörismi"]);
            }
            b2.Close();
        }
        OleDbConnection b3 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = görüntüisleme.mdb");
        OleDbConnection b4 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = degerlendirme.mdb");

        double sonuc,eleman = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            //TOPLAM SANİYE
            b3.Open();
            OleDbDataReader oku3;
            OleDbCommand komut3 = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox2.Text + "'and projekodu='" + comboBox1.Text + "'and operatör='" + comboBox4.Text + "'", b3);
            oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                listBox1.Items.Add(oku3["saniyetoplam"]);
                
            }
            b3.Close();

            //ORT. ZAMAN
            b3.Open();
            OleDbDataReader oku4;
            OleDbCommand komut4 = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox2.Text + "'and projekodu='" + comboBox1.Text + "'and operatör='" + comboBox4.Text + "'", b3);
            oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                listBox2.Items.Add(oku4["normalzaman"]);

            }
            b3.Close();

            //WhestingH-PayMiktarı-TempolamaHızı
            b4.Open();
            OleDbDataReader oku5;
            OleDbCommand komut5 = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox2.Text + "'and projekodu='" + comboBox1.Text + "'and operatör='" + comboBox4.Text + "'", b4);
            oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                listBox3.Items.Add(oku5["whesting"]);
                listBox4.Items.Add(oku5["tempolama"]);
                listBox5.Items.Add(oku5["paymiktarı"]);

            }
            b4.Close();

            //Normal Zaman
            b4.Open();
            OleDbDataReader oku6;
            OleDbCommand komut6 = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox2.Text + "'and projekodu='" + comboBox1.Text + "'and operatör='" + comboBox4.Text + "'", b4);
            oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                listBox6.Items.Add(oku6["nrmlzaman"]);

            }
            b4.Close();

            //Standart Zaman
            b4.Open();
            OleDbDataReader oku7;
            OleDbCommand komut7 = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox2.Text + "'and projekodu='" + comboBox1.Text + "'and operatör='" + comboBox4.Text + "'", b4);
            oku6 = komut7.ExecuteReader();
            while (oku6.Read())
            {
                listBox7.Items.Add(oku6["stdzaman"]);

            }
            b4.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

            comboBox1.Focus();
        }
    }
}
