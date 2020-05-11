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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti3 = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;data source=sistemkayit.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti3.Open();
            OleDbDataReader oku;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1 where kullaniciadi='"+textBox1.Text+"' and parola='"+textBox2.Text+"'", baglanti3);
            oku = komut2.ExecuteReader();
            
            while (oku.Read())
            {
               
                MessageBox.Show("Başarılı");
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;
                goto a;

            }
            baglanti3.Close();
            MessageBox.Show("Tekrar deneyiniz!");
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            a:
            textBox1.Focus();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            MessageBox.Show("Sistemden Çıktınız!");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
