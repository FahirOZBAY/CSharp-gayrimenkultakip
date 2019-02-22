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
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            { 
            radioButton1.Checked = true;

            this.WindowState = FormWindowState.Maximized;
      
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT GM_ilan_numarasi FROM tbl_emlak order by GM_ilan_numarasi", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
                label11.Text= dddawaa["GM_ilan_numarasi"].ToString();
             
            }
            conn.Close();
           
                int sonuc = Convert.ToInt32(label11.Text) + 1;
                label11.Text = sonuc.ToString();
            if(Convert.ToInt16(label11.Text)<=999)
            {
                label11.Text = "1000";
            }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Sorun Var " + ex.Message);
                label11.Text = "1000";
            }
            //
        }

        private void gayrimenkulEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
        }

        private void gayriMenkulDüzeltVeyaSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
            this.Close();
        }

        private void yedekAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Form5 = new Form5();
            Form5.ShowDialog();
            this.Close();
        }

        private void programıKilitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
            this.Close();
        }

        private void gayriMenkulDüzeltVeyaSilToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
            this.Close();
        }

        private void yedekAlToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Form5 = new Form5();
            Form5.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            if(comboBox1.Text=="" || comboBox2.Text=="" || comboBox4.Text == "" || comboBox3.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz...!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                string deger;
                if (radioButton1.Checked == true)
                {
                    deger = "Kiralık";
                }
                else
                {
                    deger = "Satılık";
                }
                textBox3.Text = textBox3.Text.ToString() + " m²";

                    baglan();
                OleDbCommand kom = new OleDbCommand("insert into tbl_emlak (GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_mahalle,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_ekbilgi,mulk_kat) values(@GM_ilan_numarasi,@Emlak_cinsi,@Emlak_turu,@Mulk_sahibi,@Mulk_sahibi_tel1,@Mulk_sahibi_tel2,@Mulk_mahalle,@Mulk_oda_sayisi,@Mulk_metrekare,@Mulk_ucreti,@Mulk_adresi,@Mulk_ekbilgi,@mulk_kat)", conn);
                kom.Parameters.AddWithValue("@GM_ilan_numarasi", label11.Text.ToString());
                kom.Parameters.AddWithValue("@Emlak_cinsi", deger.ToString());
                kom.Parameters.AddWithValue("@Emlak_turu", comboBox1.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_sahibi", textBox1.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_sahibi_tel1", textBox2.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_sahibi_tel2", textBox7.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_mahalle", comboBox2.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_oda_sayisi", comboBox3.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_metrekare", textBox3.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_ucreti", textBox6.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_adresi", textBox5.Text.ToString());
                kom.Parameters.AddWithValue("@Mulk_ekbilgi", textBox4.Text.ToString());
                    kom.Parameters.AddWithValue("@mulk_kat", comboBox4.Text.ToString());

                    kom.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Tebrikler " + label11.Text + " İlan Numarası ile Gayrimenkul Eklendi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                this.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }

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

        private void istekEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //istekekle
            this.Hide();
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
            this.Close();
           
        }

        private void bütünGayrimenkullerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Bütün Kayıt
            this.Hide();
            Form9 Form9 = new Form9();
            Form9.ShowDialog();
            this.Close();
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }
        int bilgi10 = 0;
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (bilgi10 == 0)
            {
                MessageBox.Show("Bu Alana Sadece Sayısal Değer Girilmelidir.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bilgi10 = 1;
            }
            }
    }
}
