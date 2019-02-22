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
    public partial class Form4 : Form
    {
        //
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
        //
        public Form4()
        {
            InitializeComponent();
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
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            this.Close();
        }

        private void yedekAlToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Form5 = new Form5();
            Form5.ShowDialog();
            this.Close();
        }

        private void programıKilitleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            groupBox1.Enabled = false;

        }
        void temizle()
        {
            groupBox1.Enabled = true;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            { 
            temizle();
            string deger="";
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT * FROM tbl_emlak  where  GM_ilan_numarasi='" + textBox7.Text + "' ", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
               deger=Convert.ToString(dddawaa["Emlak_cinsi"]);
                comboBox1.Text = dddawaa["Emlak_turu"].ToString();
                textBox1.Text = dddawaa["Mulk_sahibi"].ToString();
                textBox2.Text = dddawaa["Mulk_sahibi_tel1"].ToString();
                textBox8.Text = dddawaa["Mulk_sahibi_tel2"].ToString();
                comboBox2.Text = dddawaa["Mulk_mahalle"].ToString();
                comboBox3.Text = dddawaa["Mulk_oda_sayisi"].ToString();
                textBox3.Text = dddawaa["Mulk_metrekare"].ToString();
                textBox6.Text = dddawaa["Mulk_ucreti"].ToString();
                textBox5.Text = dddawaa["Mulk_adresi"].ToString();
                textBox4.Text = dddawaa["Mulk_ekbilgi"].ToString();
                    comboBox4.Text = dddawaa["mulk_kat"].ToString();

                }
                conn.Close();
            if(deger=="Kiralık")
            {
                radioButton1.Checked = true;
            }
            else if (deger == "Satılık")
            {
                radioButton2.Checked = true;
            }
            else if (deger == "Kiralandı")
            {
                radioButton3.Checked = true;
            }
            else if (deger == "Satıldı")
            {
                radioButton4.Checked = true;
            }



            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox3.Text == "")
            {
                groupBox1.Enabled = false;
                MessageBox.Show("Böyle Bir İlan Numarası Bulunamadı Lütfen Kontrol Edip Tekrar Deneyiniz!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

        void düzenle()
        {
            try
            { 
            baglan();
            OleDbCommand kom = new OleDbCommand("Update tbl_emlak set Emlak_cinsi=@Emlak_cinsi,Emlak_turu=@Emlak_turu,Mulk_sahibi=@Mulk_sahibi,Mulk_sahibi_tel1=@Mulk_sahibi_tel1,Mulk_sahibi_tel2=@Mulk_sahibi_tel2,Mulk_mahalle=@Mulk_mahalle,Mulk_oda_sayisi=@Mulk_oda_sayisi,Mulk_metrekare=@Mulk_metrekare,Mulk_ucreti=@Mulk_ucreti,Mulk_adresi=@Mulk_adresi,Mulk_ekbilgi=@Mulk_ekbilgi,mulk_kat=@mulk_kat where GM_ilan_numarasi='" + textBox7.Text.ToString() + "' ", conn);
            kom.Parameters.AddWithValue("@Emlak_cinsi", deger.ToString());
            kom.Parameters.AddWithValue("@Emlak_turu", comboBox1.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_sahibi", textBox1.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_sahibi_tel1", textBox2.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_sahibi_tel2", textBox8.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_mahalle", comboBox2.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_oda_sayisi", comboBox3.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_metrekare", textBox3.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_ucreti", textBox6.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_adresi", textBox5.Text.ToString());
            kom.Parameters.AddWithValue("@Mulk_ekbilgi", textBox4.Text.ToString());
                kom.Parameters.AddWithValue("@mulk_kat", comboBox4.Text.ToString());

                kom.ExecuteNonQuery();
            conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

            string deger="";

        private void button1_Click(object sender, EventArgs e)
        {

         

            if (radioButton1.Checked == true)
            {
                deger = "Kiralık";
                düzenle();
            }
            else if (radioButton2.Checked == true)
            {
                deger = "Satılık";
                düzenle();
            }
            else if (radioButton3.Checked == true)
            {
                deger = "Kiralandı";
                düzenle();
            }
            else if (radioButton4.Checked == true)
            {
                deger = "Satıldı";
                düzenle();
            }
            

            MessageBox.Show(textBox7.Text+ "  İlan Numaralı Gayrimenkulün Düzenleme İşlemi Sonuçlandı", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            baglan();
            OleDbCommand adawa12 = new OleDbCommand("delete * from tbl_emlak where GM_ilan_numarasi='" + textBox7.Text.ToString() + "' ", conn);
            adawa12.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(textBox7.Text+" İlan Numaralı Gayrimenkulün Silinme İşlemi Gerçekleşti", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
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

        private void textBox7_Click(object sender, EventArgs e)
        {
            temizle();
            groupBox1.Enabled = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int bilgi10=0;
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (bilgi10 == 0)
            {
                MessageBox.Show("Bu Alana Sadece Sayısal Değer Girilmelidir.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bilgi10 = 1;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
