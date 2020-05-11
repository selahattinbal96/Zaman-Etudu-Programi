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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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

        private void Form7_Load(object sender, EventArgs e)
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

        private void aKIŞŞEMASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            this.Hide();
            f8.Show();
        }

        private void gÖRÜNTÜİŞLEMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
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

        private void pROJEKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
