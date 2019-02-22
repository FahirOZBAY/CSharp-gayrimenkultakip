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
    public partial class Form1 : Form
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
        void say()
            {
            try
            {
                baglan();
                OleDbCommand kom = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton1", conn);
                kom.Parameters.AddWithValue("@radioButton1", radioButton1.Text);
                label7.Text = kom.ExecuteScalar().ToString();
                OleDbCommand kom1 = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton2", conn);
                kom1.Parameters.AddWithValue("@radioButton2", radioButton2.Text);
                label8.Text = kom1.ExecuteScalar().ToString();
                conn.Close();

                int topla = 0;
                topla = Convert.ToInt16(label7.Text)+ Convert.ToInt16(label8.Text);
                label6.Text = topla.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }


        }
        //
        void listele()
        {


            /////
            try
            { 
            
            /////////////////
            if (radioButton3.Checked == true)
            { 
            baglan();
            DataTable dt = new DataTable();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "' order by GM_ilan_numarasi desc", conn);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
                conn.Close();
             
            }
            else if (radioButton1.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton1.Text.ToString()+ "'order by GM_ilan_numarasi desc", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (radioButton2.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton2.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }
        //
        public Form1()
        {
            InitializeComponent();
        }

        public static String ilan_numarası;
        


        private void Form1_Load(object sender, EventArgs e)
        {
           



            try
            {
                say();
            
            baglan();
            OleDbCommand cmd = new OleDbCommand("SELECT distinct (Mulk_metrekare) from tbl_emlak ", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                 { comboBox4.Items.Add(dr["Mulk_metrekare"]); }

            dr.Close();
            cmd.Dispose();
            conn.Close();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            radioButton3.Checked = true;
               this.WindowState = FormWindowState.Maximized;
                        listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            this.Close();
        }

        private void gayrimenkulEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
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
 string turu;
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            
            listele();
           
            turu = radioButton3.Text.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {    textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
        
            listele();
            turu = radioButton1.Text.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {  textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
          
            listele();
            turu = radioButton2.Text.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
               
            comboBox1.Text = "";
       comboBox5.Text = "";
comboBox2.Text = "";
            comboBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                //
                if (radioButton3.Checked == false)
                {
                    baglan();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                else
                {
                    baglan();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and  Emlak_turu='" + comboBox3.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                    ad.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
    //


}
 int bilgi = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                
                if (comboBox3.Text == "")
                {
                    if(bilgi==0)
                    {
                    ////////////////
                    MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi = 1;
                    }
                    comboBox3.Text = "";
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Mulk_mahalle='" + comboBox1.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    //////////////////////
                }
                else
                {
                    comboBox5.Text = "";
                    comboBox2.Text = "";
                    comboBox4.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "'and Mulk_mahalle='" + comboBox1.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }
        int bilgi2=0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                comboBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
                try
                {
                if (comboBox3.Text == "" || comboBox1.Text == "" || comboBox5.Text == "")
                {
                  
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    comboBox5.Text = "";
                    if (bilgi2 == 0)
                    {
                        ////////////////
                        MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi2 = 1;
                    }
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where  Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
                else
                {
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "' and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "' and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }
        int bilgi4 = 0;
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            textBox2.Text = "";
            textBox3.Text = "";
            try
            {
                if (comboBox3.Text == "" || comboBox1.Text == "" || comboBox5.Text == "" || comboBox2.Text == "")
                {
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    comboBox5.Text = "";
                    comboBox2.Text = "";
                    if (bilgi4 == 0)
                    {
                        ////////////////
                        MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi4 = 1;
                    }
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
                else
                {
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "' and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "' and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            { 
            string deger = dataGridView1.CurrentRow.Cells["GM_ilan_numarasi"].Value.ToString();
            ilan_numarası = deger.ToString();
            this.Hide();
            Form6 Form6 = new Form6();
            Form6.ShowDialog();
           this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void istekEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
            this.Close();
            //
           
        }

        private void bütünGayrimenkullerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 Form9 = new Form9();
            Form9.ShowDialog();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            string deger = "0";
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT GM_ilan_numarasi FROM tbl_emlak where GM_ilan_numarasi='" + textBox1.Text.ToString() + "'", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
                deger = dddawaa["GM_ilan_numarasi"].ToString();

            }
            conn.Close();
            if (Convert.ToInt16(deger) <= 999)
            {
                MessageBox.Show("Hatalı Bir İlan Numarası Girdiniz Lütfen Kontrol Ediniz", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ilan_numarası = deger.ToString();
                this.Hide();
                Form6 Form6 = new Form6();
                Form6.ShowDialog();
                this.Close();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        int bilgi1 = 0;
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                comboBox2.Text = "";
            comboBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
                try
                {

                if (comboBox3.Text == ""|| comboBox1.Text == "")
                {
                   
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    if (bilgi1 == 0)
                    {
                        ////////////////
                        MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi1 = 1;
                    }
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and mulk_kat='" + comboBox5.Text.ToString() + "' order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
                else
            { 
                    if (radioButton3.Checked == false)
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                    else
                    {
                        baglan();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "' and mulk_kat='" + comboBox5.Text.ToString() + "' order by GM_ilan_numarasi desc", conn);
                        ad.Fill(dt);
                        dataGridView1.DataSource = dt;
                        conn.Close();
                    }
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
    //
}
        int bilgi5=0;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text == "" || comboBox1.Text == "" || comboBox5.Text == "" || comboBox2.Text == "" || comboBox4.Text == "")
                {
                    if (bilgi5 == 0)
                    {
                        ////////////////
                        MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi5 = 1;
                    }
                    //MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (textBox2.Text != "")
                    {
                        if (textBox3.Text == "")
                        {
                            textBox3.Text = "0";
                        }
                        Double min1 = 0;
                        Double max1 = 0;
                        min1 = Convert.ToDouble(textBox2.Text);
                        max1 = Convert.ToDouble(textBox3.Text);

                        if (radioButton3.Checked == false)
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min1 + " and " + max1 + " and Emlak_cinsi='" + turu.ToString() + "' order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                        else
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min1 + " and " + max1 + " and (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                    }
                }
                else
                {
                    if (textBox2.Text != "")
                    {
                        if (textBox3.Text == "")
                        {
                            textBox3.Text = "0";
                        }
                        Double min = 0;
                        Double max = 0;
                        min = Convert.ToDouble(textBox2.Text);
                        max = Convert.ToDouble(textBox3.Text);

                        if (radioButton3.Checked == false)
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min + " and " + max + "and Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "'and mulk_kat='" + comboBox5.Text.ToString() + "'and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                        else
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min + " and " + max + "and (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "'and Mulk_mahalle='" + comboBox1.Text.ToString() + "'and mulk_kat='" + comboBox5.Text.ToString() + "'and  Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }


        }
        int bilgi3 = 0;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (comboBox3.Text == "" || comboBox1.Text == "" || comboBox5.Text == "" || comboBox2.Text == "" || comboBox4.Text == "")
                {
                    if (bilgi3 == 0)
                    {
                        ////////////////
                        MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bilgi3 = 1;
                    }
                    //MessageBox.Show("Lütfen Daha Detaylı Sonuçlar İçin Ok Yönünden Başlayarak Seçiminizi Yapınız...!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (textBox3.Text != "")
                    {
                        if (textBox2.Text == "")
                        {
                            textBox2.Text = "0";
                        }
                        Double min1 = 0;
                        Double max1 = 0;
                        min1 = Convert.ToDouble(textBox2.Text);
                        max1 = Convert.ToDouble(textBox3.Text);

                        if (radioButton3.Checked == false)
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min1 + " and " + max1 + " and Emlak_cinsi='" + turu.ToString() + "' order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                        else
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min1 + " and " + max1 + " and (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                    }
                }
                else
                {
                    if (textBox3.Text != "")
                    {
                        if (textBox2.Text == "")
                        {
                            textBox2.Text = "0";
                        }
                        Double min = 0;
                        Double max = 0;
                        min = Convert.ToDouble(textBox2.Text);
                        max = Convert.ToDouble(textBox3.Text);

                        if (radioButton3.Checked == false)
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min + " and " + max + "and Emlak_cinsi='" + turu.ToString() + "'and Emlak_turu='" + comboBox3.Text.ToString() + "' and Mulk_mahalle='" + comboBox1.Text.ToString() + "'and mulk_kat='" + comboBox5.Text.ToString() + "'and Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                        else
                        {
                            baglan();
                            DataTable dt = new DataTable();
                            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Mulk_ucreti between " + min + " and " + max + "and (Emlak_cinsi='" + radioButton1.Text.ToString() + "' or Emlak_cinsi='" + radioButton2.Text.ToString() + "') and Emlak_turu='" + comboBox3.Text.ToString() + "'and Mulk_mahalle='" + comboBox1.Text.ToString() + "'and mulk_kat='" + comboBox5.Text.ToString() + "'and  Mulk_oda_sayisi='" + comboBox2.Text.ToString() + "'and Mulk_metrekare='" + comboBox4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                            ad.Fill(dt);
                            dataGridView1.DataSource = dt;
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
      {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
