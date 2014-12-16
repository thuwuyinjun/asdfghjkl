namespace Communication
{
    partial class control_friend
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
            this.pb_photo = new System.Windows.Forms.PictureBox();
            this.lb_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_photo
            // 
            this.pb_photo.BackColor = System.Drawing.Color.Gainsboro;
            this.pb_photo.Image = global::Communication.Properties.Resources.local_test;
            this.pb_photo.Location = new System.Drawing.Point(12, 7);
            this.pb_photo.Name = "pb_photo";
            this.pb_photo.Size = new System.Drawing.Size(35, 35);
            this.pb_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_photo.TabIndex = 2;
            this.pb_photo.TabStop = false;
            this.pb_photo.Click += new System.EventHandler(this.pb_photo_Click);
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(50, 17);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(35, 15);
            this.lb_name.TabIndex = 3;
            this.lb_name.Text = "label1";
            this.lb_name.Click += new System.EventHandler(this.lb_name_Click);
            // 
            // control_friend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.pb_photo);
            this.Name = "control_friend";
            this.Size = new System.Drawing.Size(116, 50);
            this.Click += new System.EventHandler(this.control_friend_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pb_photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pb_photo;
        public System.Windows.Forms.Label lb_name;

    }
}
