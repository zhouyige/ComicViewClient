using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ComicViewClient.Properties;
using System.IO;

namespace ComicViewClient
{
    public partial class MyPictureViewBox : UserControl
    {
        private delegate void MouseOnEdge();
        public MyPictureViewBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _pictureShowType = PICTURESHOWTYPE.无;
            _nowDrawState = new Rectangle(0, 0, this.Width, this.Height);
        }

        bool _isPaint = false;
        Bitmap _myCutBitmap;
        Image _nowViewImage;
        float _PictureSize;
        PICTURESHOWTYPE _pictureShowType;
        Rectangle _nowDrawState;
        public Rectangle _openDrawState; //保存图片被截取的状态
        Point _pPoint;//记录鼠标按下时的鼠标
        Point _cPoint;//记录移动时的鼠标
        private bool _mouseLeftButtonDown = false;//鼠标左键是否按下
        MousePosOnCtrl _mpoc;
        readonly Rectangle[] _stretchFrame = new Rectangle[8];
        Rectangle[] _cursorIncoChangeRect = new Rectangle[8];
        Rectangle _picturePushRect;
        Graphics _PictureBoxPaint;

        #region enum
        enum MousePosOnCtrl
        {
            NONE = 0,
            TOP = 1,
            RIGHT = 2,
            BOTTOM = 3,
            LEFT = 4,
            TOPLEFT = 5,
            TOPRIGHT = 6,
            BOTTOMLEFT = 7,
            BOTTOMRIGHT = 8,
        }
        //enum PICTURESHOWTYPE
        //{
        //    无,
        //    直接出现,
        //    上至下出现,
        //    下至上出现,
        //    右至左出现,
        //    左至右出现,
        //    放大出现,
        //    右至左翻页,
        //    左至右翻页,
        //    下至上翻页,
        //    上至下翻页,
        //}
        #endregion

        #region dllimport
        [DllImport("user32.dll", EntryPoint = "SwapMouseButton")]
        public static extern int SwapMouseButton(int bSwap);

        [DllImport("user32", EntryPoint = "LoadCursorFromFile")]
        public static extern int LoadCursorFromFile(string lpFileName);

        [DllImport("user32", EntryPoint = "SetSystemCursor")]
        public static extern void SetSystemCursor(int hcur, int i);
        #endregion


        //获取图片绘制区域（重载）
        //public bool InitToGetDrawWindow(Rectangle rect)
        //{

        //}
        ////获取图片绘制区域(重载)
        //public bool InitToGetDrawWindow(int x, int y, int width, int height)
        //{

        //}


        //public bool InitToCutPicture(Image img, Rectangle rect)
        //{

        //}
        //初始化剪切图片（重载）
        int _pictureMoveSpeed = 100;//图片弹入速度
        int _amplitude = 10;//图片移动幅度
        public bool ShowCvdFile(CVD cvd, string cvdFilePath)
        {
            System.Console.WriteLine("ShowCvdFile: 根据cvd显示图片。");
            try
            {
                string path = cvdFilePath + "\\" + cvd.Picturefilename.Substring(0, cvd.Picturefilename.IndexOf("\0"));
                
                _nowViewImage = Image.FromFile(path);
            }
            catch
            {
                System.Console.WriteLine("图片读取异常！{0}", cvdFilePath + "\\" + cvd.Picturefilename);
                return false;
            }
            switch ((PICTURESHOWTYPE)cvd.PopInStyle)
            {
                case PICTURESHOWTYPE.直接出现:
                    _nowDrawState.X = 0;
                    _nowDrawState.Y = 0;
                    _nowDrawState.Width = cvd.Width;
                    _nowDrawState.Height = cvd.Height;
                    break;
                case PICTURESHOWTYPE.上至下出现:
                    _nowDrawState.X = 0;
                    _nowDrawState.Y = (0 - cvd.Height);
                    _nowDrawState.Width = cvd.Width;
                    _nowDrawState.Height = cvd.Height;
                    break;
                case PICTURESHOWTYPE.下至上出现:
                    _nowDrawState.X = 0;
                    _nowDrawState.Y = cvd.Height;
                    _nowDrawState.Width = cvd.Width;
                    _nowDrawState.Height = cvd.Height;
                    break;
                default:
                    System.Console.WriteLine("ShowCvdFile:枚举弹入类型出错！！");
                    break;

            }
           _PictureSize = cvd.Height / cvd.PictureCutHeight;
           this.Location = new Point(cvd.X, cvd.Y);
           this.Size = new System.Drawing.Size(cvd.Width, cvd.Height);
           InitToCutPicture(cvd.PictureCutX, cvd.PictureCutY, cvd.PictureCutWidth, cvd.PictureCutHeight);
           InitToShowPicture((PICTURESHOWTYPE)cvd.PopInStyle, _pictureMoveSpeed, _amplitude);
           //PaintStart();
           return true;
        }

        public bool InitToCutPicture(int x, int y, int width, int height)
        {
            //if (x > _nowViewImage.Width || x < 0 || y < 0 || y > _nowViewImage.Height)
            //    return false;

            _myCutBitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(_myCutBitmap);
            g.DrawImage(_nowViewImage, x, y, _nowViewImage.Width, _nowViewImage.Height);
            g.Dispose();
            this.Invalidate();
            if (_myCutBitmap != null)
            {
                return true;
            }

            return false;
        }

        //图片动画显示
        public bool InitToShowPicture(PICTURESHOWTYPE showtype, int timerValue, int ampli)
        {
            if (showtype == PICTURESHOWTYPE.无)
                return false;
            _pictureShowType = showtype;
            if (timerValue > 0 && timerValue < 500)
            {
                this.ShowPictureAnimationTick.Interval = timerValue;
            }
            else
            {
                MessageBox.Show("图片动画计时器值出错！");
            }
            if (ampli > 0 && ampli < 100)
            {
                _amplitude = ampli;
            }
            else
            {
                MessageBox.Show("图片动画幅度出错！");
            }
            this.Invalidate();
            return true;

        }

        #region 控制图片动画
        private void ShowPictureAnimationTick_Tick(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //g.DrawImage(MyCutBitmap, nowDrawState);
            if (_isPaint)
            {
                switch (_pictureShowType)
                {
                    case PICTURESHOWTYPE.直接出现:
                        break;
                    case PICTURESHOWTYPE.上至下出现:
                        if (_nowDrawState.Y < 0)
                        {
                            _nowDrawState.Y += _amplitude;
                            this.Invalidate();
                        }
                        else
                        {
                            _nowDrawState.Y = 0;
                            ShowPictureAnimationTick.Stop();
                        }
                        this.Invalidate();
                        break;
                    case PICTURESHOWTYPE.下至上出现:
                        if (_nowDrawState.Y > 0)
                        {
                            _nowDrawState.Y -= _amplitude;
                            this.Invalidate();
                        }
                        else
                        {
                            _nowDrawState.Y = 0;
                            ShowPictureAnimationTick.Stop();
                            this.Invalidate();
                        }
                        break;
                    case PICTURESHOWTYPE.右至左出现:
                        if (_nowDrawState.X > 0)
                        {
                            _nowDrawState.X -= _amplitude;
                            this.Invalidate();
                        }
                        else
                        {
                            _nowDrawState.X = 0;
                            ShowPictureAnimationTick.Stop();
                            this.Invalidate();
                        }
                        break;
                    case PICTURESHOWTYPE.左至右出现:
                        if (_nowDrawState.X < 0)
                        {
                            _nowDrawState.X += _amplitude;
                            this.Invalidate();
                        }
                        else
                        {
                            _nowDrawState.X = 0;
                            ShowPictureAnimationTick.Stop();
                            this.Invalidate();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        public void PaintStart()
        {
            _isPaint = true;
            ShowPictureAnimationTick.Start();
        }

        public void PaintStop()
        {
            _isPaint = false;
            _nowDrawState = new Rectangle(0, 0, this.Width, this.Height);
            ShowPictureAnimationTick.Stop();
            this.Invalidate();
        }

        private void MyPictureBox_Paint(object sender, PaintEventArgs e)
        {
            _PictureBoxPaint = e.Graphics;
            if (_myCutBitmap != null)
            {
                e.Graphics.DrawImage(_myCutBitmap, 0, 0, _nowDrawState.Width, _nowDrawState.Height);
            }

            Pen pen = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        private void MyPictureBox_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        public void MoveToCenter()
        {
            var mainScreenRect = Screen.PrimaryScreen.WorkingArea;
            var screencenter = new Point(mainScreenRect.Width / 2, mainScreenRect.Height / 2);

            this.Location = new Point(screencenter.X - this.Width / 2, screencenter.Y - this.Height / 2);
            this.Invalidate();
        }
    }
}
