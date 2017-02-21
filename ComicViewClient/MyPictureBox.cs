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

namespace ComicViewClient
{
    public sealed partial class MyPictureBox : UserControl
    {
        private delegate void MouseOnEdge();

        public MyPictureBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _pictureShowType = PICTURESHOWTYPE.无;
            _nowDrawState = new Rectangle(0,0,this.Width,this.Height);
            _amplitude = 1;
        }

        bool _isPaint = false;
        Bitmap _myCutBitmap;
        Image _nowEditImage;
        PICTURESHOWTYPE _pictureShowType;
        Rectangle _nowDrawState;
        public Rectangle _openDrawState; //保存图片被截取的状态
        int _amplitude;//图片移动像素幅度
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

        #region MouseDown
        public void MyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _pPoint = Cursor.Position;
            if (_stretchFrame[0].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.LEFT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[1].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.RIGHT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[2].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.TOP;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[3].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.BOTTOM;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[4].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.TOPLEFT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[5].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.TOPRIGHT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[6].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.BOTTOMLEFT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_stretchFrame[7].Contains(_pPoint))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                    _mpoc = MousePosOnCtrl.BOTTOMRIGHT;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
            }
            else if (_picturePushRect.Contains(Control.MousePosition))
            {
                if (_mouseLeftButtonDown == false)
                {
                    _mouseLeftButtonDown = true;
                }
                else
                {
                    MessageBox.Show(Resources.MyPictureBox_MyPictureBox_MouseUp_no_this_is_impossible);
                }
                
            }

            
        }
        #endregion

        public void MyPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseLeftButtonDown)
            {
                if (_picturePushRect.Contains(Control.MousePosition))
                {
                    Point _cPicturePushpoint = Cursor.Position;
                    var x = _cPicturePushpoint.X - _pPoint.X;
                    var y = _cPicturePushpoint.Y - _pPoint.Y;
                    _openDrawState.X += x;
                    _openDrawState.Y += y;
                    _pPoint = Cursor.Position;
                    //InitPushPictureRect();
                }
                else
                {
                    ControlMove();
                }
                InitPushPictureRect();
                InitStretchFrame();
                this.Invalidate();
                
                
            }

            if (_cursorIncoChangeRect[0].Contains(Control.MousePosition) || _cursorIncoChangeRect[1].Contains(Control.MousePosition))
            {
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_ew.cur");
                SetSystemCursor(cur, 32512);
            }
            else if (_cursorIncoChangeRect[2].Contains(Control.MousePosition) || _cursorIncoChangeRect[3].Contains(Control.MousePosition))
            {
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_ns.cur");
                SetSystemCursor(cur, 32512);
            }
            else if (_cursorIncoChangeRect[4].Contains(Control.MousePosition) || _cursorIncoChangeRect[7].Contains(Control.MousePosition))
            {
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_nwse.cur");
                SetSystemCursor(cur, 32512);
            }
            else if (_cursorIncoChangeRect[5].Contains(Control.MousePosition) || _cursorIncoChangeRect[6].Contains(Control.MousePosition))
            {
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_nesw.cur");
                SetSystemCursor(cur, 32512);
            }
            else
            {
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_arrow.cur");
                SetSystemCursor(cur, 32512);
            }
            Console.WriteLine("{0}", Control.MousePosition);
            Console.WriteLine("-------------{0}", this.Location);
            Console.WriteLine("--------------------------{0}", _stretchFrame[0]);
            
        }

        private void MyPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mouseLeftButtonDown == true)
            {
                _mouseLeftButtonDown = false;
                var cur = LoadCursorFromFile(@"C:\\Windows\\Cursors\\aero_arrow.cur");
                SetSystemCursor(cur, 32512);
            }
        }

        private void MyPictureBox_MouseEnter(object sender, EventArgs e)
        {

        }

        private void moveBoxEdgeTick_Tick(object sender, EventArgs e)
        {
            
        }

        #region 初始化拉伸边框矩形
        private void InitStretchFrame()
        {
            //当鼠标放置在控件左边缘
            _stretchFrame[0] = new Rectangle(this.Location.X - 5, this.Location.Y + 15, 20, this.Size.Height - 30);
            //当鼠标放置在控件右边缘
            _stretchFrame[1] = new Rectangle(this.Location.X + this.Size.Width - 15, this.Location.Y + 15, 20, this.Size.Height - 30);
            //当鼠标放置在控件上边缘
            _stretchFrame[2] = new Rectangle(this.Location.X + 15, this.Location.Y - 5, this.Size.Width - 30, 20);
            //当鼠标放置在控件下边缘
            _stretchFrame[3] = new Rectangle(this.Location.X + 15, this.Location.Y + this.Size.Height - 15, this.Size.Width - 30, 20);
            //当鼠标放置在控件左上角
            _stretchFrame[4] = new Rectangle(this.Location.X - 5, this.Location.Y - 5, 20, 20);
            //当鼠标放置在控件右上角
            _stretchFrame[5] = new Rectangle(this.Location.X + this.Size.Width - 15, this.Location.Y - 5, 20, 20);
            //当鼠标放置在控件左下角
            _stretchFrame[6] = new Rectangle(this.Location.X - 5, this.Location.Y + this.Size.Height - 15, 20, 20);
            //当鼠标放置在控件右下角
            _stretchFrame[7] = new Rectangle(this.Location.X + this.Size.Width - 15, this.Location.Y + this.Size.Height - 15, 20, 20);

            //在此矩形框内鼠标图标变化
            _cursorIncoChangeRect[0] = new Rectangle(this.Location.X, this.Location.Y + 15, 2, this.Size.Height - 30);
            _cursorIncoChangeRect[1] = new Rectangle(this.Location.X + this.Size.Width - 2, this.Location.Y + 15, 2, this.Size.Height - 30);
            _cursorIncoChangeRect[2] = new Rectangle(this.Location.X + 15, this.Location.Y, this.Size.Width - 30, 2);
            _cursorIncoChangeRect[3] = new Rectangle(this.Location.X + 15, this.Location.Y + this.Size.Height - 2, this.Size.Width - 30, 2);
            _cursorIncoChangeRect[4] = new Rectangle(this.Location.X, this.Location.Y, 10, 10);
            _cursorIncoChangeRect[5] = new Rectangle(this.Location.X + this.Size.Width - 10, this.Location.Y, 10, 10);
            _cursorIncoChangeRect[6] = new Rectangle(this.Location.X, this.Location.Y + this.Size.Height - 10, 10, 10);
            _cursorIncoChangeRect[7] = new Rectangle(this.Location.X + this.Size.Width - 10, this.Location.Y + this.Size.Height - 10, 10, 10);
      

        }
        #endregion

        private void InitPushPictureRect()
        {
            _picturePushRect = new Rectangle(this.Location.X + 16, this.Location.Y + 16, this.Size.Width - 32, this.Size.Height - 32);
        }

        #region 边框坐标变化
        private void ControlMove()
        {
            _cPoint = Cursor.Position;
            var x = _cPoint.X - _pPoint.X;
            var y = _cPoint.Y - _pPoint.Y;
            switch (this._mpoc)
            {
                case MousePosOnCtrl.TOP:
                    if (this.Height - y > 0)
                    {
                        this.Top += y;
                        this.Height -= y;
                    }
                    else
                    {
                        this.Top -= 10 - this.Height;
                        this.Height = 10;
                    }
                    break;
                case MousePosOnCtrl.BOTTOM:
                    if (this.Height + y > 10)
                    {
                        this.Height += y;
                    }
                    else
                    {
                        this.Height = 10;
                    }
                    break;
                case MousePosOnCtrl.LEFT:
                    if (this.Width - x > 10)
                    {
                        this.Left += x;
                        this.Width -= x;
                    }
                    else
                    {
                        this.Left -= 10 - this.Width;
                        this.Width = 10;
                    }

                    break;
                case MousePosOnCtrl.RIGHT:
                    if (this.Width + x > 10)
                    {
                        this.Width += x;
                    }
                    else
                    {
                        this.Width = 10;
                    }
                    break;
                case MousePosOnCtrl.TOPLEFT:
                    if (this.Height - y > 10)
                    {
                        this.Top += y;
                        this.Height -= y;
                    }
                    else
                    {
                        this.Top -= 10 - this.Height;
                        this.Height = 10;
                    }
                    if (this.Width - x > 10)
                    {
                        this.Left += x;
                        this.Width -= x;
                    }
                    else
                    {
                        this.Left -= 10 - this.Width;
                        this.Width = 10;
                    }
                    break;
                case MousePosOnCtrl.TOPRIGHT:
                    if (this.Height - y > 10)
                    {
                        this.Top += y;
                        this.Height -= y;
                    }
                    else
                    {
                        this.Top -= 10 - this.Height;
                        this.Height = 10;
                    }
                    if (this.Width + x > 10)
                    {
                        this.Width += x;
                    }
                    else
                    {
                        this.Width = 10;
                    }
                    break;
                case MousePosOnCtrl.BOTTOMLEFT:
                    if (this.Height + y > 10)
                    {
                        this.Height += y;
                    }
                    else
                    {
                        this.Height = 10;
                    }
                    if (this.Width - x > 10)
                    {
                        this.Left += x;
                        this.Width -= x;
                    }
                    else
                    {
                        this.Left -= 10 - this.Width;
                        this.Width = 10;
                    }
                    break;
                case MousePosOnCtrl.BOTTOMRIGHT:
                    if (this.Height + y > 10)
                    {
                        this.Height += y;
                    }
                    else
                    {
                        this.Height = 10;
                    }
                    if (this.Width + x > 10)
                    {
                        this.Width += x;
                    }
                    else
                    {
                        this.Width = 10;
                    }
                    break;

            }
            _pPoint = Cursor.Position;
        }
        #endregion

        #region 按下鼠标移动图片位置

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

        public bool InitGetImage(Image img)
        {
            
            _nowEditImage = img;
            Graphics g = this.CreateGraphics();
            if (_nowEditImage != null)
            {
                if (_openDrawState.Width == 0)
                {
                    _openDrawState = new Rectangle(0, 0, _nowEditImage.Width, _nowEditImage.Height);
                }
                else
                {
                    _openDrawState = new Rectangle(_openDrawState.X, _openDrawState.Y, _nowEditImage.Width, _nowEditImage.Height);
                }
                g.DrawImage(_nowEditImage, _openDrawState);
                Invalidate();
                return true;
            }
            return false;
        }

        public bool InitToCutPicture(int x, int y, int width, int height)
        {
            if (x > _nowEditImage.Width || x < 0 || y < 0 || y > _nowEditImage.Height)
                return false;
   
            _myCutBitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(_myCutBitmap);
            g.DrawImage(_nowEditImage, x, y, width, height);
            g.Dispose();

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
            if (ampli > 0 && ampli <100)
            {
                _amplitude = ampli;
            }
            else
            {
                MessageBox.Show("图片动画幅度出错！");
            }
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
                e.Graphics.DrawImage(_myCutBitmap, _nowDrawState.X, _nowDrawState.Y, _nowDrawState.Width, _nowDrawState.Height);
            }
            else
            {
                if (_nowEditImage != null)
                    e.Graphics.DrawImage(_nowEditImage, _openDrawState);
            }

            Pen pen = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(pen,  0, 0, this.Width-1, this.Height-1);
        }

        private void MyPictureBox_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            //this.
            InitStretchFrame();
            InitPushPictureRect();
        }

        public void MoveToCenter()
        {
            var mainScreenRect = Screen.PrimaryScreen.WorkingArea;
            var screencenter = new Point(mainScreenRect.Width/2, mainScreenRect.Height/2);

            this.Location = new Point(screencenter.X-this.Width/2, screencenter.Y-this.Height/2);
            InitPushPictureRect();
            InitStretchFrame();
            this.Invalidate();
        }
    }
}
