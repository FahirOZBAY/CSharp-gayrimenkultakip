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
    public partial class Form7 : Form
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
            public Form7()
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

        void listele()
        {

            if (radioButton4.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * from tbl_istek ", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
              
            }
            else if (radioButton5.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * from tbl_istek where istek_cinsi='" + radioButton1.Text.ToString() + "'", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (radioButton3.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * from tbl_istek where istek_cinsi='" + radioButton2.Text.ToString() + "'", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="")
            { 
            string istek_cinsi;
            if(radioButton1.Checked == true)
            {
                istek_cinsi = radioButton1.Text.ToString();
            }
            else
            {
                istek_cinsi = radioButton2.Text.ToString();

            }
            baglan();
           
            OleDbCommand kom = new OleDbCommand("insert into tbl_istek (istek_cinsi,istegi,istek_sahibinin_adi,istek_sahibi_tel,istek_detay) values(@istek_cinsi,@istegi,@istek_sahibinin_adi,@istek_sahibi_tel,@istek_detay)", conn);
           kom.Parameters.AddWithValue("@istek_cinsi", istek_cinsi.ToString());
            kom.Parameters.AddWithValue("@istegi", comboBox1.Text.ToString());
            kom.Parameters.AddWithValue("@istek_sahibinin_adi", textBox1.Text.ToString());
            kom.Parameters.AddWithValue("@istek_sahibi_tel", textBox2.Text.ToString());
            kom.Parameters.AddWithValue("@istek_detay", textBox5.Text.ToString());
            kom.ExecuteNonQuery();

            conn.Close();
            radioButton4.Checked = true;
            listele();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            MessageBox.Show("Tebrikler İstek Veri Tabanına Başarıyla Kaydedildi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunnuz....!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /////////////////
            if(textBox3.Text!="")
            { 
            string deger = "";
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT * FROM tbl_istek  where  istek_sahibi_tel='" + textBox3.Text + "' ", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
                deger = Convert.ToString(dddawaa["istek_sahibi_tel"]);
            }
            conn.Close();
            if (deger == "")
            { MessageBox.Show("Malesef Böyle Bir Numara Yok Kontrol Edip Tekrar Deneyiniz...!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                baglan();
            OleDbCommand adawa12 = new OleDbCommand("delete * from tbl_istek where istek_sahibi_tel='" + textBox3.Text + "'", conn);
                adawa12.ExecuteNonQuery();
                MessageBox.Show("Seçtiğiniz İstek Silinmiştir...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
          
            listele();
            textBox3.Text="";
            }
            else
            {
                { MessageBox.Show("Lütfen Silmek İstediğiniz İstek Sahibinin Numarasını Giriniz...!", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }
        public static String istek_sahibi_tel;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string deger = dataGridView1.CurrentRow.Cells["istek_sahibi_tel"].Value.ToString();
            istek_sahibi_tel = deger.ToString();
            this.Hide();
            Form8 Form8 = new Form8();
            Form8.ShowDialog();
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

        private void gayrimenkulEkleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.ShowDialog();
            this.Close();
            
        }

        private void gayrimenkulEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
           
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
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

        private void programıKilitleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
         
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
            this.Close();
        }
    }
}
