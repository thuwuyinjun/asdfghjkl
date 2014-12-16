namespace Communication
{
    partial class chatting_panel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatting_panel));
            this.shake_timer = new System.Windows.Forms.Timer(this.components);
            this.pb_minimize_icon = new System.Windows.Forms.PictureBox();
            this.pb_exit_icon = new System.Windows.Forms.PictureBox();
            this.pb_maximize_icon = new System.Windows.Forms.PictureBox();
            this.pb_divide2 = new System.Windows.Forms.PictureBox();
            this.pb_divide1 = new System.Windows.Forms.PictureBox();
            this.tb_input = new System.Windows.Forms.RichTextBox();
            this.gif_panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel_toolstrip = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimize_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maximize_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide1)).BeginInit();
            this.gif_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel_toolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // shake_timer
            // 
            this.shake_timer.Interval = 10;
            this.shake_timer.Tick += new System.EventHandler(this.shake_timer_Tick);
            // 
            // pb_minimize_icon
            // 
            this.pb_minimize_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_minimize_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_minimize_icon.Image = global::Communication.Properties.Resources.minimize_inactive;
            this.pb_minimize_icon.Location = new System.Drawing.Point(423, 12);
            this.pb_minimize_icon.Name = "pb_minimize_icon";
            this.pb_minimize_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_minimize_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_minimize_icon.TabIndex = 1;
            this.pb_minimize_icon.TabStop = false;
            // 
            // pb_exit_icon
            // 
            this.pb_exit_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_exit_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_exit_icon.Image = global::Communication.Properties.Resources.exit_inactive;
            this.pb_exit_icon.Location = new System.Drawing.Point(444, 12);
            this.pb_exit_icon.Name = "pb_exit_icon";
            this.pb_exit_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_exit_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_exit_icon.TabIndex = 0;
            this.pb_exit_icon.TabStop = false;
            // 
            // pb_maximize_icon
            // 
            this.pb_maximize_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_maximize_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_maximize_icon.Image = global::Communication.Properties.Resources.maximize_inactive;
            this.pb_maximize_icon.Location = new System.Drawing.Point(402, 12);
            this.pb_maximize_icon.Name = "pb_maximize_icon";
            this.pb_maximize_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_maximize_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_maximize_icon.TabIndex = 2;
            this.pb_maximize_icon.TabStop = false;
            // 
            // pb_divide2
            // 
            this.pb_divide2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_divide2.BackColor = System.Drawing.Color.Transparent;
            this.pb_divide2.Image = global::Communication.Properties.Resources.divider;
            this.pb_divide2.Location = new System.Drawing.Point(0, 33);
            this.pb_divide2.Name = "pb_divide2";
            this.pb_divide2.Size = new System.Drawing.Size(473, 10);
            this.pb_divide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_divide2.TabIndex = 8;
            this.pb_divide2.TabStop = false;
            // 
            // pb_divide1
            // 
            this.pb_divide1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_divide1.BackColor = System.Drawing.Color.Transparent;
            this.pb_divide1.Image = global::Communication.Properties.Resources.divider;
            this.pb_divide1.Location = new System.Drawing.Point(-2, 280);
            this.pb_divide1.Name = "pb_divide1";
            this.pb_divide1.Size = new System.Drawing.Size(473, 10);
            this.pb_divide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_divide1.TabIndex = 9;
            this.pb_divide1.TabStop = false;
            // 
            // tb_input
            // 
            this.tb_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_input.Location = new System.Drawing.Point(6, 49);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(445, 225);
            this.tb_input.TabIndex = 8;
            this.tb_input.Text = "";
            // 
            // gif_panel
            // 
            this.gif_panel.BackColor = System.Drawing.SystemColors.Highlight;
            this.gif_panel.Controls.Add(this.pictureBox5);
            this.gif_panel.Controls.Add(this.pictureBox4);
            this.gif_panel.Controls.Add(this.pictureBox3);
            this.gif_panel.Controls.Add(this.pictureBox2);
            this.gif_panel.Location = new System.Drawing.Point(87, 174);
            this.gif_panel.Name = "gif_panel";
            this.gif_panel.Size = new System.Drawing.Size(200, 100);
            this.gif_panel.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(35, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(70, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(105, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // panel_toolstrip
            // 
            this.panel_toolstrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_toolstrip.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel_toolstrip.Controls.Add(this.gif_panel);
            this.panel_toolstrip.Controls.Add(this.tb_input);
            this.panel_toolstrip.Controls.Add(this.pb_divide1);
            this.panel_toolstrip.Controls.Add(this.pb_divide2);
            this.panel_toolstrip.Controls.Add(this.pb_maximize_icon);
            this.panel_toolstrip.Controls.Add(this.pb_exit_icon);
            this.panel_toolstrip.Controls.Add(this.pb_minimize_icon);
            this.panel_toolstrip.Location = new System.Drawing.Point(1, 6);
            this.panel_toolstrip.Name = "panel_toolstrip";
            this.panel_toolstrip.Size = new System.Drawing.Size(471, 435);
            this.panel_toolstrip.TabIndex = 2;
            this.panel_toolstrip.Visible = false;
            // 
            // chatting_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_toolstrip);
            this.Name = "chatting_panel";
            this.Size = new System.Drawing.Size(475, 441);
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimize_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maximize_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide1)).EndInit();
            this.gif_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel_toolstrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer shake_timer;
        private System.Windows.Forms.PictureBox pb_minimize_icon;
        private System.Windows.Forms.PictureBox pb_exit_icon;
        private System.Windows.Forms.PictureBox pb_maximize_icon;
        private System.Windows.Forms.PictureBox pb_divide2;
        private System.Windows.Forms.PictureBox pb_divide1;
        private System.Windows.Forms.RichTextBox tb_input;
        private System.Windows.Forms.Panel gif_panel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel_toolstrip;

    }
}
