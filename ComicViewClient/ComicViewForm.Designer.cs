namespace ComicViewClient
{
    partial class ComicViewForm
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
            this.components = new System.ComponentModel.Container();
            this.PictureViewBox = new ComicViewClient.MyPictureViewBox();
            this.backToMainFormButton = new ComicViewClient.UserControlButton1();
            this.appCloseButton = new ComicViewClient.UserControlButton1();
            this.formMinisizeButton = new ComicViewClient.UserControlButton1();
            this.openCvdFileButton = new ComicViewClient.UserControlButton1();
            this.playorPauseButton = new ComicViewClient.UserControlButton1();
            this.toNextPictureButton = new ComicViewClient.UserControlButton1();
            this.toLastPictureButton = new ComicViewClient.UserControlButton1();
            this.bookmarkButton = new ComicViewClient.UserControlButton1();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PictureViewBox
            // 
            this.PictureViewBox.BackColor = System.Drawing.Color.Transparent;
            this.PictureViewBox.Location = new System.Drawing.Point(300, 100);
            this.PictureViewBox.Name = "PictureViewBox";
            this.PictureViewBox.Size = new System.Drawing.Size(639, 484);
            this.PictureViewBox.TabIndex = 3;
            // 
            // backToMainFormButton
            // 
            this.backToMainFormButton.BackColor = System.Drawing.Color.Snow;
            this.backToMainFormButton.BaseColor = System.Drawing.Color.Red;
            this.backToMainFormButton.ButtonText = "←";
            this.backToMainFormButton.CornerRadius = 0;
            this.backToMainFormButton.GlowAlpha = 0;
            this.backToMainFormButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.backToMainFormButton.Location = new System.Drawing.Point(1326, 75);
            this.backToMainFormButton.Name = "backToMainFormButton";
            this.backToMainFormButton.OrdinaryAlpha = 0;
            this.backToMainFormButton.PressedAlpha = 100;
            this.backToMainFormButton.PressedKey = System.Windows.Forms.Keys.E;
            this.backToMainFormButton.Size = new System.Drawing.Size(40, 25);
            this.backToMainFormButton.TabIndex = 0;
            this.backToMainFormButton.Click += new System.EventHandler(this.backToMainFormButton_Click);
            // 
            // appCloseButton
            // 
            this.appCloseButton.BackColor = System.Drawing.Color.Snow;
            this.appCloseButton.BaseColor = System.Drawing.Color.Red;
            this.appCloseButton.ButtonText = "×";
            this.appCloseButton.CornerRadius = 0;
            this.appCloseButton.GlowAlpha = 0;
            this.appCloseButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.appCloseButton.Location = new System.Drawing.Point(1346, 55);
            this.appCloseButton.Name = "appCloseButton";
            this.appCloseButton.OrdinaryAlpha = 0;
            this.appCloseButton.PressedAlpha = 100;
            this.appCloseButton.PressedKey = System.Windows.Forms.Keys.E;
            this.appCloseButton.Size = new System.Drawing.Size(20, 20);
            this.appCloseButton.TabIndex = 0;
            this.appCloseButton.Click += new System.EventHandler(this.appCloseButton_Click);
            // 
            // formMinisizeButton
            // 
            this.formMinisizeButton.BackColor = System.Drawing.Color.Snow;
            this.formMinisizeButton.BaseColor = System.Drawing.Color.Red;
            this.formMinisizeButton.ButtonText = "－";
            this.formMinisizeButton.CornerRadius = 0;
            this.formMinisizeButton.GlowAlpha = 0;
            this.formMinisizeButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.formMinisizeButton.Location = new System.Drawing.Point(1326, 55);
            this.formMinisizeButton.Name = "formMinisizeButton";
            this.formMinisizeButton.OrdinaryAlpha = 0;
            this.formMinisizeButton.PressedAlpha = 100;
            this.formMinisizeButton.PressedKey = System.Windows.Forms.Keys.E;
            this.formMinisizeButton.Size = new System.Drawing.Size(20, 20);
            this.formMinisizeButton.TabIndex = 0;
            this.formMinisizeButton.Click += new System.EventHandler(this.formMinisizeButton_Click);
            // 
            // openCvdFileButton
            // 
            this.openCvdFileButton.BackColor = System.Drawing.Color.Transparent;
            this.openCvdFileButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.openCvdFileButton.BaseColor = System.Drawing.Color.Red;
            this.openCvdFileButton.ButtonText = "打开";
            this.openCvdFileButton.CornerRadius = 0;
            this.openCvdFileButton.GlowAlpha = 0;
            this.openCvdFileButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.openCvdFileButton.Location = new System.Drawing.Point(2, 582);
            this.openCvdFileButton.Name = "openCvdFileButton";
            this.openCvdFileButton.OrdinaryAlpha = 0;
            this.openCvdFileButton.PressedAlpha = 100;
            this.openCvdFileButton.PressedKey = System.Windows.Forms.Keys.E;
            this.openCvdFileButton.Size = new System.Drawing.Size(80, 30);
            this.openCvdFileButton.TabIndex = 0;
            this.openCvdFileButton.Click += new System.EventHandler(this.openCvdFileButton_Click);
            // 
            // playorPauseButton
            // 
            this.playorPauseButton.BackColor = System.Drawing.Color.Transparent;
            this.playorPauseButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.playorPauseButton.BaseColor = System.Drawing.Color.Red;
            this.playorPauseButton.ButtonText = "播放";
            this.playorPauseButton.CornerRadius = 0;
            this.playorPauseButton.GlowAlpha = 0;
            this.playorPauseButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.playorPauseButton.Location = new System.Drawing.Point(2, 618);
            this.playorPauseButton.Name = "playorPauseButton";
            this.playorPauseButton.OrdinaryAlpha = 0;
            this.playorPauseButton.PressedAlpha = 100;
            this.playorPauseButton.PressedKey = System.Windows.Forms.Keys.E;
            this.playorPauseButton.Size = new System.Drawing.Size(80, 30);
            this.playorPauseButton.TabIndex = 0;
            this.playorPauseButton.Click += new System.EventHandler(this.playorPauseButton_Click);
            // 
            // toNextPictureButton
            // 
            this.toNextPictureButton.BackColor = System.Drawing.Color.Transparent;
            this.toNextPictureButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.toNextPictureButton.BaseColor = System.Drawing.Color.Red;
            this.toNextPictureButton.ButtonText = "下一页";
            this.toNextPictureButton.CornerRadius = 0;
            this.toNextPictureButton.GlowAlpha = 0;
            this.toNextPictureButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.toNextPictureButton.Location = new System.Drawing.Point(2, 690);
            this.toNextPictureButton.Name = "toNextPictureButton";
            this.toNextPictureButton.OrdinaryAlpha = 0;
            this.toNextPictureButton.PressedAlpha = 100;
            this.toNextPictureButton.PressedKey = System.Windows.Forms.Keys.E;
            this.toNextPictureButton.Size = new System.Drawing.Size(80, 30);
            this.toNextPictureButton.TabIndex = 0;
            // 
            // toLastPictureButton
            // 
            this.toLastPictureButton.BackColor = System.Drawing.Color.Transparent;
            this.toLastPictureButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.toLastPictureButton.BaseColor = System.Drawing.Color.Red;
            this.toLastPictureButton.ButtonText = "上一页";
            this.toLastPictureButton.CornerRadius = 0;
            this.toLastPictureButton.GlowAlpha = 0;
            this.toLastPictureButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.toLastPictureButton.Location = new System.Drawing.Point(2, 654);
            this.toLastPictureButton.Name = "toLastPictureButton";
            this.toLastPictureButton.OrdinaryAlpha = 0;
            this.toLastPictureButton.PressedAlpha = 100;
            this.toLastPictureButton.PressedKey = System.Windows.Forms.Keys.E;
            this.toLastPictureButton.Size = new System.Drawing.Size(80, 30);
            this.toLastPictureButton.TabIndex = 0;
            // 
            // bookmarkButton
            // 
            this.bookmarkButton.BackColor = System.Drawing.Color.Transparent;
            this.bookmarkButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.bookmarkButton.BaseColor = System.Drawing.Color.Red;
            this.bookmarkButton.ButtonText = "书签";
            this.bookmarkButton.CornerRadius = 0;
            this.bookmarkButton.GlowAlpha = 0;
            this.bookmarkButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.bookmarkButton.Location = new System.Drawing.Point(2, 726);
            this.bookmarkButton.Name = "bookmarkButton";
            this.bookmarkButton.OrdinaryAlpha = 0;
            this.bookmarkButton.PressedAlpha = 100;
            this.bookmarkButton.PressedKey = System.Windows.Forms.Keys.E;
            this.bookmarkButton.Size = new System.Drawing.Size(80, 30);
            this.bookmarkButton.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComicViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.PictureViewBox);
            this.Controls.Add(this.backToMainFormButton);
            this.Controls.Add(this.appCloseButton);
            this.Controls.Add(this.formMinisizeButton);
            this.Controls.Add(this.openCvdFileButton);
            this.Controls.Add(this.playorPauseButton);
            this.Controls.Add(this.toNextPictureButton);
            this.Controls.Add(this.toLastPictureButton);
            this.Controls.Add(this.bookmarkButton);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ComicViewClient.Properties.Settings.Default, "showform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::ComicViewClient.Properties.Settings.Default.showform;
            this.Name = "ComicViewForm";
            this.Text = "ComicViewForm";
            this.Load += new System.EventHandler(this.ComicViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        MyPictureViewBox PictureViewBox;
        private UserControlButton1 backToMainFormButton;
        private UserControlButton1 appCloseButton;
        private UserControlButton1 formMinisizeButton;

        private UserControlButton1 openCvdFileButton;
        private UserControlButton1 playorPauseButton;
        private UserControlButton1 toNextPictureButton;
        private UserControlButton1 toLastPictureButton;
        private UserControlButton1 bookmarkButton;
        private System.Windows.Forms.Timer timer1;

        //UserControlButton1 

    }
}