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
    public partial class Form8 : Form
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
            public Form8()
        {
           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
            this.Close();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            try
            { 
            textBox2.Text = Form7.istek_sahibi_tel;
           
            baglan();
            DataTable dtawaa = new DataTable();
            OleDbCommand adawaa = new OleDbCommand("SELECT * FROM tbl_istek  where  istek_sahibi_tel='" + textBox2.Text + "' ", conn);
            OleDbDataReader dddawaa = adawaa.ExecuteReader();
            while (dddawaa.Read())
            {
                //combosorusıra.Items.Add(dddawaa["Emlak_cinsi"]);
                textBox3.Text = dddawaa["istek_cinsi"].ToString();
                comboBox1.Text = dddawaa["istegi"].ToString();
                textBox1.Text = dddawaa["istek_sahibinin_adi"].ToString();
                textBox5.Text = dddawaa["İstek_detay"].ToString();
            }
            conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorun Var " + ex.Message);
            }
        }
    }
}
