using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace gayrimenkultakip
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=Database1.mdb");

        protected void Backup(string path)
        {
            // Yedekleme Dosyası Oluşturma
            string src = Application.StartupPath + @"Database1.mdb"; string dst = path; System.IO.File.Copy(src, dst, true);
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
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
            this.Close();
        }

        private void programıKilitleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /////Yedek Al
            try
            {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Delete(saveFileDialog1.FileName);
                    }
                    System.IO.File.Copy(Application.StartupPath.ToString() + "\\Database1.mdb", saveFileDialog1.FileName);

                    MessageBox.Show("Yedekleme işlemi tamamlandı !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yedekleme işlemi iptal edildi !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

               
                }
            catch(Exception ex)
            {
                MessageBox.Show("Sorun Var "+ex.Message);
            }
           
            //try
            //{
            //    string klasorYeri = "D:\\";//Klasör yerini belirtiyoruz.
            //    string klasorAdi = "YEDEK";//Klasör adını belirtiyoruz.
            //    string klasorolustur = klasorYeri + @"\" + klasorAdi;
            //    Directory.CreateDirectory(klasorolustur);//yedek veritabanının yerini oluşturuyor.
            //    //System.IO.File.Copy("Database1.mdb", "D:\\Gayrimenkül Yedeği\\" + "Database1" + ".mdb");
            //               System.IO.File.Copy("Database1.mdb", "D:\\YEDEK\\" + DateTime.Now.ToShortDateString() +"  Tarihli Yedek" + ".mdb");
            //                    MessageBox.Show("Veritabanı ( D: YEDEK )klasörüne kaydedilmiştir", "Dikkat",MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    MessageBox.Show("Veritabanı Zaten Kayıtlı!!!Önceki Veritabanını Siliniz ve Son Yedeklemeyi Tekrar Yapınız.", "UYARI",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ///Yedek Yükle
            ///
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\Database1.mdb"))
                {
                    System.IO.File.Delete(Application.StartupPath.ToString() + "\\Database1.mdb");
                }
                ///
                System.IO.File.Copy(openFileDialog1.FileName,Application.StartupPath.ToString() + "\\Database1.mdb");
                MessageBox.Show("Geri yükleme işlemi tamamlandı !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Geri yükleme işlemi iptal edildi !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
