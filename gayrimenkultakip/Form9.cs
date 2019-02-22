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
    public partial class Form9 : Form
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
        void say()
        {
            try
            {
                baglan();
                OleDbCommand kom = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton5", conn);
                kom.Parameters.AddWithValue("@radioButton5", radioButton5.Text);
                label5.Text = kom.ExecuteScalar().ToString();
                OleDbCommand kom1 = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton2", conn);
                kom1.Parameters.AddWithValue("@radioButton2", radioButton2.Text);
                label2.Text = kom1.ExecuteScalar().ToString();
                OleDbCommand kom2 = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton3", conn);
                kom2.Parameters.AddWithValue("@radioButton3", radioButton3.Text);
                label3.Text = kom2.ExecuteScalar().ToString();
                OleDbCommand kom3 = new OleDbCommand("SELECT COUNT(GM_ilan_numarasi) FROM tbl_emlak WHERE Emlak_cinsi=@radioButton4", conn);
                kom3.Parameters.AddWithValue("@radioButton4", radioButton4.Text);
                label4.Text = kom3.ExecuteScalar().ToString();
                conn.Close();

                int topla = 0;
                topla = Convert.ToInt16(label2.Text) + Convert.ToInt16(label3.Text) + Convert.ToInt16(label4.Text) + Convert.ToInt16(label5.Text);
                label1.Text = topla.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }
            void listele()
        {
            try
            { 
            if (radioButton1.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak order by GM_ilan_numarasi desc ", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            else if (radioButton2.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton2.Text.ToString() + "' order by GM_ilan_numarasi desc", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (radioButton3.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton3.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (radioButton4.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton4.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            else if (radioButton5.Checked == true)
            {
                baglan();
                DataTable dt = new DataTable();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT GM_ilan_numarasi,Emlak_cinsi,Emlak_turu,Mulk_mahalle,mulk_kat,Mulk_oda_sayisi,Mulk_metrekare,Mulk_ucreti,Mulk_adresi,Mulk_sahibi,Mulk_sahibi_tel1,Mulk_sahibi_tel2,Mulk_ekbilgi from tbl_emlak where Emlak_cinsi='" + radioButton5.Text.ToString() + "'order by GM_ilan_numarasi desc", conn);
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
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            say();
            this.WindowState = FormWindowState.Maximized;
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listele();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listele();

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listele();

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listele();

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
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            this.Close();
        }

        private void yedekAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
            this.Close();
        }

        private void istekEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
            this.Close();
        }

        private void bütünGayrimenkullerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void yedekToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
