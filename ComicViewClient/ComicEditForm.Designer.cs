namespace ComicViewClient
{
    partial class ComicEditForm
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
            this.imagePopStyleLabel = new System.Windows.Forms.Label();
            this.moveButtonAnimationTick = new System.Windows.Forms.Timer(this.components);
            this.openNewCvdFileButton = new ComicViewClient.UserControlButton1();
            this.openImageFileButton = new ComicViewClient.UserControlButton1();
            this.enlargeImageButton = new ComicViewClient.UserControlButton1();
            this.shrinkImageButton = new ComicViewClient.UserControlButton1();
            this.imagePopStyleSetButton = new ComicViewClient.UserControlButton1();
            this.imagePopTimeSetButton = new ComicViewClient.UserControlButton1();
            this.savePresentPictureButton = new ComicViewClient.UserControlButton1();
            this.previewButton = new ComicViewClient.UserControlButton1();
            this.savePresentCvdFileButton = new ComicViewClient.UserControlButton1();
            this.backToMainFormButton = new ComicViewClient.UserControlButton1();
            this.appCloseButton = new ComicViewClient.UserControlButton1();
            this.formMinisizeButton = new ComicViewClient.UserControlButton1();
            this.imagePopStyleToLastButton = new ComicViewClient.UserControlButton1();
            this.imagePopStyleToNextButton = new ComicViewClient.UserControlButton1();
            this.imagePopTimeTextbox = new ComicViewClient.MyTextBox();
            this.pictureEditBox = new ComicViewClient.MyPictureBox();
            this.pictureBoxToCenterButton = new ComicViewClient.UserControlButton1();
            this.SuspendLayout();
            // 
            // imagePopStyleLabel
            // 
            this.imagePopStyleLabel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.imagePopStyleLabel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.imagePopStyleLabel.ForeColor = System.Drawing.Color.White;
            this.imagePopStyleLabel.Location = new System.Drawing.Point(1286, 220);
            this.imagePopStyleLabel.Name = "imagePopStyleLabel";
            this.imagePopStyleLabel.Size = new System.Drawing.Size(80, 30);
            this.imagePopStyleLabel.TabIndex = 2;
            this.imagePopStyleLabel.Text = "直接打开";
            this.imagePopStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moveButtonAnimationTick
            // 
            this.moveButtonAnimationTick.Interval = 10;
            this.moveButtonAnimationTick.Tick += new System.EventHandler(this.moveButtonAnimationTick_Tick);
            // 
            // openNewCvdFileButton
            // 
            this.openNewCvdFileButton.BackColor = System.Drawing.Color.Transparent;
            this.openNewCvdFileButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.openNewCvdFileButton.BaseColor = System.Drawing.Color.Red;
            this.openNewCvdFileButton.ButtonText = "创建新卷";
            this.openNewCvdFileButton.CornerRadius = 0;
            this.openNewCvdFileButton.GlowAlpha = 0;
            this.openNewCvdFileButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.openNewCvdFileButton.Location = new System.Drawing.Point(1286, 100);
            this.openNewCvdFileButton.Name = "openNewCvdFileButton";
            this.openNewCvdFileButton.OrdinaryAlpha = 0;
            this.openNewCvdFileButton.PressedAlpha = 100;
            this.openNewCvdFileButton.PressedKey = System.Windows.Forms.Keys.E;
            this.openNewCvdFileButton.Size = new System.Drawing.Size(80, 30);
            this.openNewCvdFileButton.TabIndex = 0;
            this.openNewCvdFileButton.Click += new System.EventHandler(this.openNewCvdFileButton_Click);
            // 
            // openImageFileButton
            // 
            this.openImageFileButton.BackColor = System.Drawing.Color.Transparent;
            this.openImageFileButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.openImageFileButton.BaseColor = System.Drawing.Color.Red;
            this.openImageFileButton.ButtonText = "打开图片";
            this.openImageFileButton.CornerRadius = 0;
            this.openImageFileButton.GlowAlpha = 0;
            this.openImageFileButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.openImageFileButton.Location = new System.Drawing.Point(1286, 130);
            this.openImageFileButton.Name = "openImageFileButton";
            this.openImageFileButton.OrdinaryAlpha = 0;
            this.openImageFileButton.PressedAlpha = 100;
            this.openImageFileButton.PressedKey = System.Windows.Forms.Keys.E;
            this.openImageFileButton.Size = new System.Drawing.Size(80, 30);
            this.openImageFileButton.TabIndex = 0;
            this.openImageFileButton.Click += new System.EventHandler(this.openImageFileButton_Click);
            // 
            // enlargeImageButton
            // 
            this.enlargeImageButton.BackColor = System.Drawing.Color.Transparent;
            this.enlargeImageButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.enlargeImageButton.BaseColor = System.Drawing.Color.Red;
            this.enlargeImageButton.ButtonText = "放大图片";
            this.enlargeImageButton.CornerRadius = 0;
            this.enlargeImageButton.GlowAlpha = 0;
            this.enlargeImageButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.enlargeImageButton.Location = new System.Drawing.Point(1286, 160);
            this.enlargeImageButton.Name = "enlargeImageButton";
            this.enlargeImageButton.OrdinaryAlpha = 0;
            this.enlargeImageButton.PressedAlpha = 100;
            this.enlargeImageButton.PressedKey = System.Windows.Forms.Keys.E;
            this.enlargeImageButton.Size = new System.Drawing.Size(80, 30);
            this.enlargeImageButton.TabIndex = 0;
            this.enlargeImageButton.Click += new System.EventHandler(this.enlargeImageButton_Click);
            // 
            // shrinkImageButton
            // 
            this.shrinkImageButton.BackColor = System.Drawing.Color.Transparent;
            this.shrinkImageButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.shrinkImageButton.BaseColor = System.Drawing.Color.Red;
            this.shrinkImageButton.ButtonText = "缩小图片";
            this.shrinkImageButton.CornerRadius = 0;
            this.shrinkImageButton.GlowAlpha = 0;
            this.shrinkImageButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.shrinkImageButton.Location = new System.Drawing.Point(1286, 190);
            this.shrinkImageButton.Name = "shrinkImageButton";
            this.shrinkImageButton.OrdinaryAlpha = 0;
            this.shrinkImageButton.PressedAlpha = 100;
            this.shrinkImageButton.PressedKey = System.Windows.Forms.Keys.E;
            this.shrinkImageButton.Size = new System.Drawing.Size(80, 30);
            this.shrinkImageButton.TabIndex = 0;
            this.shrinkImageButton.Click += new System.EventHandler(this.shrinkImageButton_Click);
            // 
            // imagePopStyleSetButton
            // 
            this.imagePopStyleSetButton.BackColor = System.Drawing.Color.Transparent;
            this.imagePopStyleSetButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.imagePopStyleSetButton.BaseColor = System.Drawing.Color.Red;
            this.imagePopStyleSetButton.ButtonText = "弹出方式";
            this.imagePopStyleSetButton.CornerRadius = 0;
            this.imagePopStyleSetButton.GlowAlpha = 0;
            this.imagePopStyleSetButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.imagePopStyleSetButton.Location = new System.Drawing.Point(1286, 220);
            this.imagePopStyleSetButton.Name = "imagePopStyleSetButton";
            this.imagePopStyleSetButton.OrdinaryAlpha = 0;
            this.imagePopStyleSetButton.PressedAlpha = 100;
            this.imagePopStyleSetButton.PressedKey = System.Windows.Forms.Keys.E;
            this.imagePopStyleSetButton.Size = new System.Drawing.Size(80, 30);
            this.imagePopStyleSetButton.TabIndex = 0;
            this.imagePopStyleSetButton.Click += new System.EventHandler(this.imagePopStyleSetButton_Click);
            // 
            // imagePopTimeSetButton
            // 
            this.imagePopTimeSetButton.BackColor = System.Drawing.Color.Transparent;
            this.imagePopTimeSetButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.imagePopTimeSetButton.BaseColor = System.Drawing.Color.Red;
            this.imagePopTimeSetButton.ButtonText = "弹出时间";
            this.imagePopTimeSetButton.CornerRadius = 0;
            this.imagePopTimeSetButton.GlowAlpha = 0;
            this.imagePopTimeSetButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.imagePopTimeSetButton.Location = new System.Drawing.Point(1286, 250);
            this.imagePopTimeSetButton.Name = "imagePopTimeSetButton";
            this.imagePopTimeSetButton.OrdinaryAlpha = 0;
            this.imagePopTimeSetButton.PressedAlpha = 100;
            this.imagePopTimeSetButton.PressedKey = System.Windows.Forms.Keys.E;
            this.imagePopTimeSetButton.Size = new System.Drawing.Size(80, 30);
            this.imagePopTimeSetButton.TabIndex = 0;
            this.imagePopTimeSetButton.Click += new System.EventHandler(this.imagePopTimeSetButton_Click);
            // 
            // savePresentPictureButton
            // 
            this.savePresentPictureButton.BackColor = System.Drawing.Color.Transparent;
            this.savePresentPictureButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.savePresentPictureButton.BaseColor = System.Drawing.Color.Red;
            this.savePresentPictureButton.ButtonText = "保存本帧";
            this.savePresentPictureButton.CornerRadius = 0;
            this.savePresentPictureButton.GlowAlpha = 0;
            this.savePresentPictureButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.savePresentPictureButton.Location = new System.Drawing.Point(1286, 280);
            this.savePresentPictureButton.Name = "savePresentPictureButton";
            this.savePresentPictureButton.OrdinaryAlpha = 0;
            this.savePresentPictureButton.PressedAlpha = 100;
            this.savePresentPictureButton.PressedKey = System.Windows.Forms.Keys.E;
            this.savePresentPictureButton.Size = new System.Drawing.Size(80, 30);
            this.savePresentPictureButton.TabIndex = 0;
            this.savePresentPictureButton.Click += new System.EventHandler(this.savePresentPictureButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.BackColor = System.Drawing.Color.Transparent;
            this.previewButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.previewButton.BaseColor = System.Drawing.Color.Red;
            this.previewButton.ButtonText = "预览";
            this.previewButton.CornerRadius = 0;
            this.previewButton.GlowAlpha = 0;
            this.previewButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.previewButton.Location = new System.Drawing.Point(1286, 310);
            this.previewButton.Name = "previewButton";
            this.previewButton.OrdinaryAlpha = 0;
            this.previewButton.PressedAlpha = 100;
            this.previewButton.PressedKey = System.Windows.Forms.Keys.E;
            this.previewButton.Size = new System.Drawing.Size(80, 30);
            this.previewButton.TabIndex = 0;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // savePresentCvdFileButton
            // 
            this.savePresentCvdFileButton.BackColor = System.Drawing.Color.Transparent;
            this.savePresentCvdFileButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.savePresentCvdFileButton.BaseColor = System.Drawing.Color.Red;
            this.savePresentCvdFileButton.ButtonText = "保存本卷";
            this.savePresentCvdFileButton.CornerRadius = 0;
            this.savePresentCvdFileButton.GlowAlpha = 0;
            this.savePresentCvdFileButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.savePresentCvdFileButton.Location = new System.Drawing.Point(1286, 340);
            this.savePresentCvdFileButton.Name = "savePresentCvdFileButton";
            this.savePresentCvdFileButton.OrdinaryAlpha = 0;
            this.savePresentCvdFileButton.PressedAlpha = 100;
            this.savePresentCvdFileButton.PressedKey = System.Windows.Forms.Keys.E;
            this.savePresentCvdFileButton.Size = new System.Drawing.Size(80, 30);
            this.savePresentCvdFileButton.TabIndex = 0;
            this.savePresentCvdFileButton.Click += new System.EventHandler(this.savePresentCvdFileButton_Click);
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
            // imagePopStyleToLastButton
            // 
            this.imagePopStyleToLastButton.BackColor = System.Drawing.Color.Pink;
            this.imagePopStyleToLastButton.BaseColor = System.Drawing.Color.Red;
            this.imagePopStyleToLastButton.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.imagePopStyleToLastButton.ButtonText = "←";
            this.imagePopStyleToLastButton.CornerRadius = 0;
            this.imagePopStyleToLastButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.imagePopStyleToLastButton.GlowAlpha = 0;
            this.imagePopStyleToLastButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.imagePopStyleToLastButton.Location = new System.Drawing.Point(1286, 190);
            this.imagePopStyleToLastButton.Name = "imagePopStyleToLastButton";
            this.imagePopStyleToLastButton.OrdinaryAlpha = 255;
            this.imagePopStyleToLastButton.PressedAlpha = 255;
            this.imagePopStyleToLastButton.PressedKey = System.Windows.Forms.Keys.E;
            this.imagePopStyleToLastButton.Size = new System.Drawing.Size(40, 30);
            this.imagePopStyleToLastButton.TabIndex = 0;
            this.imagePopStyleToLastButton.Click += new System.EventHandler(this.imagePopStyleToLastButton_Click);
            // 
            // imagePopStyleToNextButton
            // 
            this.imagePopStyleToNextButton.BackColor = System.Drawing.Color.Pink;
            this.imagePopStyleToNextButton.BaseColor = System.Drawing.Color.Red;
            this.imagePopStyleToNextButton.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.imagePopStyleToNextButton.ButtonText = "→";
            this.imagePopStyleToNextButton.CornerRadius = 0;
            this.imagePopStyleToNextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.imagePopStyleToNextButton.GlowAlpha = 0;
            this.imagePopStyleToNextButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(158)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.imagePopStyleToNextButton.Location = new System.Drawing.Point(1326, 190);
            this.imagePopStyleToNextButton.Name = "imagePopStyleToNextButton";
            this.imagePopStyleToNextButton.OrdinaryAlpha = 255;
            this.imagePopStyleToNextButton.PressedAlpha = 255;
            this.imagePopStyleToNextButton.PressedKey = System.Windows.Forms.Keys.E;
            this.imagePopStyleToNextButton.Size = new System.Drawing.Size(40, 30);
            this.imagePopStyleToNextButton.TabIndex = 0;
            this.imagePopStyleToNextButton.Click += new System.EventHandler(this.imagePopStyleToNextButton_Click);
            // 
            // imagePopTimeTextbox
            // 
            this.imagePopTimeTextbox.BackColor = System.Drawing.Color.CadetBlue;
            this.imagePopTimeTextbox.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.imagePopTimeTextbox.ForeColor = System.Drawing.Color.SlateBlue;
            this.imagePopTimeTextbox.Location = new System.Drawing.Point(1286, 250);
            this.imagePopTimeTextbox.Multiline = true;
            this.imagePopTimeTextbox.Name = "imagePopTimeTextbox";
            this.imagePopTimeTextbox.Size = new System.Drawing.Size(80, 30);
            this.imagePopTimeTextbox.TabIndex = 1;
            this.imagePopTimeTextbox.Text = "1000";
            this.imagePopTimeTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.imagePopTimeTextbox.TextChanged += new System.EventHandler(this.imagePopTimeTextbox_TextChanged);
            // 
            // pictureEditBox
            // 
            this.pictureEditBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureEditBox.Location = new System.Drawing.Point(300, 100);
            this.pictureEditBox.Name = "pictureEditBox";
            this.pictureEditBox.Size = new System.Drawing.Size(639, 484);
            this.pictureEditBox.TabIndex = 3;
            // 
            // pictureBoxToCenterButton
            // 
            this.pictureBoxToCenterButton.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxToCenterButton.BackImage = global::ComicViewClient.Properties.Resources.modify_time;
            this.pictureBoxToCenterButton.BaseColor = System.Drawing.Color.Red;
            this.pictureBoxToCenterButton.ButtonText = "图片框居中";
            this.pictureBoxToCenterButton.CornerRadius = 0;
            this.pictureBoxToCenterButton.GlowAlpha = 0;
            this.pictureBoxToCenterButton.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(60)))));
            this.pictureBoxToCenterButton.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxToCenterButton.Name = "pictureBoxToCenterButton";
            this.pictureBoxToCenterButton.OrdinaryAlpha = 0;
            this.pictureBoxToCenterButton.PressedAlpha = 100;
            this.pictureBoxToCenterButton.PressedKey = System.Windows.Forms.Keys.E;
            this.pictureBoxToCenterButton.Size = new System.Drawing.Size(80, 25);
            this.pictureBoxToCenterButton.TabIndex = 0;
            this.pictureBoxToCenterButton.Click += new System.EventHandler(this.pictureBoxToCenterButton_Click);
            // 
            // ComicEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.openNewCvdFileButton);
            this.Controls.Add(this.openImageFileButton);
            this.Controls.Add(this.enlargeImageButton);
            this.Controls.Add(this.shrinkImageButton);
            this.Controls.Add(this.imagePopStyleSetButton);
            this.Controls.Add(this.imagePopTimeSetButton);
            this.Controls.Add(this.savePresentPictureButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.savePresentCvdFileButton);
            this.Controls.Add(this.backToMainFormButton);
            this.Controls.Add(this.appCloseButton);
            this.Controls.Add(this.formMinisizeButton);
            this.Controls.Add(this.imagePopStyleToLastButton);
            this.Controls.Add(this.imagePopStyleToNextButton);
            this.Controls.Add(this.imagePopTimeTextbox);
            this.Controls.Add(this.imagePopStyleLabel);
            this.Controls.Add(this.pictureEditBox);
            this.Controls.Add(this.pictureBoxToCenterButton);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ComicViewClient.Properties.Settings.Default, "showform", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::ComicViewClient.Properties.Settings.Default.showform;
            this.Name = "ComicEditForm";
            this.Text = "ComicEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComicEditForm_FormClosing);
            this.Load += new System.EventHandler(this.ComicEditForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ComicEditForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Label label1;
        private UserControlButton1 openNewCvdFileButton;
        private UserControlButton1 openImageFileButton;
        private UserControlButton1 enlargeImageButton;
        private UserControlButton1 shrinkImageButton;
        private UserControlButton1 imagePopStyleSetButton;
        private UserControlButton1 imagePopTimeSetButton;
        private UserControlButton1 savePresentPictureButton;
        private UserControlButton1 previewButton;
        private UserControlButton1 savePresentCvdFileButton;
        private UserControlButton1 backToMainFormButton;
        private UserControlButton1 appCloseButton;
        private UserControlButton1 formMinisizeButton;
        private UserControlButton1 pictureBoxToCenterButton;

        private UserControlButton1 imagePopStyleToLastButton;
        private UserControlButton1 imagePopStyleToNextButton;
        private MyTextBox imagePopTimeTextbox;
        private System.Windows.Forms.Label imagePopStyleLabel;

        private MyPictureBox pictureEditBox;
        private System.Windows.Forms.Timer moveButtonAnimationTick;
    }
}