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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=projekayit.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("insert into Tablo1 ([projekodu],[projeadı],[projenumarası],[projesorumlusu],[projekayıtalankisi],[projetarihi]) values ('" + textBox5.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            listBox1.Items.Add(textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + textBox4.Text + "\t" + dateTimePicker1.Text);
            MessageBox.Show("Kayıt Başarılı!");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataReader oku;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", baglanti);
            oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                listBox2.Items.Add(oku[0].ToString() + "\t" + oku[1].ToString() + "\t" + oku[2].ToString() + "\t" + oku[3].ToString() + "\t" + oku[4].ToString() + "\t" + oku[5].ToString());
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            baglanti.Open();
            OleDbDataReader oku;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", baglanti);
            oku = komut2.ExecuteReader();
            while (oku.Read())
            {
                listBox2.Items.Add(oku[0].ToString() + "\t" + oku[1].ToString() + "\t" + oku[2].ToString() + "\t" + oku[3].ToString() + "\t" + oku[4].ToString() + "\t" + oku[5].ToString());
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
