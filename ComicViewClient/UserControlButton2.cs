using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ComicViewClient
{
    class UserControlButton2 : UserControl
    {
                enum State { None, Hover, Pressed };

        private bool calledbykey = false;
        private State mButtonState = State.None;
        private Timer mFadeIn = new Timer();
        private Timer mFadeOut = new Timer();
        //private Timer mMouseDownTimer = new Timer();
        private int mGlowAlpha = 0;
        
        private System.ComponentModel.Container components = null;

        public UserControlButton2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.BackColor = Color.Transparent;
            mFadeIn.Interval = 20;
            mFadeOut.Interval = 20;
            //mMouseDownTimer.Interval = 20;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.Name = "MyControlButton1";
            this.Size = new System.Drawing.Size(100, 100);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Button_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
            this.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.MouseUp += new MouseEventHandler(Button_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.GotFocus += new EventHandler(Button_MouseEnter);
            this.LostFocus += new EventHandler(Button_MouseLeave);
            this.mFadeIn.Tick += new EventHandler(mFadeIn_Tick);
            this.mFadeOut.Tick += new EventHandler(mFadeOut_Tick);
            //this.mMouseDownTimer.Tick += new EventHandler(MouseDownTimer_Tick);
            this.Resize += new EventHandler(Button_Resize);
            //this.Click += new EventHandler(Button_Click);

        }
        //保存绘制mMouseDownImage的坐标 以及 LeftHeight，RightHeight，DrawWidth属性
        private int mMouseDownImageX = 0;
        public int MouseDownImageX
        {
            get { return mMouseDownImageX; }
            set { mMouseDownImageX = value; this.Invalidate(); }
        }
        private int mMouseDownImageY = 0;
        public int MouseDownImageY
        {
            get { return mMouseDownImageY; }
            set { mMouseDownImageY = value; this.Invalidate(); }
        }
        private int mLeftDrawHeight = 0;
        public int LeftDrawHeight
        {
            get { return mLeftDrawHeight; }
            set { mLeftDrawHeight = value; this.Invalidate(); }
        }
        private int mRightDrawHeight = 0;
        public int RightDrawHeight
        {
            get { return mRightDrawHeight; }
            set { mRightDrawHeight = value; this.Invalidate(); }
        }
        private int mDrawWidth = 0;
        public int DrawWidth
        {
            get { return mDrawWidth; }
            set { mDrawWidth = value; this.Invalidate(); }
        }
        //保存from类Graphics
        private Graphics mMyGraphics;
        public Graphics MyGraphics
        {
            get { return mMyGraphics; }
            set { mMyGraphics = value; this.Invalidate(); }
        }
        //鼠标左键按下后动画图片
        private Image mMouseDownImage = null;
        public Image MouseDownImage
        {
            get { return mMouseDownImage; }
            set { mMouseDownImage = value; this.Invalidate(); }
        }
        //炫光Alpha
        public int GlowAlpha
        {
            get { return mGlowAlpha; }
            set { mGlowAlpha = value; Invalidate(); }
        }
        //设置响应按钮的按键
        private Keys mMyPressedKey;
        public Keys PressedKey
        {
            get { return mMyPressedKey; }
            set { mMyPressedKey = value; Invalidate(); }
        }
        //按钮alpha        
        private int mPressedAlpha = 204;
        private int mOrdinaryAlpha = 127;
        public int OrdinaryAlpha
        {
            get { return mOrdinaryAlpha; }
            set { mOrdinaryAlpha = value; this.Invalidate(); }
        }
        public int PressedAlpha
        {
            get { return mPressedAlpha; }
            set { mPressedAlpha = value; this.Invalidate(); }
        }
        //按钮样式
        public enum Style
        {
            Default = 0,
            Flat = 1,
        };
        // 用于设置按钮的用处
        //public enum UseTo
        //{
        //    Min, Close
        //};
        //UseTo Ut = UseTo.Close;    //默认作为关闭按钮
        //[Category("UseTo"),
        // DefaultValue(UseTo.Close),
        // Browsable(true),
        // Description("设置按钮的用处")]
        //public UseTo UT
        //{
        //    get
        //    {
        //        return Ut;
        //    }
        //    set
        //    {
        //        Ut = value;
        //        this.Invalidate();
        //    }
        //}
      
        // 按钮上显示的文本
        private string mText;
        [Category("Text"),
         Description("按钮上显示的文本.")]
        public string ButtonText
        {
            get { return mText; }
            set { mText = value; this.Invalidate(); }
        }
        // 文本颜色
        private Color mForeColor = Color.White;
        [Category("Text"),
         Browsable(true),
         DefaultValue(typeof(Color), "White"),
         Description("文本颜色.")]
        public override Color ForeColor
        {
            get { return mForeColor; }
            set { mForeColor = value; this.Invalidate(); }
        }       
        // 文本对齐方式
        private ContentAlignment mTextAlign = ContentAlignment.MiddleCenter;
        [Category("Text"),
         DefaultValue(typeof(ContentAlignment), "MiddleCenter"),
         Description("The alignment of the button text " +
                     "that is displayed on the control.")]
        public ContentAlignment TextAlign
        {
            get { return mTextAlign; }
            set { mTextAlign = value; this.Invalidate(); }
        }
        //按钮的图片
        private Image mImage;
        [Category("Image"),
        DefaultValue(null),
        Description("显示在按钮上的图片")]
        public Image Image
        {
            get { return mImage; }
            set { mImage = value; this.Invalidate(); }
        }
        //图片对齐方式
        private ContentAlignment mImageAlign = ContentAlignment.MiddleLeft;
        [Category("Image"),
        DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
        Description("按钮上图片对齐方式")]

        public ContentAlignment ImageAlign
        {
            get { return mImageAlign; }
            set { mImageAlign = value; this.Invalidate(); }
        }
        //图片大小
        private Size mImageSize = new Size(24, 24);
        [Category("Image"),
        DefaultValue(typeof(Size), "24,24"),
        Description("按钮上图片的尺寸")]
        public Size ImageSize
        {
            get { return mImageSize; }
            set { mImageSize = value; this.Invalidate(); }
        }
        //
        private Style mButtonStyle = Style.Default;
        [Category("Appearance"),
         DefaultValue(typeof(Style), "Default"),
         Description("Sets whether the button background is drawn " +
                     "while the mouse is outside of the client area.")]
        public Style ButtonStyle
        {
            get { return mButtonStyle; }
            set { mButtonStyle = value; this.Invalidate(); }
        }
        //设置按键四角圆滑半径
        private int mCornerRadius = 3;
        [Category("Appearance"),
         DefaultValue(8),
         Description("The radius for the button corners. The " +
                     "greater this value is, the more 'smooth' " +
                     "the corners are. This property should " +
                     "not be greater than half of the " +
                     "controls height.")]
        public int CornerRadius
        {
            get { return mCornerRadius; }
            set { mCornerRadius = value; this.Invalidate(); }
        }
        //设置按钮上半部分高光颜色
        //private Color mHighlightColor = Color.Gray;
        //[Category("Appearance"),
        // DefaultValue(typeof(Color), "White"),
        // Description("设置按钮上半部分高光颜色")]
        //public Color HighlightColor
        //{
        //    get { return mHighlightColor; }
        //    set { mHighlightColor = value; this.Invalidate(); }
        //}
        

        //按钮外框线条颜色
        private Color mButtonColor = Color.Black;
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The bottom color of the button that " +
                     "will be drawn over the base color.")]
        public Color ButtonColor
        {
            get { return mButtonColor; }
            set { mButtonColor = value; this.Invalidate(); }
        }

        private Color mGlowColor = Color.FromArgb(141, 189, 255);
        // 鼠标移上去之后显示的颜色
        [Category("Appearance"),
         DefaultValue(typeof(Color), "141,189,255"),
         Description("The colour that the button glows when " +
                     "the mouse is inside the client area.")]
        public Color GlowColor
        {
            get { return mGlowColor; }
            set { mGlowColor = value; this.Invalidate(); }
        }
        //按钮背景图片
        private Image mBackImage;
        [Category("Appearance"),
         DefaultValue(null), 
         Description("The background image for the button, " +
                     "this image is drawn over the base " +
                     "color of the button.")]
        public Image BackImage
        {
            get { return mBackImage; }
            set { mBackImage = value; this.Invalidate(); }
        }
        //
        private static Color mBaseColor = Color.Black;
        [Category("Appearance"),
         DefaultValue(typeof(Color), "Black"),
         Description("The backing color that the rest of" +
                     "the button is drawn. For a glassier " +
                     "effect set this property to Transparent.")]
        public Color BaseColor
        {
            get { return mBaseColor; }
            set { mBaseColor = value; this.Invalidate(); }
        }
        // 按钮的形状
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }
        // 对齐方式
        private StringFormat StringFormatAlignment(ContentAlignment textalign)
        {
            StringFormat sf = new StringFormat();
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (textalign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }
        // 画出按钮的外框线条
        private void DrawOuterStroke(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            Rectangle r = this.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (Pen p = new Pen(this.ButtonColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }
        // 画出按钮的内框线条
        //private void DrawInnerStroke(Graphics g)
        //{
        //    if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
        //    Rectangle r = this.ClientRectangle;
        //    r.X++;
        //    r.Y++;
        //    r.Width -= 3;
        //    r.Height -= 3;
        //    using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
        //    {
        //        using (Pen p = new Pen(this.HighlightColor))
        //        {
        //            g.DrawPath(p, rr);
        //        }
        //    }
        //}
        // 画出按钮的背景
        private void DrawBackground(Graphics g)
        {
            if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
            int alpha = (mButtonState == State.Pressed) ?  mPressedAlpha : mOrdinaryAlpha;
            Rectangle r = this.ClientRectangle;
            r.Width--;
            r.Height--;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (SolidBrush sb = new SolidBrush(this.BaseColor))
                {
                    g.FillPath(sb, rr);
                }
                if (this.BackImage != null) 
                {
                    g.DrawImage(this.BackImage, this.ClientRectangle); 
                }
                g.ResetClip();
                using (SolidBrush sb = new SolidBrush(System.Drawing.Color.FromArgb(alpha, this.ButtonColor)))
                {
                    g.FillPath(sb, rr);
                }
            }
        }
        // 画出按钮的上半部分高光颜色
        ///暂时不添加
        //{
        //    if (this.ButtonStyle == Style.Flat && this.mButtonState == State.None) { return; }
        //    int alpha = (mButtonState == State.Pressed) ? 60 : 150;
        //    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height / 2);
        //    using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
        //    {
        //        using (LinearGradientBrush lg = new LinearGradientBrush(r.GetBounds(),
        //                                    Color.FromArgb(alpha, this.HighlightColor),
        //                                    Color.FromArgb(alpha / 3, this.HighlightColor),
        //                                    LinearGradientMode.Vertical))
        //        {
        //            g.FillPath(lg, r);
        //        }
        //    }
        //}

        // 当鼠标移上去的时候的炫光
        private void DrawGlow(Graphics g)
        {
            if (this.mButtonState == State.Pressed) { return; }
            using (GraphicsPath glow = new GraphicsPath())
            {
                Rectangle r = this.ClientRectangle;
                //r.Width -= 3; r.Height -= 3;
                glow.AddPath(RoundRect(new Rectangle(r.Left + 1, r.Top + 1, r.Width - 3, r.Height - 3), CornerRadius, CornerRadius, CornerRadius, CornerRadius), true);
                using (GraphicsPath gp = RoundRect(new Rectangle(r.Left + 1, r.Top + 1, r.Width - 3, r.Height / 2 - 2), CornerRadius, CornerRadius, CornerRadius, CornerRadius))
                {
                    Color c = Color.FromArgb(mGlowAlpha, this.GlowColor);
                   // Color c1 = Color.FromArgb(mGlowAlpha / 2 + 50, Color.White);
                    using (SolidBrush sb = new SolidBrush(c))
                    {
                        //using (SolidBrush sb1 = new SolidBrush(c1))
                        //{
                        //    
                        //    g.FillPath(sb1, gp);
                        //}
                        g.FillPath(sb, glow);
                    }
                }
            }
            g.ResetClip();
        }
        // 显示按钮的文本
        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment(this.TextAlign);
            Rectangle r = new Rectangle(8, 8, this.Width - 17, this.Height - 17);
            g.DrawString(this.ButtonText, this.Font, new SolidBrush(this.ForeColor), r, sf);
        }
        //绘制事件
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(g);
            DrawGlow(g);
            //DrawInnerStroke(g);
        }
        //响应控件大小变化时按钮矩形变化
        private void Button_Resize(object sender, EventArgs e)
        {
            Rectangle r = this.ClientRectangle;
            r.X -= 1; r.Y -= 1;
            r.Width += 2; r.Height += 2;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                this.Region = new Region(rr);
            }
        }
        //当鼠标指针放在控件上响应事件
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            mButtonState = State.Hover;
            mFadeOut.Stop();
            mFadeIn.Start();
        }
        //鼠标离开控件
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            mButtonState = State.None;
            if (this.mButtonStyle == Style.Flat) { mGlowAlpha = 0; }
            mFadeIn.Stop();
            mFadeOut.Start();
        }
        //鼠标左键按下
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mButtonState = State.Pressed;
                if (this.mButtonStyle != Style.Flat) { mGlowAlpha = 0; }
                mFadeIn.Stop();
                mFadeOut.Stop();
                this.Invalidate();
            }
        }
        //鼠标移到控件上
        private void mFadeIn_Tick(object sender, EventArgs e)
        {
            if (this.ButtonStyle == Style.Flat) { mGlowAlpha = 0; }
            if (this.ClientRectangle.Width <= 180)
            {
                this.Size = new Size(180, 180);
                mFadeIn.Stop();
            }
            else
            {
                Height = this.Size.Height - 2;
                Width = this.Size.Width - 2;
                this.Size = new Size(Width, Height);
                Point p = this.Location;
                p.X++;
                p.Y++;
                this.Location = p;

            }
            this.Invalidate();
        }
       
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == mMyPressedKey)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                Button_MouseDown(sender, m);
                mGlowAlpha = 0;
            }
        }
        //鼠标离开控件
        private void mFadeOut_Tick(object sender, EventArgs e)
        {
            if (this.ButtonStyle == Style.Flat) { mGlowAlpha = 0; }
            if (this.ClientRectangle.Width >= 200)
            {
                this.Size = new Size(200, 200);
                mFadeOut.Stop();
            }
            else
            {
                Height = this.Size.Height + 2;
                Width = this.Size.Width + 2;
                this.Size = new Size(Width, Height);
                Point p = this.Location;
                p.X--;
                p.Y--;
                this.Location = p;
            }
            this.Invalidate();
        }
        //
        private void Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == mMyPressedKey)
            {
                MouseEventArgs m = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                calledbykey = true;
                Button_MouseUp(sender, m);
            }
        }
        //
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mButtonState = State.Hover;
                mFadeIn.Stop();
                mFadeOut.Stop();
                this.Invalidate();
                if (calledbykey == true) { this.OnClick(EventArgs.Empty); calledbykey = false; }
            }
        }
        //private void Button_Click(object sender, EventArgs e)
        //{
        //    mMouseDownTimer.Start();
        //}
        //private void MouseDownTimer_Tick(object sender, EventArgs e)
        //{
        //    if (mDrawWidth <= 10)
        //    {
        //        mDrawWidth = 200;
        //        mMouseDownTimer.Stop();
        //    }
        //    else
        //    {
        //        Bitmap _MyBitmap = new Bitmap(mMouseDownImage);
        //        _MyBitmap = ChangetoTrapezoid(_MyBitmap, mLeftDrawHeight, mRightDrawHeight, mDrawWidth);
        //        if (_MyBitmap == null) { System.Windows.Forms.MessageBox.Show("_MyBitmap == NULL "); }
        //        mMyGraphics.DrawImage(_MyBitmap, mMouseDownImageX, mMouseDownImageY, mLeftDrawHeight, mLeftDrawHeight);
        //        mLeftDrawHeight += 2;
        //        mDrawWidth -= 1;
        //        mMouseDownImageX += 1;
        //        mMouseDownImageY -= 1;
        //        //this.Invalidate();
        //    }
        //}
        [DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow(); 
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDc(IntPtr hwnd);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, Int32 dwRop);
        
        //使位图左长右窄
        public Bitmap ChangetoTrapezoid(Bitmap img, int drawLeftHeight, int drawRightHeight, int drawWidth)//drawWidth不能大于原图片的宽
        {
            int ImgWidth = img.Width;
            int ImgHeight = img.Height;
            Bitmap _NewBitmap = new Bitmap(drawLeftHeight, drawLeftHeight);
            Graphics g = Graphics.FromImage(_NewBitmap);
            int _difference = drawLeftHeight - drawRightHeight;
            double _imgWidthtoAvg = ImgWidth / drawWidth;

            if (_imgWidthtoAvg <= 0) { _imgWidthtoAvg = 1; }
            if (_difference < 0) { System.Windows.Forms.MessageBox.Show("左边高不能小于右边高"); }
            for (var i = 1; i <= drawWidth; i++)
            {
                Rectangle ol = new Rectangle((int)((i - 1) * _imgWidthtoAvg + _imgWidthtoAvg / 2 + 0.5) - 1, 0, 1, ImgHeight);
                if (ol.X > ImgWidth) { System.Windows.Forms.MessageBox.Show("图片获取出界"); }
                Rectangle ne = new Rectangle((int)(i - 1), (int)(((double)(_difference / 2) / (double)drawWidth) * i + 0.5), 1, drawLeftHeight - (int)(((double)(_difference / 2) / (double)drawWidth) * i + 0.5) * 2);
                g.DrawImage(img, ne, ol, GraphicsUnit.Pixel);
            }
            g.Dispose();
            return _NewBitmap;
        }
        public static Bitmap BothAlpha(Bitmap p_Bitmap, bool p_CentralTransparent, bool p_Crossdirection)
        {
            Bitmap _SetBitmap = new Bitmap(p_Bitmap.Width, p_Bitmap.Height);
            Graphics _GraphisSetBitmap = Graphics.FromImage(_SetBitmap);
            _GraphisSetBitmap.DrawImage(p_Bitmap, new Rectangle(0, 0, p_Bitmap.Width, p_Bitmap.Height));
            _GraphisSetBitmap.Dispose();

            Bitmap _Bitmap = new Bitmap(_SetBitmap.Width, _SetBitmap.Height);
            Graphics _Graphcis = Graphics.FromImage(_Bitmap);

            Point _Left1 = new Point(0, 0);
            Point _Left2 = new Point(_Bitmap.Width, 0);
            Point _Left3 = new Point(_Bitmap.Width, _Bitmap.Height / 2);
            Point _Left4 = new Point(0, _Bitmap.Height / 2);

            if (p_Crossdirection)
            {
                _Left1 = new Point(0, 0);
                _Left2 = new Point(_Bitmap.Width / 2, 0);
                _Left3 = new Point(_Bitmap.Width / 2, _Bitmap.Height);
                _Left4 = new Point(0, _Bitmap.Height);
            }

            Point[] _Point = new Point[] { _Left1, _Left2, _Left3, _Left4 };
            PathGradientBrush _SetBruhs = new PathGradientBrush(_Point, WrapMode.TileFlipY);

            _SetBruhs.CenterPoint = new PointF(0, 0);
            _SetBruhs.FocusScales = new PointF(_Bitmap.Width / 2, 0);
            _SetBruhs.CenterColor = Color.FromArgb(0, 0, 255, 255);
            _SetBruhs.SurroundColors = new Color[] { Color.FromArgb(255, 0, 255, 255) };
            if (p_Crossdirection)
            {
                _SetBruhs.FocusScales = new PointF(0, _Bitmap.Height);
                _SetBruhs.WrapMode = WrapMode.TileFlipX;
            }

            if (p_CentralTransparent)
            {
                _SetBruhs.CenterColor = Color.FromArgb(255, 255, 255, 255);
                _SetBruhs.SurroundColors = new Color[] { Color.FromArgb(0, 255, 255, 255) };
            }

            _Graphcis.FillRectangle(_SetBruhs, new Rectangle(0, 0, _Bitmap.Width, _Bitmap.Height));
            _Graphcis.Dispose();

            BitmapData _NewData = _Bitmap.LockBits(new Rectangle(0, 0, _Bitmap.Width, _Bitmap.Height), ImageLockMode.ReadOnly, _Bitmap.PixelFormat);
            byte[] _NewBytes = new byte[_NewData.Stride * _NewData.Height];
            Marshal.Copy(_NewData.Scan0, _NewBytes, 0, _NewBytes.Length);
            _Bitmap.UnlockBits(_NewData);

            BitmapData _SetData = _SetBitmap.LockBits(new Rectangle(0, 0, _SetBitmap.Width, _SetBitmap.Height), ImageLockMode.ReadWrite, _SetBitmap.PixelFormat);
            byte[] _SetBytes = new byte[_SetData.Stride * _SetData.Height];
            Marshal.Copy(_SetData.Scan0, _SetBytes, 0, _SetBytes.Length);

            int _WriteIndex = 0;

            for (int i = 0; i != _SetData.Height; i++)
            {
                _WriteIndex = i * _SetData.Stride + 3;
                for (int z = 0; z != _SetData.Width; z++)
                {
                    _SetBytes[_WriteIndex] = _NewBytes[_WriteIndex];
                    _WriteIndex += 4;
                }
            }

            Marshal.Copy(_SetBytes, 0, _SetData.Scan0, _SetBytes.Length);
            _SetBitmap.UnlockBits(_SetData);

            return _SetBitmap;

        }

        //private Image ChangeAlpha(Image image)
        //{

        //    Bitmap img = new Bitmap(image);

        //    using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
        //    {

        //        using (Graphics g = Graphics.FromImage(bmp))
        //        {

        //            g.DrawImage(img, 0, 0);

        //            for (int h = 0; h <= img.Height - 1; h++)
        //            {

        //                for (int w = 0; w <= img.Width - 1; w++)
        //                {
        //                    Color c = img.GetPixel(w, h);
        //                    bmp.SetPixel(w, h, Color.FromArgb(200, c.R, c.G, c.B));
        //                }

        //            }

        //            return (Image)bmp.Clone();

        //        }

        //    }

        //}
    }
}
