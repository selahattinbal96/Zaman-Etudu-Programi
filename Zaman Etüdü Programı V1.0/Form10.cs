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
    public partial class Form10 : Form
    {
        public Form10()
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
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }

        private void dEĞERLENDİRMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sONUÇLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            this.Hide();
            f11.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox17.Enabled = false;
        }
        string a;
        double normzamn = 0;
        OleDbConnection b3 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = görüntüisleme.mdb");
        private void button6_Click(object sender, EventArgs e)
        {
            double son = topla + 1;

            b3.Open();
            OleDbDataReader oku1;
            OleDbCommand komut = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox1.Text + "'and projekodu='" + comboBox4.Text + "'and operatör='" + comboBox2.Text + "'", b3);
            oku1 = komut.ExecuteReader();
            while (oku1.Read())
            {
                a = Convert.ToString(oku1["normalzaman"]);
            }
            double hes = Convert.ToDouble(a);
            normzamn = hes * son;


            MessageBox.Show("Sonuç:  " + son);
            MessageBox.Show("Normal Zaman=" + normzamn.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox17.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox6.Enabled = true;
        }
        OleDbConnection b1 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = projekayit.mdb");
        OleDbConnection b2 = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = akissemasi.mdb");
        private void Form10_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox6.Enabled = false;
            groupBox17.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            b1.Open();
            OleDbDataReader oku;
            OleDbCommand komut = new OleDbCommand("select * from tablo1", b1);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox4.Items.Add(oku["projekodu"]);
                comboBox1.Items.Add(oku["projeadı"]);
            }
            b1.Close();

            b2.Open();
            OleDbDataReader oku2;
            OleDbCommand komut2 = new OleDbCommand("select * from tablo1", b2);
            oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["operatörismi"]);
                comboBox3.Items.Add(oku2["faaliyet"]);
            }
            b2.Close();
        }
        //KişiselGereksinimler
        //Erkek
        double topla2 = 0;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                double s2 = 0.02;
                topla2 = topla2 + s2;
                MessageBox.Show("0.02");
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
            }
            if (radioButton1.Checked == false)
            {
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == true && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                double s2 = 0.03;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton1.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
            }
            if (radioButton2.Checked == false)
            {
                radioButton1.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == true && radioButton4.Checked == false)
            {
                double s2 = 0.04;
                topla2 = topla2 + s2;
                MessageBox.Show("0.04");
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton4.Enabled = false;
            }
            if (radioButton3.Checked == false)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton4.Enabled = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == true)
            {
                double s2 = 0.05;
                topla2 = topla2 + s2;
                MessageBox.Show("0.05");
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
            if (radioButton4.Checked == false)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true && radioButton7.Checked == false && radioButton6.Checked == false && radioButton5.Checked == false && radioButton10.Checked == false && radioButton9.Checked == false)
            {
                double s2 = 0.02;
                topla2 = topla2 + s2;
                MessageBox.Show("0.02");
                radioButton7.Enabled = false;
                radioButton6.Enabled = false;
                radioButton5.Enabled = false;
                radioButton10.Enabled = false;
                radioButton9.Enabled = false;
            }
            if (radioButton8.Checked == false)
            {
                radioButton7.Enabled = true;
                radioButton6.Enabled = true;
                radioButton5.Enabled = true;
                radioButton10.Enabled = true;
                radioButton9.Enabled = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == false && radioButton7.Checked == true && radioButton6.Checked == false && radioButton5.Checked == false && radioButton10.Checked == false && radioButton9.Checked == false)
            {
                double s2 = 0.02;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton8.Enabled = false;
                radioButton6.Enabled = false;
                radioButton5.Enabled = false;
                radioButton10.Enabled = false;
                radioButton9.Enabled = false;
            }
            if (radioButton7.Checked == false)
            {
                radioButton8.Enabled = true;
                radioButton6.Enabled = true;
                radioButton5.Enabled = true;
                radioButton10.Enabled = true;
                radioButton9.Enabled = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == false && radioButton7.Checked == false && radioButton6.Checked == true && radioButton5.Checked == false && radioButton10.Checked == false && radioButton9.Checked == false)
            {
                double s2 = 0.04;
                topla2 = topla2 + s2;
                MessageBox.Show("0.04");
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;
                radioButton5.Enabled = false;
                radioButton10.Enabled = false;
                radioButton9.Enabled = false;
            }
            if (radioButton6.Checked == false)
            {
                radioButton8.Enabled = true;
                radioButton7.Enabled = true;
                radioButton5.Enabled = true;
                radioButton10.Enabled = true;
                radioButton9.Enabled = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == false && radioButton7.Checked == false && radioButton6.Checked == false && radioButton5.Checked == true && radioButton10.Checked == false && radioButton9.Checked == false)
            {
                double s2 = 0.04;
                topla2 = topla2 + s2;
                MessageBox.Show("0.04");
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;
                radioButton5.Enabled = false;
                radioButton10.Enabled = false;
                radioButton9.Enabled = false;
            }
            if (radioButton6.Checked == false)
            {
                radioButton8.Enabled = true;
                radioButton7.Enabled = true;
                radioButton5.Enabled = true;
                radioButton10.Enabled = true;
                radioButton9.Enabled = true;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == false && radioButton7.Checked == false && radioButton6.Checked == false && radioButton5.Checked == false && radioButton10.Checked == true && radioButton9.Checked == false)
            {
                double s2 = 0.05;
                topla2 = topla2 + s2;
                MessageBox.Show("0.05");
                radioButton8.Enabled = false;
                radioButton7.Enabled = false;
                radioButton5.Enabled = false;
                radioButton6.Enabled = false;
                radioButton9.Enabled = false;
            }
            if (radioButton10.Checked == false)
            {
                radioButton8.Enabled = true;
                radioButton7.Enabled = true;
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;
                radioButton9.Enabled = true;
            }
        }
        //YETENEK
        double topla = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                double s1 = 0.15;
                topla = topla + s1;
                MessageBox.Show("0.15");
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                double s1 = 0.15;
                topla = topla + s1;
                MessageBox.Show("0.06");
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            if (checkBox2.Checked == false)
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                double s1 = 0.00;
                topla = topla + s1;
                MessageBox.Show("0.00");
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            if (checkBox3.Checked == false)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == false)
            {
                double s1 = 0.05;
                topla = topla - s1;
                MessageBox.Show("0.05");
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox5.Enabled = false;
            }
            if (checkBox4.Checked == false)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                double s1 = 0.16;
                topla = topla - s1;
                MessageBox.Show("0.16");
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            if (checkBox5.Checked == false)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }
        //ÇABA
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true && checkBox9.Checked == false && checkBox11.Checked == false && checkBox8.Checked == false && checkBox7.Checked == false && checkBox6.Checked == false)
            {
                double s1 = 0.13;
                topla = topla + s1;
                MessageBox.Show("0.13");
                checkBox9.Enabled = false;
                checkBox11.Enabled = false;
                checkBox8.Enabled = false;
                checkBox7.Enabled = false;
                checkBox6.Enabled = false;
            }
            if (checkBox10.Checked == false)
            {
                checkBox9.Enabled = true;
                checkBox11.Enabled = true;
                checkBox8.Enabled = true;
                checkBox7.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false && checkBox9.Checked == true && checkBox11.Checked == false && checkBox8.Checked == false && checkBox7.Checked == false && checkBox6.Checked == false)
            {
                double s1 = 0.10;
                topla = topla + s1;
                MessageBox.Show("0.10");
                checkBox10.Enabled = false;
                checkBox11.Enabled = false;
                checkBox8.Enabled = false;
                checkBox7.Enabled = false;
                checkBox6.Enabled = false;
            }
            if (checkBox9.Checked == false)
            {
                checkBox10.Enabled = true;
                checkBox11.Enabled = true;
                checkBox8.Enabled = true;
                checkBox7.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false && checkBox9.Checked == false && checkBox11.Checked == true && checkBox8.Checked == false && checkBox7.Checked == false && checkBox6.Checked == false)
            {
                double s1 = 0.05;
                topla = topla + s1;
                MessageBox.Show("0.05");
                checkBox10.Enabled = false;
                checkBox9.Enabled = false;
                checkBox8.Enabled = false;
                checkBox7.Enabled = false;
                checkBox6.Enabled = false;
            }
            if (checkBox11.Checked == false)
            {
                checkBox10.Enabled = true;
                checkBox9.Enabled = true;
                checkBox8.Enabled = true;
                checkBox7.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false && checkBox9.Checked == false && checkBox11.Checked == false && checkBox8.Checked == true && checkBox7.Checked == false && checkBox6.Checked == false)
            {
                double s1 = 0.00;
                topla = topla + s1;
                MessageBox.Show("0.00");
                checkBox10.Enabled = false;
                checkBox9.Enabled = false;
                checkBox11.Enabled = false;
                checkBox7.Enabled = false;
                checkBox6.Enabled = false;
            }
            if (checkBox8.Checked == false)
            {
                checkBox10.Enabled = true;
                checkBox9.Enabled = true;
                checkBox11.Enabled = true;
                checkBox7.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false && checkBox9.Checked == false && checkBox11.Checked == false && checkBox8.Checked == false && checkBox7.Checked == true && checkBox6.Checked == false)
            {
                double s1 = 0.04;
                topla = topla - s1;
                MessageBox.Show("0.04");
                checkBox10.Enabled = false;
                checkBox9.Enabled = false;
                checkBox11.Enabled = false;
                checkBox8.Enabled = false;
                checkBox6.Enabled = false;
            }
            if (checkBox7.Checked == false)
            {
                checkBox10.Enabled = true;
                checkBox9.Enabled = true;
                checkBox11.Enabled = true;
                checkBox8.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == false && checkBox9.Checked == false && checkBox11.Checked == false && checkBox8.Checked == false && checkBox7.Checked == false && checkBox6.Checked == true)
            {
                double s1 = 0.12;
                topla = topla - s1;
                MessageBox.Show("0.12");
                checkBox10.Enabled = false;
                checkBox9.Enabled = false;
                checkBox11.Enabled = false;
                checkBox8.Enabled = false;
                checkBox7.Enabled = false;
            }
            if (checkBox6.Checked == false)
            {
                checkBox10.Enabled = true;
                checkBox9.Enabled = true;
                checkBox11.Enabled = true;
                checkBox8.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        //ÇalışmaKoşulları
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == true && checkBox16.Checked == false && checkBox12.Checked == false && checkBox15.Checked == false && checkBox14.Checked == false && checkBox13.Checked == false)
            {
                double s1 = 0.06;
                topla = topla + s1;
                MessageBox.Show("0.06");
                checkBox16.Enabled = false;
                checkBox12.Enabled = false;
                checkBox15.Enabled = false;
                checkBox14.Enabled = false;
                checkBox13.Enabled = false;
            }
            if (checkBox17.Checked == false)
            {
                checkBox16.Enabled = true;
                checkBox12.Enabled = true;
                checkBox15.Enabled = true;
                checkBox14.Enabled = true;
                checkBox13.Enabled = true;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == false && checkBox16.Checked == true && checkBox12.Checked == false && checkBox15.Checked == false && checkBox14.Checked == false && checkBox13.Checked == false)
            {
                double s1 = 0.14;
                topla = topla + s1;
                MessageBox.Show("0.14");
                checkBox17.Enabled = false;
                checkBox12.Enabled = false;
                checkBox15.Enabled = false;
                checkBox14.Enabled = false;
                checkBox13.Enabled = false;
            }
            if (checkBox16.Checked == false)
            {
                checkBox17.Enabled = true;
                checkBox12.Enabled = true;
                checkBox15.Enabled = true;
                checkBox14.Enabled = true;
                checkBox13.Enabled = true;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == false && checkBox16.Checked == false && checkBox12.Checked == true && checkBox15.Checked == false && checkBox14.Checked == false && checkBox13.Checked == false)
            {
                double s1 = 0.02;
                topla = topla + s1;
                MessageBox.Show("0.02");
                checkBox17.Enabled = false;
                checkBox16.Enabled = false;
                checkBox15.Enabled = false;
                checkBox14.Enabled = false;
                checkBox13.Enabled = false;
            }
            if (checkBox12.Checked == false)
            {
                checkBox17.Enabled = true;
                checkBox16.Enabled = true;
                checkBox15.Enabled = true;
                checkBox14.Enabled = true;
                checkBox13.Enabled = true;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == false && checkBox16.Checked == false && checkBox12.Checked == false && checkBox15.Checked == true && checkBox14.Checked == false && checkBox13.Checked == false)
            {
                double s1 = 0.00;
                topla = topla + s1;
                MessageBox.Show("0.00");
                checkBox17.Enabled = false;
                checkBox16.Enabled = false;
                checkBox12.Enabled = false;
                checkBox14.Enabled = false;
                checkBox13.Enabled = false;
            }
            if (checkBox15.Checked == false)
            {
                checkBox17.Enabled = true;
                checkBox16.Enabled = true;
                checkBox12.Enabled = true;
                checkBox14.Enabled = true;
                checkBox13.Enabled = true;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == false && checkBox16.Checked == false && checkBox12.Checked == false && checkBox15.Checked == false && checkBox14.Checked == true && checkBox13.Checked == false)
            {
                double s1 = 0.03;
                topla = topla - s1;
                MessageBox.Show("0.03");
                checkBox17.Enabled = false;
                checkBox16.Enabled = false;
                checkBox12.Enabled = false;
                checkBox15.Enabled = false;
                checkBox13.Enabled = false;
            }
            if (checkBox14.Checked == false)
            {
                checkBox17.Enabled = true;
                checkBox16.Enabled = true;
                checkBox12.Enabled = true;
                checkBox15.Enabled = true;
                checkBox13.Enabled = true;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked == false && checkBox16.Checked == false && checkBox12.Checked == false && checkBox15.Checked == false && checkBox14.Checked == false && checkBox13.Checked == true)
            {
                double s1 = 0.07;
                topla = topla - s1;
                MessageBox.Show("0.07");
                checkBox17.Enabled = false;
                checkBox16.Enabled = false;
                checkBox12.Enabled = false;
                checkBox15.Enabled = false;
                checkBox14.Enabled = false;
            }
            if (checkBox13.Checked == false)
            {
                checkBox17.Enabled = true;
                checkBox16.Enabled = true;
                checkBox12.Enabled = true;
                checkBox15.Enabled = true;
                checkBox14.Enabled = true;
            }
        }
        //Tutarlılık
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true && checkBox22.Checked == false && checkBox18.Checked == false && checkBox21.Checked == false && checkBox20.Checked == false && checkBox19.Checked == false)
            {
                double s1 = 0.04;
                topla = topla + s1;
                MessageBox.Show("0.04");
                checkBox22.Enabled = false;
                checkBox18.Enabled = false;
                checkBox21.Enabled = false;
                checkBox20.Enabled = false;
                checkBox19.Enabled = false;
            }
            if (checkBox23.Checked == false)
            {
                checkBox22.Enabled = true;
                checkBox18.Enabled = true;
                checkBox21.Enabled = true;
                checkBox20.Enabled = true;
                checkBox19.Enabled = true;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false && checkBox22.Checked == true && checkBox18.Checked == false && checkBox21.Checked == false && checkBox20.Checked == false && checkBox19.Checked == false)
            {
                double s1 = 0.03;
                topla = topla + s1;
                MessageBox.Show("0.03");
                checkBox23.Enabled = false;
                checkBox18.Enabled = false;
                checkBox21.Enabled = false;
                checkBox20.Enabled = false;
                checkBox19.Enabled = false;
            }
            if (checkBox22.Checked == false)
            {
                checkBox23.Enabled = true;
                checkBox18.Enabled = true;
                checkBox21.Enabled = true;
                checkBox20.Enabled = true;
                checkBox19.Enabled = true;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false && checkBox22.Checked == false && checkBox18.Checked == true && checkBox21.Checked == false && checkBox20.Checked == false && checkBox19.Checked == false)
            {
                double s1 = 0.01;
                topla = topla + s1;
                MessageBox.Show("0.01");
                checkBox23.Enabled = false;
                checkBox22.Enabled = false;
                checkBox21.Enabled = false;
                checkBox20.Enabled = false;
                checkBox19.Enabled = false;
            }
            if (checkBox18.Checked == false)
            {
                checkBox23.Enabled = true;
                checkBox22.Enabled = true;
                checkBox21.Enabled = true;
                checkBox20.Enabled = true;
                checkBox19.Enabled = true;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false && checkBox22.Checked == false && checkBox18.Checked == false && checkBox21.Checked == true && checkBox20.Checked == false && checkBox19.Checked == false)
            {
                double s1 = 0.00;
                topla = topla + s1;
                MessageBox.Show("0.00");
                checkBox23.Enabled = false;
                checkBox22.Enabled = false;
                checkBox18.Enabled = false;
                checkBox20.Enabled = false;
                checkBox19.Enabled = false;
            }
            if (checkBox21.Checked == false)
            {
                checkBox23.Enabled = true;
                checkBox22.Enabled = true;
                checkBox18.Enabled = true;
                checkBox20.Enabled = true;
                checkBox19.Enabled = true;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false && checkBox22.Checked == false && checkBox18.Checked == false && checkBox21.Checked == false && checkBox20.Checked == true && checkBox19.Checked == false)
            {
                double s1 = 0.02;
                topla = topla - s1;
                MessageBox.Show("0.02");
                checkBox23.Enabled = false;
                checkBox22.Enabled = false;
                checkBox18.Enabled = false;
                checkBox21.Enabled = false;
                checkBox19.Enabled = false;
            }
            if (checkBox20.Checked == false)
            {
                checkBox23.Enabled = true;
                checkBox22.Enabled = true;
                checkBox18.Enabled = true;
                checkBox21.Enabled = true;
                checkBox19.Enabled = true;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == false && checkBox22.Checked == false && checkBox18.Checked == false && checkBox21.Checked == false && checkBox20.Checked == false && checkBox19.Checked == true)
            {
                double s1 = 0.04;
                topla = topla - s1;
                MessageBox.Show("0.04");
                checkBox23.Enabled = false;
                checkBox22.Enabled = false;
                checkBox18.Enabled = false;
                checkBox21.Enabled = false;
                checkBox20.Enabled = false;
            }
            if (checkBox19.Checked == false)
            {
                checkBox23.Enabled = true;
                checkBox22.Enabled = true;
                checkBox18.Enabled = true;
                checkBox21.Enabled = true;
                checkBox20.Enabled = true;
            }
        }
        //FizikselÇaba
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == true && radioButton12.Checked == false && radioButton13.Checked == false && radioButton14.Checked == false && radioButton15.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton15.Enabled = false;
            }
            if (radioButton11.Checked == false)
            {
                radioButton12.Enabled = true;
                radioButton13.Enabled = true;
                radioButton14.Enabled = true;
                radioButton15.Enabled = true;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == false && radioButton12.Checked == true && radioButton13.Checked == false && radioButton14.Checked == false && radioButton15.Checked == false)
            {
                double s2 = 0.03;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton11.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
                radioButton15.Enabled = false;
            }
            if (radioButton12.Checked == false)
            {
                radioButton11.Enabled = true;
                radioButton13.Enabled = true;
                radioButton14.Enabled = true;
                radioButton15.Enabled = true;
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == false && radioButton12.Checked == false && radioButton13.Checked == true && radioButton14.Checked == false && radioButton15.Checked == false)
            {
                double s2 = 0.06;
                topla2 = topla2 + s2;
                MessageBox.Show("0.06");
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton14.Enabled = false;
                radioButton15.Enabled = false;
            }
            if (radioButton13.Checked == false)
            {
                radioButton11.Enabled = true;
                radioButton12.Enabled = true;
                radioButton14.Enabled = true;
                radioButton15.Enabled = true;
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == false && radioButton12.Checked == false && radioButton13.Checked == false && radioButton14.Checked == true && radioButton15.Checked == false)
            {
                double s2 = 0.09;
                topla2 = topla2 + s2;
                MessageBox.Show("0.09");
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton15.Enabled = false;
            }
            if (radioButton14.Checked == false)
            {
                radioButton11.Enabled = true;
                radioButton12.Enabled = true;
                radioButton13.Enabled = true;
                radioButton15.Enabled = true;
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked == false && radioButton12.Checked == false && radioButton13.Checked == false && radioButton14.Checked == false && radioButton15.Checked == true)
            {
                double s2 = 0.12;
                topla2 = topla2 + s2;
                MessageBox.Show("0.12");
                radioButton11.Enabled = false;
                radioButton12.Enabled = false;
                radioButton13.Enabled = false;
                radioButton14.Enabled = false;
            }
            if (radioButton15.Checked == false)
            {
                radioButton11.Enabled = true;
                radioButton12.Enabled = true;
                radioButton13.Enabled = true;
                radioButton14.Enabled = true;
            }
        }
        //ÇalışmaPozisyonu
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == true && radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == false && radioButton20.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;
                radioButton20.Enabled = false;
            }
            if (radioButton16.Checked == false)
            {
                radioButton17.Enabled = true;
                radioButton18.Enabled = true;
                radioButton19.Enabled = true;
                radioButton20.Enabled = true;
            }
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == false && radioButton17.Checked == true && radioButton18.Checked == false && radioButton19.Checked == false && radioButton20.Checked == false)
            {
                double s2 = 0.01;
                topla2 = topla2 + s2;
                MessageBox.Show("0.01");
                radioButton16.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;
                radioButton20.Enabled = false;
            }
            if (radioButton17.Checked == false)
            {
                radioButton16.Enabled = true;
                radioButton18.Enabled = true;
                radioButton19.Enabled = true;
                radioButton20.Enabled = true;
            }
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == false && radioButton17.Checked == false && radioButton18.Checked == true && radioButton19.Checked == false && radioButton20.Checked == false)
            {
                double s2 = 0.05;
                topla2 = topla2 + s2;
                MessageBox.Show("0.05");
                radioButton16.Enabled = false;
                radioButton17.Enabled = false;
                radioButton19.Enabled = false;
                radioButton20.Enabled = false;
            }
            if (radioButton18.Checked == false)
            {
                radioButton16.Enabled = true;
                radioButton17.Enabled = true;
                radioButton19.Enabled = true;
                radioButton20.Enabled = true;
            }
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == false && radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == true && radioButton20.Checked == false)
            {
                double s2 = 0.08;
                topla2 = topla2 + s2;
                MessageBox.Show("0.08");
                radioButton16.Enabled = false;
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton20.Enabled = false;
            }
            if (radioButton19.Checked == false)
            {
                radioButton16.Enabled = true;
                radioButton17.Enabled = true;
                radioButton18.Enabled = true;
                radioButton20.Enabled = true;
            }
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked == false && radioButton17.Checked == false && radioButton18.Checked == false && radioButton19.Checked == false && radioButton20.Checked == true)
            {
                double s2 = 0.15;
                topla2 = topla2 + s2;
                MessageBox.Show("0.15");
                radioButton16.Enabled = false;
                radioButton17.Enabled = false;
                radioButton18.Enabled = false;
                radioButton19.Enabled = false;
            }
            if (radioButton20.Checked == false)
            {
                radioButton16.Enabled = true;
                radioButton17.Enabled = true;
                radioButton18.Enabled = true;
                radioButton19.Enabled = true;
            }
        }
        //Atmosfer
        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton21.Checked == true && radioButton22.Checked == false && radioButton23.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton22.Enabled = false;
                radioButton23.Enabled = false;
            }
            if (radioButton21.Checked == false)
            {
                radioButton22.Enabled = true;
                radioButton23.Enabled = true;
            }
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton21.Checked == false && radioButton22.Checked == true && radioButton23.Checked == false)
            {
                double s2 = 0.03;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton21.Enabled = false;
                radioButton23.Enabled = false;
            }
            if (radioButton22.Checked == false)
            {
                radioButton21.Enabled = true;
                radioButton23.Enabled = true;
            }
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton21.Checked == false && radioButton22.Checked == false && radioButton23.Checked == true)
            {
                double s2 = 0.08;
                topla2 = topla2 + s2;
                MessageBox.Show("0.08");
                radioButton21.Enabled = false;
                radioButton22.Enabled = false;
            }
            if (radioButton23.Checked == false)
            {
                radioButton21.Enabled = true;
                radioButton22.Enabled = true;
            }
        }
        //Isı
        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton26.Checked == true && radioButton25.Checked == false && radioButton24.Checked == false)
            {
                double s2 = 0.03;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton25.Enabled = false;
                radioButton24.Enabled = false;
            }
            if (radioButton26.Checked == false)
            {
                radioButton25.Enabled = true;
                radioButton24.Enabled = true;
            }
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton26.Checked == false && radioButton25.Checked == true && radioButton24.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton26.Enabled = false;
                radioButton24.Enabled = false;
            }
            if (radioButton25.Checked == false)
            {
                radioButton26.Enabled = true;
                radioButton24.Enabled = true;
            }
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton26.Checked == false && radioButton25.Checked == false && radioButton24.Checked == true)
            {
                double s2 = 0.08;
                topla2 = topla2 + s2;
                MessageBox.Show("0.08");
                radioButton26.Enabled = false;
                radioButton25.Enabled = false;
            }
            if (radioButton24.Checked == false)
            {
                radioButton26.Enabled = true;
                radioButton25.Enabled = true;
            }
        }
        //KoruyucuElbise
        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton27.Checked == true && radioButton28.Checked == false && radioButton29.Checked == false && radioButton30.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton28.Enabled = false;
                radioButton29.Enabled = false;
                radioButton30.Enabled = false;
            }
            if (radioButton27.Checked == false)
            {
                radioButton28.Enabled = true;
                radioButton29.Enabled = true;
                radioButton30.Enabled = true;
            }
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton27.Checked == false && radioButton28.Checked == true && radioButton29.Checked == false && radioButton30.Checked == false)
            {
                double s2 = 0.02;
                topla2 = topla2 + s2;
                MessageBox.Show("0.02");
                radioButton27.Enabled = false;
                radioButton29.Enabled = false;
                radioButton30.Enabled = false;
            }
            if (radioButton28.Checked == false)
            {
                radioButton27.Enabled = true;
                radioButton29.Enabled = true;
                radioButton30.Enabled = true;
            }
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton27.Checked == false && radioButton28.Checked == false && radioButton29.Checked == true && radioButton30.Checked == false)
            {
                double s2 = 0.15;
                topla2 = topla2 + s2;
                MessageBox.Show("0.15");
                radioButton27.Enabled = false;
                radioButton28.Enabled = false;
                radioButton30.Enabled = false;
            }
            if (radioButton29.Checked == false)
            {
                radioButton27.Enabled = true;
                radioButton28.Enabled = true;
                radioButton30.Enabled = true;
            }
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton27.Checked == false && radioButton28.Checked == false && radioButton29.Checked == false && radioButton30.Checked == true)
            {
                double s2 = 0.15;
                topla2 = topla2 + s2;
                MessageBox.Show("0.15");
                radioButton27.Enabled = false;
                radioButton28.Enabled = false;
                radioButton29.Enabled = false;
            }
            if (radioButton30.Checked == false)
            {
                radioButton27.Enabled = true;
                radioButton28.Enabled = true;
                radioButton29.Enabled = true;
            }
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton31.Checked == true && radioButton32.Checked == false && radioButton33.Checked == false && radioButton34.Checked == false)
            {
                double s2 = 0.00;
                topla2 = topla2 + s2;
                MessageBox.Show("0.00");
                radioButton32.Enabled = false;
                radioButton33.Enabled = false;
                radioButton34.Enabled = false;
            }
            if (radioButton31.Checked == false)
            {
                radioButton32.Enabled = true;
                radioButton33.Enabled = true;
                radioButton34.Enabled = true;
            }
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton31.Checked == false && radioButton32.Checked == true && radioButton33.Checked == false && radioButton34.Checked == false)
            {
                double s2 = 0.01;
                topla2 = topla2 + s2;
                MessageBox.Show("0.01");
                radioButton31.Enabled = false;
                radioButton33.Enabled = false;
                radioButton34.Enabled = false;
            }
            if (radioButton32.Checked == false)
            {
                radioButton31.Enabled = true;
                radioButton33.Enabled = true;
                radioButton34.Enabled = true;
            }
        }

        private void radioButton33_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton31.Checked == false && radioButton32.Checked == false && radioButton33.Checked == true && radioButton34.Checked == false)
            {
                double s2 = 0.05;
                topla2 = topla2 + s2;
                MessageBox.Show("0.05");
                radioButton31.Enabled = false;
                radioButton32.Enabled = false;
                radioButton34.Enabled = false;
            }
            if (radioButton33.Checked == false)
            {
                radioButton31.Enabled = true;
                radioButton32.Enabled = true;
                radioButton34.Enabled = true;
            }
        }

        private void radioButton34_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton31.Checked == false && radioButton32.Checked == false && radioButton33.Checked == false && radioButton34.Checked == true)
            {
                double s2 = 0.08;
                topla2 = topla2 + s2;
                MessageBox.Show("0.08");
                radioButton31.Enabled = false;
                radioButton32.Enabled = false;
                radioButton33.Enabled = false;
            }
            if (radioButton34.Checked == false)
            {
                radioButton31.Enabled = true;
                radioButton32.Enabled = true;
                radioButton33.Enabled = true;
            }
        }

        //Genel
        private void radioButton35_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked == true && radioButton36.Checked == false && radioButton37.Checked == false && radioButton38.Checked == false && radioButton39.Checked == false)
            {
                double s2 = 0.03;
                topla2 = topla2 + s2;
                MessageBox.Show("0.03");
                radioButton36.Enabled = false;
                radioButton37.Enabled = false;
                radioButton38.Enabled = false;
                radioButton39.Enabled = false;
            }
            if (radioButton35.Checked == false)
            {
                radioButton36.Enabled = true;
                radioButton37.Enabled = true;
                radioButton38.Enabled = true;
                radioButton39.Enabled = true;
            }
        }

        private void radioButton36_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked == false && radioButton36.Checked == true && radioButton37.Checked == false && radioButton38.Checked == false && radioButton39.Checked == false)
            {
                double s2 = 0.04;
                topla2 = topla2 + s2;
                MessageBox.Show("0.04");
                radioButton35.Enabled = false;
                radioButton37.Enabled = false;
                radioButton38.Enabled = false;
                radioButton39.Enabled = false;
            }
            if (radioButton36.Checked == false)
            {
                radioButton35.Enabled = true;
                radioButton37.Enabled = true;
                radioButton38.Enabled = true;
                radioButton39.Enabled = true;
            }
        }

        private void radioButton37_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked == false && radioButton36.Checked == false && radioButton37.Checked == true && radioButton38.Checked == false && radioButton39.Checked == false)
            {
                double s2 = 0.04;
                topla2 = topla2 + s2;
                MessageBox.Show("0.04");
                radioButton35.Enabled = false;
                radioButton36.Enabled = false;
                radioButton38.Enabled = false;
                radioButton39.Enabled = false;
            }
            if (radioButton37.Checked == false)
            {
                radioButton35.Enabled = true;
                radioButton36.Enabled = true;
                radioButton38.Enabled = true;
                radioButton39.Enabled = true;
            }
        }

        private void radioButton38_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked == false && radioButton36.Checked == false && radioButton37.Checked == false && radioButton38.Checked == true && radioButton39.Checked == false)
            {
                double s2 = 0.02;
                topla2 = topla2 + s2;
                MessageBox.Show("0.02");
                radioButton35.Enabled = false;
                radioButton36.Enabled = false;
                radioButton37.Enabled = false;
                radioButton39.Enabled = false;
            }
            if (radioButton38.Checked == false)
            {
                radioButton35.Enabled = true;
                radioButton36.Enabled = true;
                radioButton37.Enabled = true;
                radioButton39.Enabled = true;
            }
        }

        private void radioButton39_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked == false && radioButton36.Checked == false && radioButton37.Checked == false && radioButton38.Checked == false && radioButton39.Checked == true)
            {
                double s2 = 0.05;
                topla2 = topla2 + s2;
                MessageBox.Show("0.05");
                radioButton35.Enabled = false;
                radioButton36.Enabled = false;
                radioButton37.Enabled = false;
                radioButton38.Enabled = false;
            }
            if (radioButton39.Checked == false)
            {
                radioButton35.Enabled = true;
                radioButton36.Enabled = true;
                radioButton37.Enabled = true;
                radioButton38.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            topla = 0.00;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
            checkBox5.Enabled = true;
            checkBox6.Enabled = true;
            checkBox7.Enabled = true;
            checkBox8.Enabled = true;
            checkBox9.Enabled = true;
            checkBox10.Enabled = true;
            checkBox11.Enabled = true;
            checkBox12.Enabled = true;
            checkBox13.Enabled = true;
            checkBox14.Enabled = true;
            checkBox15.Enabled = true;
            checkBox16.Enabled = true;
            checkBox17.Enabled = true;
            checkBox18.Enabled = true;
            checkBox19.Enabled = true;
            checkBox20.Enabled = true;
            checkBox21.Enabled = true;
            checkBox22.Enabled = true;
            checkBox23.Enabled = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            MessageBox.Show("Temizlendi!");
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.JET.OLEDB.4.0; data source = degerlendirme.mdb");
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "-----";
            }
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("insert into Tablo1 ([projekodu],[projeadı],[operatör],[faaliyet],[whesting],[tempolama],[paymiktarı],[stdzaman],[nrmlzaman]) values ('" + comboBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + topla + "','" + textBox2.Text + "','" + topla2 + "','" + stdzaman + "','" + normzamn + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            listBox1.Items.Add("ProjeKodu: " + comboBox4.Text + "\t" + "ProjeAdı: " + comboBox1.Text + "\t" + "Operatör: " + comboBox2.Text + "\t" + "Faaliyet: " + comboBox3.Text + "\t" + "Whesting House Sonuçlar: " + topla + "\t" + "Tolerans Değeri: " + textBox2.Text + "\t" + "Pay Miktarı Sonuçları: " + topla2 + "Standart Zaman: " + stdzaman);
        }
        double stdzaman = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            topla2 = topla2 + 1;

            stdzaman = topla2 * normzamn;

            MessageBox.Show("Sonuç:  " + topla2);
            MessageBox.Show("Standart Zaman= " + stdzaman);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            topla2 = 0.00;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
            radioButton8.Enabled = true;
            radioButton9.Enabled = true;
            radioButton10.Enabled = true;
            radioButton11.Enabled = true;
            radioButton12.Enabled = true;
            radioButton13.Enabled = true;
            radioButton14.Enabled = true;
            radioButton15.Enabled = true;
            radioButton16.Enabled = true;
            radioButton17.Enabled = true;
            radioButton18.Enabled = true;
            radioButton19.Enabled = true;
            radioButton20.Enabled = true;
            radioButton21.Enabled = true;
            radioButton22.Enabled = true;
            radioButton23.Enabled = true;
            radioButton24.Enabled = true;
            radioButton25.Enabled = true;
            radioButton26.Enabled = true;
            radioButton27.Enabled = true;
            radioButton28.Enabled = true;
            radioButton29.Enabled = true;
            radioButton30.Enabled = true;
            radioButton31.Enabled = true;
            radioButton32.Enabled = true;
            radioButton33.Enabled = true;
            radioButton34.Enabled = true;
            radioButton35.Enabled = true;
            radioButton36.Enabled = true;
            radioButton37.Enabled = true;
            radioButton38.Enabled = true;
            radioButton39.Enabled = true;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = false;
            radioButton27.Checked = false;
            radioButton28.Checked = false;
            radioButton29.Checked = false;
            radioButton30.Checked = false;
            radioButton31.Checked = false;
            radioButton32.Checked = false;
            radioButton33.Checked = false;
            radioButton34.Checked = false;
            radioButton35.Checked = false;
            radioButton36.Checked = false;
            radioButton37.Checked = false;
            radioButton38.Checked = false;
            radioButton39.Checked = false;

            groupBox19.Enabled = true;
            groupBox18.Enabled = true;
        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                groupBox19.Enabled = true;
            }
            else
            {
                groupBox19.Enabled = false; ;
            }
        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true || radioButton7.Checked == true || radioButton6.Checked == true || radioButton5.Checked == true || radioButton10.Checked == true)
            {
                groupBox18.Enabled = true;
            }
            else
            {
                groupBox18.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            b3.Open();
            OleDbDataReader oku2;
            OleDbCommand komut = new OleDbCommand("select * from tablo1 where faaliyet='" + comboBox3.Text + "'and projeadı='" + comboBox1.Text + "'and projekodu='" + comboBox4.Text + "'and operatör='" + comboBox2.Text + "'", b3);
            oku2 = komut.ExecuteReader();
            while (oku2.Read())
            {
                a = Convert.ToString(oku2["normalzaman"]);
            }
            double hesap = Convert.ToDouble(a);
            double a5 = Convert.ToDouble(textBox2.Text);
            normzamn = hesap * a5;

            MessageBox.Show("Tempolama Miktarı= " + normzamn);
        }
    }
}
