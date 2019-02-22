using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Management;
using Microsoft.Win32;

namespace gayrimenkultakip
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox2.Text == "c_t")
            {
                MessageBox.Show("Yetkili Girişi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                this.Close();
            }
            if (textBox2.Text == "7100")
            {
                MessageBox.Show("Tebrikler Parolanız Doğru", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Malesef Parolanız Yanlış", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "7100")
            {
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.ShowDialog();
                this.Close();
            }
        }
        public static String CPUSeriNoCek()
        {
            String processorID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                processorID = obj["ProcessorId"].ToString();
            }

            return processorID;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            string cpuid = CPUSeriNoCek().ToString();
            string sistem = "00700F01178BFBFF";//lisans sahibi işlemci seri numarası

            if (sistem != cpuid)

            {
                MessageBox.Show("Lisans Bulunamadı.Satın almak için iletişime geçin.E-mail:ratapan@gmail.com");
                System.Windows.Forms.Application.ExitThread();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
