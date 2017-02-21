using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComicViewClient
{
    public enum PICTURESHOWTYPE : uint
    {
        无,
        直接出现,
        上至下出现,
        下至上出现,
        右至左出现,
        左至右出现,
        放大出现,
        右至左翻页,
        左至右翻页,
        下至上翻页,
        上至下翻页,
    }

    public partial class mainForm : Form
    {
        ComicViewForm viewForm = new ComicViewForm();
        ComicEditForm editForm = new ComicEditForm();
        int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            this.TransparencyKey = this.BackColor;
            //viewForm.Owner = editForm;
            //viewForm.Show(); 
            //editForm.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void mainformEditButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            editForm.Show();
        }

        private void mainformViewButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewForm.Show();

        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
