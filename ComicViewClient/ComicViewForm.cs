using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComicViewClient
{
    public partial class ComicViewForm : Form
    {
        public ComicViewForm()
        {
            InitializeComponent();
            //得到屏幕宽高值
            _screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.DoubleBuffered = true;

        }
        bool _allControlValid = true;

        
        //保存屏幕宽高值
        int _screenWidth;
        int _screenHeight;

        string _cvdFilePath = null;
        int _openedCvdFileListCount = 0;
        List<CVD> _openedCvdFileList = new List<CVD>();

        private void ComicViewForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            this.TransparencyKey = this.BackColor;
            PictureViewBox.Hide();

            this.Size = new Size(_screenWidth, _screenHeight);
            this.backToMainFormButton.Location = new System.Drawing.Point(_screenWidth - 40, 75);
            this.appCloseButton.Location = new System.Drawing.Point(_screenWidth - 20, 55);
            this.formMinisizeButton.Location = new System.Drawing.Point(_screenWidth - 40, 55);
            
            this.backToMainFormButton.Font = new System.Drawing.Font("楷体", 20);
            this.appCloseButton.Font = new System.Drawing.Font("微软雅黑", 20);
            this.formMinisizeButton.Font = new System.Drawing.Font("微软雅黑", 26);

        }

        //返回至主窗口
        private void backToMainFormButton_Click(object sender, EventArgs e)
        {

        }
        //关闭程序
        private void appCloseButton_Click(object sender, EventArgs e)
        {
            if (_allControlValid)
            {
                this.Close();
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

        }
        //最小化窗口
        private void formMinisizeButton_Click(object sender, EventArgs e)
        {
            if (_allControlValid)
            {
                this.WindowState = FormWindowState.Minimized;
            }

        }
        //打开文件
        private void openCvdFileButton_Click(object dender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
              
            openFileDialog.Filter = "*.cvd|*.CVD";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null)
                {
                    CvdFile cvdfile = new CvdFile();
                    cvdfile.Read(openFileDialog.FileName, _openedCvdFileList);
                    _cvdFilePath = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf("\\"));
                    System.Console.WriteLine("{0}", _cvdFilePath);
                    if (_openedCvdFileList.Count > 0)
                    {
                        PictureViewBox.ShowCvdFile(_openedCvdFileList[_openedCvdFileListCount], _cvdFilePath);
                        this.timer1.Interval = _openedCvdFileList[0].StopTime;
                        _openedCvdFileListCount++;
                        this.PictureViewBox.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("文件错误或文件是空的");
                        openCvdFileButton_Click(dender, e);
                    }
                    
                }
            }
        }

        //播放或者暂停
        private void playorPauseButton_Click(object sender, EventArgs e)
        {
            if (this.playorPauseButton.ButtonText == "播放")
            {
                this.playorPauseButton.ButtonText = "暂停";
                this.timer1.Start();
                this.timer1.Interval = 1000;
            }
            else
            {
                this.playorPauseButton.ButtonText = "播放";
                
            }
            
        }

        //播放计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            System.Console.WriteLine("换帧计时器触发！");
            if (_openedCvdFileList[_openedCvdFileListCount-1].EndFlag == true)
            {
                return;
            }
            this.timer1.Stop();
            this.timer1.Interval = _openedCvdFileList[_openedCvdFileListCount].StopTime;
            
            this.timer1.Start();
            
            PictureViewBox.ShowCvdFile(_openedCvdFileList[_openedCvdFileListCount], _cvdFilePath);
            _openedCvdFileListCount++;
        }
    }
}
