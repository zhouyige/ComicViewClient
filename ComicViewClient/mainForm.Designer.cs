namespace ComicViewClient
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            //得到屏幕宽高值
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.closeButton = new ComicViewClient.UserControlButton1();
            this.mainformEditButton = new ComicViewClient.UserControlButton2();
            this.mainformViewButton = new ComicViewClient.UserControlButton2();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackImage = global::ComicViewClient.Properties.Resources.X2;
            this.closeButton.BaseColor = System.Drawing.Color.Red;
            this.closeButton.ButtonText = null;
            this.closeButton.CornerRadius = 0;
            this.closeButton.GlowAlpha = 0;
            this.closeButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.closeButton.Location = new System.Drawing.Point(screenWidth/2+210, screenHeight/2-100);
            this.closeButton.Name = "closeButton";
            this.closeButton.OrdinaryAlpha = 0;
            this.closeButton.PressedAlpha = 100;
            this.closeButton.PressedKey = System.Windows.Forms.Keys.E;
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.Click += new System.EventHandler(closeButton_Click);
            this.closeButton.TabIndex = 0;
            // 
            // mainformEditButton
            // 
            this.mainformEditButton.BackColor = System.Drawing.Color.Red;
            this.mainformEditButton.BackImage = global::ComicViewClient.Properties.Resources.编辑;
            this.mainformEditButton.ButtonText = null;
            this.mainformEditButton.CornerRadius = 0;
            this.mainformEditButton.DrawWidth = 200;
            this.mainformEditButton.GlowAlpha = 0;
            this.mainformEditButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.mainformEditButton.LeftDrawHeight = 200;
            this.mainformEditButton.Location = new System.Drawing.Point(screenWidth / 2 + 10, screenHeight / 2 - 100);
            this.mainformEditButton.MouseDownImage = global::ComicViewClient.Properties.Resources.编辑;
            this.mainformEditButton.MouseDownImageX = 300;
            this.mainformEditButton.MouseDownImageY = 300;
            this.mainformEditButton.MyGraphics = this.CreateGraphics();
            this.mainformEditButton.Name = "mainformEditButton";
            this.mainformEditButton.OrdinaryAlpha = 0;
            this.mainformEditButton.PressedAlpha = 100;
            this.mainformEditButton.PressedKey = System.Windows.Forms.Keys.E;
            this.mainformEditButton.RightDrawHeight = 200;
            this.mainformEditButton.Size = new System.Drawing.Size(200, 200);
            this.mainformEditButton.Click += new System.EventHandler(mainformEditButton_Click);
            this.mainformEditButton.TabIndex = 0;
            //
            // mainformViewButton
            // 
            this.mainformViewButton.BackColor = System.Drawing.Color.Red;
            this.mainformViewButton.BackImage = global::ComicViewClient.Properties.Resources.阅读;
            this.mainformViewButton.ButtonText = null;
            this.mainformViewButton.CornerRadius = 0;
            this.mainformViewButton.DrawWidth = 200;
            this.mainformViewButton.GlowAlpha = 0;
            this.mainformViewButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.mainformViewButton.LeftDrawHeight = 200;
            this.mainformViewButton.Location = new System.Drawing.Point(screenWidth/2-210, screenHeight/2-100);
            this.mainformViewButton.MouseDownImage = global::ComicViewClient.Properties.Resources.阅读;
            this.mainformViewButton.MouseDownImageX = 300;
            this.mainformViewButton.MouseDownImageY = 300;
            this.mainformViewButton.MyGraphics = this.CreateGraphics();
            this.mainformViewButton.Name = "mainformEditButton";
            this.mainformViewButton.OrdinaryAlpha = 0;
            this.mainformViewButton.PressedAlpha = 100;
            this.mainformViewButton.PressedKey = System.Windows.Forms.Keys.E;
            this.mainformViewButton.RightDrawHeight = 200;
            this.mainformViewButton.Size = new System.Drawing.Size(200, 200);
            this.mainformViewButton.Click += new System.EventHandler(mainformViewButton_Click);
            this.mainformViewButton.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.mainformEditButton);
            this.Controls.Add(this.mainformViewButton);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ComicViewClient.Properties.Settings.Default, "showform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::ComicViewClient.Properties.Settings.Default.showform;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ComicViewClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
        }
        #endregion

        private UserControlButton1 closeButton ;
        private UserControlButton2 mainformEditButton;
        private UserControlButton2 mainformViewButton;
    }
}

