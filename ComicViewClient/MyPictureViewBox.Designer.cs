namespace ComicViewClient
{
    partial class MyPictureViewBox
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ShowPictureAnimationTick = new System.Windows.Forms.Timer(this.components);
            this.moveBoxEdgeTick = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ShowPictureAnimationTick
            // 
            this.ShowPictureAnimationTick.Tick += new System.EventHandler(this.ShowPictureAnimationTick_Tick);

            // 
            // MyPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "MyPictureBox";
            this.Size = new System.Drawing.Size(567, 484);
            this.Load += new System.EventHandler(this.MyPictureBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyPictureBox_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ShowPictureAnimationTick;
        private System.Windows.Forms.Timer moveBoxEdgeTick;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
