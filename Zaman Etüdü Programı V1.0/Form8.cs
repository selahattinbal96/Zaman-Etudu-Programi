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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void pROJEKAYITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
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
        OleDbConnection baglanti2 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = projekayit.mdb");
        private void Form8_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataReader oku;
            OleDbCommand komut1 = new OleDbCommand("select * from tablo1", baglanti);
            oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                listBox2.Items.Add(oku[0].ToString() + "\t" + oku[1].ToString() + "\t" + oku[2].ToString() + "\t" + oku[3].ToString() + "\t" + oku[4].ToString() + "\t" + oku[5].ToString());
            }
            baglanti.Close();

            comboBox2.Items.Clear();
            baglanti2.Open();
            OleDbDataReader oku1;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", baglanti2);
            oku1 = komut2.ExecuteReader();
            while (oku1.Read())
            {
                comboBox2.Items.Add(oku1["projekodu"]);
            }
            baglanti.Close();

            textBox5.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "İŞLEM")
            {
                pictureBox1.Image = Image.FromFile(@"Resources\\işlem.png");
            }
            if (comboBox1.Text == "TAŞIMA")
            {
                pictureBox1.Image = Image.FromFile(@"Resources\\taşıma.png");
            }
            if (comboBox1.Text == "MUAYENE")
            {
                pictureBox1.Image = Image.FromFile(@"Resources\\muayene.png");
            }
            if (comboBox1.Text == "GECİKME")
            {
                pictureBox1.Image = Image.FromFile(@"Resources\\gecikme.png");
            }
            if (comboBox1.Text == "DEPOLAMA")
            {
                pictureBox1.Image = Image.FromFile(@"Resources\\depolama.png");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static int toplam = 1;
        public static int x = 0;
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = akissemasi.mdb");
        private void button1_Click(object sender, EventArgs e)
        {

            x = Convert.ToInt32(comboBox3.Text);

            if (toplam <= x)
            {
                MessageBox.Show("combobox değeri" + x + "toplam değeri:" + toplam);
                baglanti.Open();
                string toplamm = toplam.ToString();
                OleDbCommand komut2 = new OleDbCommand("insert into Tablo1 ([islemnumarasi],[projekodu],[faaliyet],[operatörismi],[islem],[islemsayısıadedi],[açıklama],[digersecenekler]) values ('" + toplamm + "','" + comboBox2.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + digersecenek + "')", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                listBox1.Items.Add(toplamm + "\t" + comboBox2.Text + "\t" + textBox1.Text + "\t" + textBox2.Text + "\t" + comboBox1.Text + "\t" + comboBox3.Text + "\t" + textBox4.Text + "\t" + digersecenek);
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox1.Focus();
                comboBox3.Enabled = false;
                toplam = toplam + 1;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            baglanti.Open();
            OleDbDataReader oku;
            OleDbCommand komut1 = new OleDbCommand("select * from tablo1", baglanti);
            oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                listBox2.Items.Add(oku[0].ToString() + "\t" + oku[1].ToString() + "\t" + oku[2].ToString() + "\t" + oku[3].ToString() + "\t" + oku[4].ToString() + "\t" + oku[5].ToString() + "\t" + oku[6].ToString());
            }
            baglanti.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
        string digersecenek;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true && checkBox2.Checked==false && checkBox3.Checked==false && checkBox4.Checked==false && checkBox5.Checked==false)
            {
                digersecenek = "Çıkartılabilir işlem!";
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                digersecenek = "Tamamen İptaledilebilir işlem!";
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                digersecenek = "Süresi Arttırılabilir işlem!";
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == false)
            {
                digersecenek = "Yöntem Değiştirilebilir işlem!";
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox5.Enabled = false;
                textBox5.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                digersecenek = textBox5.Text;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                textBox5.Enabled = true;
            }
        }
    }
}
