using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gayrimenkultakip
{
    public partial class Form6 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Database1.mdb");
        void baglan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);

            }
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox7.Text = Form1.ilan_numarası;
            this.WindowState = FormWindowState.Maximized;                  
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT * FROM tbl_emlak  where  GM_ilan_numarasi='" + textBox7.Text + "' ", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
                textBox9.Text = dddawaa["Emlak_cinsi"].ToString();
                comboBox1.Text = dddawaa["Emlak_turu"].ToString();
                textBox1.Text = dddawaa["Mulk_sahibi"].ToString();
                textBox2.Text = dddawaa["Mulk_sahibi_tel1"].ToString();
                textBox8.Text = dddawaa["Mulk_sahibi_tel2"].ToString();
                comboBox2.Text = dddawaa["Mulk_mahalle"].ToString();
                comboBox3.Text = dddawaa["Mulk_oda_sayisi"].ToString();
                textBox3.Text = dddawaa["Mulk_metrekare"].ToString();
                textBox6.Text = dddawaa["Mulk_ucreti"].ToString() + " ₺ (Türk Lirası)";
                textBox5.Text = dddawaa["Mulk_adresi"].ToString();
                textBox4.Text = dddawaa["Mulk_ekbilgi"].ToString();
                    comboBox4.Text = dddawaa["mulk_kat"].ToString();


                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
       
        private void button3_Click_1(object sender, EventArgs e)
        {

          
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
    }

