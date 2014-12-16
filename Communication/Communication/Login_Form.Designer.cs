namespace Communication
{
    partial class Login_Form
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
            this.tb_StudentNum = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_divider = new System.Windows.Forms.PictureBox();
            this.pb_login_icon = new System.Windows.Forms.PictureBox();
            this.pb_exit_icon = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_StudentNum
            // 
            this.tb_StudentNum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tb_StudentNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_StudentNum.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_StudentNum.ForeColor = System.Drawing.Color.Black;
            this.tb_StudentNum.Location = new System.Drawing.Point(61, 193);
            this.tb_StudentNum.Name = "tb_StudentNum";
            this.tb_StudentNum.Size = new System.Drawing.Size(100, 17);
            this.tb_StudentNum.TabIndex = 1;
            this.tb_StudentNum.Text = "2012011441";
            // 
            // tb_Password
            // 
            this.tb_Password.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tb_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Password.Font = new System.Drawing.Font("Arial Narrow", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.Location = new System.Drawing.Point(61, 233);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '●';
            this.tb_Password.Size = new System.Drawing.Size(100, 17);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.Text = "net2014";
            // 
            // pb_logo
            // 
            this.pb_logo.Image = global::Communication.Properties.Resources.logo;
            this.pb_logo.Location = new System.Drawing.Point(90, 56);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(100, 100);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 14;
            this.pb_logo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Communication.Properties.Resources.divider;
            this.pictureBox1.Location = new System.Drawing.Point(61, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 10);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pb_divider
            // 
            this.pb_divider.Image = global::Communication.Properties.Resources.divider;
            this.pb_divider.Location = new System.Drawing.Point(61, 216);
            this.pb_divider.Name = "pb_divider";
            this.pb_divider.Size = new System.Drawing.Size(150, 10);
            this.pb_divider.TabIndex = 12;
            this.pb_divider.TabStop = false;
            // 
            // pb_login_icon
            // 
            this.pb_login_icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_login_icon.Image = global::Communication.Properties.Resources.login_inactive;
            this.pb_login_icon.Location = new System.Drawing.Point(184, 227);
            this.pb_login_icon.Name = "pb_login_icon";
            this.pb_login_icon.Size = new System.Drawing.Size(27, 27);
            this.pb_login_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_login_icon.TabIndex = 11;
            this.pb_login_icon.TabStop = false;
            this.pb_login_icon.Click += new System.EventHandler(this.pb_login_icon_Click);
            this.pb_login_icon.MouseLeave += new System.EventHandler(this.pb_login_icon_MouseLeave);
            this.pb_login_icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_login_icon_MouseMove);
            // 
            // pb_exit_icon
            // 
            this.pb_exit_icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_exit_icon.Image = global::Communication.Properties.Resources.exit_inactive;
            this.pb_exit_icon.Location = new System.Drawing.Point(240, 12);
            this.pb_exit_icon.Name = "pb_exit_icon";
            this.pb_exit_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_exit_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_exit_icon.TabIndex = 10;
            this.pb_exit_icon.TabStop = false;
            this.pb_exit_icon.Click += new System.EventHandler(this.pb_exit_icon_Click);
            this.pb_exit_icon.MouseLeave += new System.EventHandler(this.pb_exit_icon_MouseLeave);
            this.pb_exit_icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_exit_icon_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(267, 315);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_divider);
            this.Controls.Add(this.pb_login_icon);
            this.Controls.Add(this.pb_exit_icon);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_StudentNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_Form";
            this.ShowIcon = false;
            this.Text = "Login_Form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Form_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_Form_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_StudentNum;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.PictureBox pb_exit_icon;
        private System.Windows.Forms.PictureBox pb_login_icon;
        private System.Windows.Forms.PictureBox pb_divider;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Timer timer1;
    }
}