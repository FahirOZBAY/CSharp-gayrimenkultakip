namespace gayrimenkultakip
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gayrimenkulEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yedekAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.istekEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bütünGayrimenkullerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programıKilitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(395, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 129);
            this.button1.TabIndex = 0;
            this.button1.Text = "Yedek Al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(38, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(288, 129);
            this.button2.TabIndex = 0;
            this.button2.Text = "Yedek Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gayrimenkulEkleToolStripMenuItem,
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem,
            this.yedekAlToolStripMenuItem,
            this.istekEkleToolStripMenuItem,
            this.bütünGayrimenkullerToolStripMenuItem,
            this.programıKilitleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gayrimenkulEkleToolStripMenuItem
            // 
            this.gayrimenkulEkleToolStripMenuItem.Name = "gayrimenkulEkleToolStripMenuItem";
            this.gayrimenkulEkleToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.gayrimenkulEkleToolStripMenuItem.Text = "Gayrimenkul Ara";
            this.gayrimenkulEkleToolStripMenuItem.Click += new System.EventHandler(this.gayrimenkulEkleToolStripMenuItem_Click);
            // 
            // gayriMenkulDüzeltVeyaSilToolStripMenuItem
            // 
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem.Name = "gayriMenkulDüzeltVeyaSilToolStripMenuItem";
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem.Text = "Gayrimenkul Ekle";
            this.gayriMenkulDüzeltVeyaSilToolStripMenuItem.Click += new System.EventHandler(this.gayriMenkulDüzeltVeyaSilToolStripMenuItem_Click_1);
            // 
            // yedekAlToolStripMenuItem
            // 
            this.yedekAlToolStripMenuItem.Name = "yedekAlToolStripMenuItem";
            this.yedekAlToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.yedekAlToolStripMenuItem.Text = "Gayrimenkul Düzelt veya Sil";
            this.yedekAlToolStripMenuItem.Click += new System.EventHandler(this.yedekAlToolStripMenuItem_Click_1);
            // 
            // istekEkleToolStripMenuItem
            // 
            this.istekEkleToolStripMenuItem.Name = "istekEkleToolStripMenuItem";
            this.istekEkleToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.istekEkleToolStripMenuItem.Text = "İstek Ekle";
            this.istekEkleToolStripMenuItem.Click += new System.EventHandler(this.istekEkleToolStripMenuItem_Click);
            // 
            // bütünGayrimenkullerToolStripMenuItem
            // 
            this.bütünGayrimenkullerToolStripMenuItem.Name = "bütünGayrimenkullerToolStripMenuItem";
            this.bütünGayrimenkullerToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.bütünGayrimenkullerToolStripMenuItem.Text = "Bütün Gayrimenkuller";
            this.bütünGayrimenkullerToolStripMenuItem.Click += new System.EventHandler(this.bütünGayrimenkullerToolStripMenuItem_Click);
            // 
            // programıKilitleToolStripMenuItem
            // 
            this.programıKilitleToolStripMenuItem.Name = "programıKilitleToolStripMenuItem";
            this.programıKilitleToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.programıKilitleToolStripMenuItem.Text = "Programı Kilitle";
            this.programıKilitleToolStripMenuItem.Click += new System.EventHandler(this.programıKilitleToolStripMenuItem_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bkOteca";
            this.openFileDialog1.FileName = "Lütfen Sisteme Yüklemek İstediğiniz Veritabanını Seçiniz...!";
            this.openFileDialog1.Filter = "\"Backup SystemOteca (*.bkOteca)|*.bkOteca|All files (*.*)|*.*\"";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bkOteca";
            this.saveFileDialog1.FileName = "Bugünün Tarihi ile Yedeği Kaydedin Lütfen";
            this.saveFileDialog1.Filter = "\"Backup SystemOteca (*.bkOteca)|*.bkOteca|All files (*.*)|*.*\"";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedek";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gayrimenkulEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gayriMenkulDüzeltVeyaSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yedekAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programıKilitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bütünGayrimenkullerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem istekEkleToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}