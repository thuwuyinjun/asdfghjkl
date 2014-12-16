namespace Communication
{
    partial class bg_form
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pb_bg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_bg)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pb_bg
            // 
            this.pb_bg.Image = global::Communication.Properties.Resources.bg;
            this.pb_bg.Location = new System.Drawing.Point(0, 0);
            this.pb_bg.Name = "pb_bg";
            this.pb_bg.Size = new System.Drawing.Size(631, 433);
            this.pb_bg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_bg.TabIndex = 11;
            this.pb_bg.TabStop = false;
            this.pb_bg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_bg_MouseDown);
            this.pb_bg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_bg_MouseMove);
            this.pb_bg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_bg_MouseUp);
            // 
            // bg_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(631, 433);
            this.Controls.Add(this.pb_bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bg_form";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "bg_form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.bg_form_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bg_form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bg_form_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pb_bg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_bg;
    }
}