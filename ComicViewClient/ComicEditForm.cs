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
    public partial class ComicEditForm : Form
    {
        enum BUTTONMOVETYPE
        {
            无,
            时间设置输入框显示,
            时间设置输入框隐藏,
            弹出类型选择控件显示,
            弹出类型选择控件隐藏,
        }
        BUTTONMOVETYPE _myButtonAnimationtype = BUTTONMOVETYPE.无;
        bool _allControlValid = true;           //作为窗体内所有控件是否有效的标志
        bool _FileCreated = false;
        string _preOpenPicturePath = null;
        string _preCreateFilePath = null;
        Image _openedImageToCut;
        CvdFile _cvdFile;   //文件操作对象引用
        float _PictureSize = 1;   //控制控件中图片显示与原文件的大小倍数
        Size _PictureDrawSize;   //图片框中绘制的图片大小
        PICTURESHOWTYPE _picturePopInType = PICTURESHOWTYPE.直接出现;   //图片弹出方式
        int _pictureShowTime = 1000;
        int _pictureMoveSpeed = 100;
        int _amplitude = 10;
        //保存屏幕宽高值
        int _screenWidth;
        int _screenHeight;
        public ComicEditForm()
        {
            InitializeComponent();
            //得到屏幕宽高值
            _screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            _screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            //创建文件操作对象
            _cvdFile = new CvdFile();
        }

        private void ComicEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        //图片框控件居中
        private void pictureBoxToCenterButton_Click(object sender, EventArgs e)
        {
            this.pictureEditBox.MoveToCenter();
        }
        //创建新卷
        private void openNewCvdFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (_preCreateFilePath == null)
            {
                saveFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                _preCreateFilePath = System.Windows.Forms.Application.StartupPath;
            }
            else
            {
                saveFileDialog.InitialDirectory = _preOpenPicturePath;
            }

            //saveFileDialog.Filter = "(*.cvd)|*.cvd|";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.InitialDirectory != null)
                {
                    _preCreateFilePath = saveFileDialog.InitialDirectory;
                    if (!_cvdFile.CreateFile(saveFileDialog.FileName))
                    {
                        MessageBox.Show("创建过程出错！");
                    }
                    _FileCreated = true;
                }
            }
        }
        //打开图片
        private void openImageFileButton_Click(object sender, EventArgs e)
        {
            //this.moveButtonAnimationTick.Start();
            if (_FileCreated == false)
            {
                MessageBox.Show("还未创建文件！");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (_preOpenPicturePath == null)
            {
                openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
                _preOpenPicturePath = System.Windows.Forms.Application.StartupPath;
            }
            else
            {
                openFileDialog.InitialDirectory = _preOpenPicturePath;
            }
            //openFileDialog.Filter = "*.png|*.bmp";
            openFileDialog.Multiselect = false;
            //openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null)
                {
                    _preOpenPicturePath = openFileDialog.FileName;
                    _openedImageToCut = Image.FromFile(openFileDialog.FileName);
                    pictureEditBox.InitGetImage(_openedImageToCut);
                    pictureEditBox.InitToShowPicture(_picturePopInType, _pictureMoveSpeed, _amplitude);
                    _PictureDrawSize = new Size(_openedImageToCut.Size.Width, _openedImageToCut.Size.Height);
                }
            }
            

        }
        //放大图片
        private void enlargeImageButton_Click(object sender, EventArgs e)
        {
            if (_openedImageToCut == null)
                return;
            if (_openedImageToCut.Size.Height >= _openedImageToCut.Size.Width)
            {
                _PictureSize = (float)(_PictureDrawSize.Height + 10.0) / (float)_PictureDrawSize.Height;
                _PictureDrawSize.Width = (int)(_PictureSize * _PictureDrawSize.Width+0.5);
                _PictureDrawSize.Height = (int)(_PictureSize * _PictureDrawSize.Height+0.5);
                Bitmap img;
                img = new Bitmap((_PictureDrawSize.Width), (_PictureDrawSize.Height));
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(_openedImageToCut, 0, 0, _PictureDrawSize.Width, _PictureDrawSize.Height);
                pictureEditBox.InitGetImage(img);
                Invalidate();
            }
            else 
            {
                _PictureSize = (_PictureDrawSize.Width + 10) / _PictureDrawSize.Width;
                _PictureDrawSize.Width = (int)(_PictureSize * _PictureDrawSize.Width + 0.5);
                _PictureDrawSize.Height = (int)(_PictureSize * _PictureDrawSize.Height + 0.5);
                Bitmap img;
                img = new Bitmap((_PictureDrawSize.Width), (_PictureDrawSize.Height));
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(_openedImageToCut, 0, 0, _PictureDrawSize.Width, _PictureDrawSize.Height);
                pictureEditBox.InitGetImage(img);
                Invalidate();
            }
            
        }
        //缩小图片
        private void shrinkImageButton_Click(object sender, EventArgs e)
        {
            if (_openedImageToCut == null)
                return;
            if (_openedImageToCut.Size.Height >= _openedImageToCut.Size.Width)
            {
                _PictureSize = (float)(_PictureDrawSize.Height - 10.0) / (float)_PictureDrawSize.Height;
                _PictureDrawSize.Width = (int)(_PictureSize * _PictureDrawSize.Width + 0.5);
                _PictureDrawSize.Height = (int)(_PictureSize * _PictureDrawSize.Height + 0.5);
                Bitmap img;
                img = new Bitmap((_PictureDrawSize.Width), (_PictureDrawSize.Height));
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(_openedImageToCut, 0, 0, _PictureDrawSize.Width, _PictureDrawSize.Height);
                pictureEditBox.InitGetImage(img);
                Invalidate();
            }
            else
            {
                _PictureSize = (_PictureDrawSize.Width - 10) / _PictureDrawSize.Width;
                _PictureDrawSize.Width = (int)(_PictureSize * _PictureDrawSize.Width + 0.5);
                _PictureDrawSize.Height = (int)(_PictureSize * _PictureDrawSize.Height + 0.5);
                Bitmap img;
                img = new Bitmap((_PictureDrawSize.Width), (_PictureDrawSize.Height));
                Graphics g = Graphics.FromImage(img);
                g.DrawImage(_openedImageToCut, 0, 0, _PictureDrawSize.Width, _PictureDrawSize.Height);
                pictureEditBox.InitGetImage(img);
                Invalidate();
            }
        }
        //弹出方式
        private void imagePopStyleSetButton_Click(object sender, EventArgs e)
        {
            if (_allControlValid)
            {
                if (this.imagePopStyleSetButton.Clicked == false)
                {
                    this.imagePopStyleSetButton.Clicked = true;
                    _myButtonAnimationtype = BUTTONMOVETYPE.弹出类型选择控件显示;
                }
                else
                {
                    this.imagePopStyleSetButton.Clicked = false;
                    _myButtonAnimationtype = BUTTONMOVETYPE.弹出类型选择控件隐藏;
                }
                moveButtonAnimationTick.Start();
            }
        }
        private void imagePopStyleToLastButton_Click(object sender, EventArgs e)
        {
            switch (_picturePopInType)
            {
                case PICTURESHOWTYPE.直接出现:
                    _picturePopInType = PICTURESHOWTYPE.上至下出现;
                    this.imagePopStyleLabel.Text = "上至下出现";
                    break;
                case PICTURESHOWTYPE.上至下出现:
                    _picturePopInType = PICTURESHOWTYPE.下至上出现;
                    this.imagePopStyleLabel.Text = "下至上出现";
                    break;
                case PICTURESHOWTYPE.下至上出现:
                    _picturePopInType = PICTURESHOWTYPE.直接出现;
                    this.imagePopStyleLabel.Text = "直接出现";
                    break;
            }
            pictureEditBox.InitToShowPicture(_picturePopInType, _pictureMoveSpeed, _amplitude);
        }
        private void imagePopStyleToNextButton_Click(object sender, EventArgs e)
        {
            switch (_picturePopInType)
            {
                case PICTURESHOWTYPE.直接出现:
                    _picturePopInType = PICTURESHOWTYPE.下至上出现;
                    this.imagePopStyleLabel.Text = "下至上出现";
                    break;
                case PICTURESHOWTYPE.上至下出现:
                    _picturePopInType = PICTURESHOWTYPE.直接出现;
                    this.imagePopStyleLabel.Text = "直接出现";
                    break;
                case PICTURESHOWTYPE.下至上出现:
                    _picturePopInType = PICTURESHOWTYPE.上至下出现;
                    this.imagePopStyleLabel.Text = "上至下出现";
                    break;
            }
            pictureEditBox.InitToShowPicture(_picturePopInType, _pictureMoveSpeed, _amplitude);
        }
        //弹出时间
        private void imagePopTimeSetButton_Click(object sender, EventArgs e)
        {
            if (_allControlValid)
            {
                if (this.imagePopTimeSetButton.Clicked == false)
                {
                    this.imagePopTimeSetButton.Clicked = true;
                    _myButtonAnimationtype = BUTTONMOVETYPE.时间设置输入框显示;
                }
                else
                {
                    _myButtonAnimationtype = BUTTONMOVETYPE.时间设置输入框隐藏;
                    this.imagePopTimeSetButton.Clicked = false;
                }
                moveButtonAnimationTick.Start();
            }
        }
        //时间设置Timer的TextBox
        private void imagePopTimeTextbox_TextChanged(object sender, EventArgs e)
        {
            _pictureShowTime = System.Int32.Parse(this.imagePopTimeTextbox.Text);
        }
        //保存本帧
        private void savePresentPictureButton_Click(object sender, EventArgs e)
        {
            if (_preCreateFilePath == null) return;
            CVD cvdbuf = new CVD();
            cvdbuf.AnimationNum = (uint)_picturePopInType;
            cvdbuf.Picturefilename = _preOpenPicturePath.Substring(_preOpenPicturePath.LastIndexOf("\\")+1);
            cvdbuf.PictureCutX = this.pictureEditBox._openDrawState.X;
            cvdbuf.PictureCutY = this.pictureEditBox._openDrawState.Y;
            cvdbuf.PictureCutWidth = (int)((float)this.pictureEditBox.Size.Width / _PictureSize);
            cvdbuf.PictureCutHeight = (int)((float)this.pictureEditBox.Size.Height / _PictureSize);
            cvdbuf.X = this.pictureEditBox.Location.X;
            cvdbuf.Y = this.pictureEditBox.Location.Y;
            cvdbuf.Width = this.pictureEditBox.Size.Width;
            cvdbuf.Height = this.pictureEditBox.Size.Height;
            cvdbuf.StopTime = _pictureShowTime;
            cvdbuf.PopInStyle = (uint)_picturePopInType;
            cvdbuf.PopOutStyle = 1;
            cvdbuf.EndFlag = true;
            _cvdFile.Add(cvdbuf);
        }
        //预览
        private void previewButton_Click(object sender, EventArgs e)
        {
            List<CVD> cvdlist = new List<CVD>();
            _cvdFile.Read(_preCreateFilePath+"\\3333.cvd", cvdlist);
        }
        //保存本卷
        private void savePresentCvdFileButton_Click(object sender, EventArgs e)
        {

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
        
        //没有使用
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //按钮移动动画定时器触发
        private void moveButtonAnimationTick_Tick(object sender, EventArgs e)
        {
            switch (_myButtonAnimationtype)
            {
                case BUTTONMOVETYPE.时间设置输入框显示:
                    if (!this.imagePopStyleSetButton.Clicked)
                    {
                        if (this.imagePopTimeSetButton.Clicked && this.imagePopTimeTextbox.Location.Y < 280)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y += 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y += 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y += 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y += 2;
                            imagePopTimeTextbox.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    else
                    {
                        if (this.imagePopTimeSetButton.Clicked && this.imagePopTimeTextbox.Location.Y < 340)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y += 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y += 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y += 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y += 2;
                            imagePopTimeTextbox.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    break;
                case BUTTONMOVETYPE.时间设置输入框隐藏:
                     if (!this.imagePopStyleSetButton.Clicked)
                     {
                        if (!this.imagePopTimeSetButton.Clicked && this.imagePopTimeTextbox.Location.Y > 250)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y -= 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y -= 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y -= 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y -= 2;
                            imagePopTimeTextbox.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    else
                    {
                        if (!this.imagePopTimeSetButton.Clicked && this.imagePopTimeTextbox.Location.Y > 310)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y -= 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y -= 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y -= 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y -= 2;
                            imagePopTimeTextbox.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    break;
                case BUTTONMOVETYPE.弹出类型选择控件显示:
                    if (this.imagePopStyleSetButton.Clicked)
                    { 
                        if (this.imagePopStyleToLastButton.Location.Y < 250)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y += 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y += 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y += 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y += 2;
                            imagePopTimeTextbox.Location = p;
                            p = imagePopTimeSetButton.Location;
                            p.Y += 2;
                            imagePopTimeSetButton.Location = p;
                            p = imagePopStyleToLastButton.Location;
                            p.Y += 2;
                            imagePopStyleToLastButton.Location = p;
                            p = imagePopStyleToNextButton.Location;
                            p.Y += 2;
                            imagePopStyleToNextButton.Location = p;
                            p = imagePopStyleLabel.Location;
                            p.Y += 2;
                            imagePopStyleLabel.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    else
                    {
                        MessageBox.Show("目测是不会走到这里来的-case BUTTONMOVETYPE.弹出类型选择控件显示:");
                    }
                    break;
                case BUTTONMOVETYPE.弹出类型选择控件隐藏:
                    if (!this.imagePopStyleSetButton.Clicked)
                    { 
                        if (this.imagePopStyleToLastButton.Location.Y > 190)
                        {
                            Point p = new Point();
                            p = savePresentPictureButton.Location;
                            p.Y -= 2;
                            savePresentPictureButton.Location = p;
                            p = previewButton.Location;
                            p.Y -= 2;
                            previewButton.Location = p;
                            p = savePresentCvdFileButton.Location;
                            p.Y -= 2;
                            savePresentCvdFileButton.Location = p;
                            p = imagePopTimeTextbox.Location;
                            p.Y -= 2;
                            imagePopTimeTextbox.Location = p;
                            p = imagePopTimeSetButton.Location;
                            p.Y -= 2;
                            imagePopTimeSetButton.Location = p;
                            p = imagePopStyleToLastButton.Location;
                            p.Y -= 2;
                            imagePopStyleToLastButton.Location = p;
                            p = imagePopStyleToNextButton.Location;
                            p.Y -= 2;
                            imagePopStyleToNextButton.Location = p;
                            p = imagePopStyleLabel.Location;
                            p.Y -= 2;
                            imagePopStyleLabel.Location = p;
                        }
                        else
                        {
                            moveButtonAnimationTick.Stop();
                        }
                    }
                    else
                    {
                        MessageBox.Show("目测是不会走到这里来的-case BUTTONMOVETYPE.弹出类型选择控件显示:");
                    }
                    break;
                default:
                    break;
           }
           
        }
        private void ComicEditForm_MouseMove(object sender, MouseEventArgs e)
        {
            pictureEditBox.MyPictureBox_MouseMove(sender, e);
        }
        private void ComicEditForm_Load(object sender, EventArgs e)
        {
            //调整控件坐标
            this.Size = new Size(_screenWidth, _screenHeight);
            this.openNewCvdFileButton.Location = new System.Drawing.Point(_screenWidth - 80, 100);
            this.openImageFileButton.Location = new System.Drawing.Point(_screenWidth - 80, 130);
            this.enlargeImageButton.Location = new System.Drawing.Point(_screenWidth - 80, 160);
            this.shrinkImageButton.Location = new System.Drawing.Point(_screenWidth - 80, 190);
            this.imagePopStyleSetButton.Location = new System.Drawing.Point(_screenWidth - 80, 220);
            this.imagePopTimeSetButton.Location = new System.Drawing.Point(_screenWidth - 80, 250);
            this.savePresentPictureButton.Location = new System.Drawing.Point(_screenWidth - 80, 280);
            this.previewButton.Location = new System.Drawing.Point(_screenWidth - 80, 310);
            this.savePresentCvdFileButton.Location = new System.Drawing.Point(_screenWidth - 80, 340);
            this.backToMainFormButton.Location = new System.Drawing.Point(_screenWidth - 40, 75);
            this.appCloseButton.Location = new System.Drawing.Point(_screenWidth - 20, 55);
            this.formMinisizeButton.Location = new System.Drawing.Point(_screenWidth - 40, 55);
            this.imagePopStyleToLastButton.Location = new System.Drawing.Point(_screenWidth - 80, 190);
            this.imagePopStyleToNextButton.Location = new System.Drawing.Point(_screenWidth - 40, 190);
            this.imagePopTimeTextbox.Location = new System.Drawing.Point(_screenWidth - 80, 250);
            this.imagePopStyleLabel.Location = new System.Drawing.Point(_screenWidth - 80, 220);
            //this.BackColor = Color.Green;
            //this.TransparencyKey = this.BackColor;
            //按钮上的文本格式
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
            this.openNewCvdFileButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.openImageFileButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.enlargeImageButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.shrinkImageButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.imagePopStyleSetButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.imagePopTimeSetButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.savePresentPictureButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.previewButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.savePresentCvdFileButton.Font = new System.Drawing.Font("微软雅黑", 12);
            this.backToMainFormButton.Font = new System.Drawing.Font("楷体", 20);
            this.appCloseButton.Font = new System.Drawing.Font("微软雅黑", 20);
            this.formMinisizeButton.Font = new System.Drawing.Font("微软雅黑", 26);
            this.pictureBoxToCenterButton.Font = new System.Drawing.Font("微软雅黑", 10);

        }

        private void pictureBoxToCenterButton_Load(object sender, EventArgs e)
        {

        }
    }
}
