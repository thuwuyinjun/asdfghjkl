namespace Communication
{
    partial class Client_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_toolstrip = new System.Windows.Forms.Panel();
            this.pb_expression = new System.Windows.Forms.PictureBox();
            this.pb_shake = new System.Windows.Forms.PictureBox();
            this.gif_panel = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tb_input = new System.Windows.Forms.RichTextBox();
            this.pb_snapshot = new System.Windows.Forms.PictureBox();
            this.tb_output = new System.Windows.Forms.RichTextBox();
            this.pb_pic = new System.Windows.Forms.PictureBox();
            this.pb_video = new System.Windows.Forms.PictureBox();
            this.pb_file = new System.Windows.Forms.PictureBox();
            this.pb_divide1 = new System.Windows.Forms.PictureBox();
            this.pb_divide2 = new System.Windows.Forms.PictureBox();
            this.pb_maximize_icon = new System.Windows.Forms.PictureBox();
            this.pb_exit_icon = new System.Windows.Forms.PictureBox();
            this.pb_minimize_icon = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dfdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pb_single_chat = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pb_add = new System.Windows.Forms.PictureBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.shake_timer = new System.Windows.Forms.Timer(this.components);
            this.control_local_test = new Communication.control_friend();
            this.panel_toolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_expression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shake)).BeginInit();
            this.gif_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_snapshot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_video)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maximize_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimize_icon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_single_chat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel_toolstrip
            // 
            this.panel_toolstrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_toolstrip.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel_toolstrip.Controls.Add(this.pb_expression);
            this.panel_toolstrip.Controls.Add(this.pb_shake);
            this.panel_toolstrip.Controls.Add(this.gif_panel);
            this.panel_toolstrip.Controls.Add(this.tb_input);
            this.panel_toolstrip.Controls.Add(this.pb_snapshot);
            this.panel_toolstrip.Controls.Add(this.tb_output);
            this.panel_toolstrip.Controls.Add(this.pb_pic);
            this.panel_toolstrip.Controls.Add(this.pb_video);
            this.panel_toolstrip.Controls.Add(this.pb_file);
            this.panel_toolstrip.Controls.Add(this.pb_divide1);
            this.panel_toolstrip.Controls.Add(this.pb_divide2);
            this.panel_toolstrip.Controls.Add(this.pb_maximize_icon);
            this.panel_toolstrip.Controls.Add(this.pb_exit_icon);
            this.panel_toolstrip.Controls.Add(this.pb_minimize_icon);
            this.panel_toolstrip.Location = new System.Drawing.Point(173, 0);
            this.panel_toolstrip.Name = "panel_toolstrip";
            this.panel_toolstrip.Size = new System.Drawing.Size(458, 435);
            this.panel_toolstrip.TabIndex = 1;
            this.panel_toolstrip.Visible = false;
            this.panel_toolstrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_toolstrip_MouseDown);
            this.panel_toolstrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_toolstrip_MouseMove);
            // 
            // pb_expression
            // 
            this.pb_expression.Image = ((System.Drawing.Image)(resources.GetObject("pb_expression.Image")));
            this.pb_expression.Location = new System.Drawing.Point(201, 294);
            this.pb_expression.Name = "pb_expression";
            this.pb_expression.Size = new System.Drawing.Size(21, 17);
            this.pb_expression.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_expression.TabIndex = 15;
            this.pb_expression.TabStop = false;
            this.pb_expression.Click += new System.EventHandler(this.pb_expression_Click);
            // 
            // pb_shake
            // 
            this.pb_shake.Image = global::Communication.Properties.Resources.shake;
            this.pb_shake.Location = new System.Drawing.Point(166, 295);
            this.pb_shake.Name = "pb_shake";
            this.pb_shake.Size = new System.Drawing.Size(24, 17);
            this.pb_shake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_shake.TabIndex = 4;
            this.pb_shake.TabStop = false;
            this.pb_shake.Click += new System.EventHandler(this.pb_shake_Click);
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
            // tb_input
            // 
            this.tb_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_input.Location = new System.Drawing.Point(6, 49);
            this.tb_input.Name = "tb_input";
            this.tb_input.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tb_input.Size = new System.Drawing.Size(445, 225);
            this.tb_input.TabIndex = 8;
            this.tb_input.Text = "";
            this.tb_input.VScroll += new System.EventHandler(this.scroll);
            // 
            // pb_snapshot
            // 
            this.pb_snapshot.Image = global::Communication.Properties.Resources.snapshot;
            this.pb_snapshot.Location = new System.Drawing.Point(135, 295);
            this.pb_snapshot.Name = "pb_snapshot";
            this.pb_snapshot.Size = new System.Drawing.Size(17, 17);
            this.pb_snapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_snapshot.TabIndex = 12;
            this.pb_snapshot.TabStop = false;
            this.pb_snapshot.Click += new System.EventHandler(this.pb_snapshot_Click);
            // 
            // tb_output
            // 
            this.tb_output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_output.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_output.Location = new System.Drawing.Point(6, 318);
            this.tb_output.Name = "tb_output";
            this.tb_output.Size = new System.Drawing.Size(445, 108);
            this.tb_output.TabIndex = 8;
            this.tb_output.Text = "";
            this.tb_output.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_output_KeyPress);
            // 
            // pb_pic
            // 
            this.pb_pic.Image = global::Communication.Properties.Resources.pic;
            this.pb_pic.Location = new System.Drawing.Point(101, 295);
            this.pb_pic.Name = "pb_pic";
            this.pb_pic.Size = new System.Drawing.Size(20, 17);
            this.pb_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_pic.TabIndex = 11;
            this.pb_pic.TabStop = false;
            this.pb_pic.Click += new System.EventHandler(this.pb_pic_Click);
            // 
            // pb_video
            // 
            this.pb_video.Image = global::Communication.Properties.Resources.video;
            this.pb_video.Location = new System.Drawing.Point(61, 296);
            this.pb_video.Name = "pb_video";
            this.pb_video.Size = new System.Drawing.Size(26, 16);
            this.pb_video.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_video.TabIndex = 10;
            this.pb_video.TabStop = false;
            // 
            // pb_file
            // 
            this.pb_file.BackColor = System.Drawing.Color.Transparent;
            this.pb_file.Image = global::Communication.Properties.Resources.file_transfer;
            this.pb_file.Location = new System.Drawing.Point(25, 295);
            this.pb_file.Name = "pb_file";
            this.pb_file.Size = new System.Drawing.Size(22, 17);
            this.pb_file.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_file.TabIndex = 8;
            this.pb_file.TabStop = false;
            this.pb_file.Click += new System.EventHandler(this.pb_file_Click);
            // 
            // pb_divide1
            // 
            this.pb_divide1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_divide1.BackColor = System.Drawing.Color.Transparent;
            this.pb_divide1.Image = global::Communication.Properties.Resources.divider;
            this.pb_divide1.Location = new System.Drawing.Point(-2, 280);
            this.pb_divide1.Name = "pb_divide1";
            this.pb_divide1.Size = new System.Drawing.Size(460, 10);
            this.pb_divide1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_divide1.TabIndex = 9;
            this.pb_divide1.TabStop = false;
            // 
            // pb_divide2
            // 
            this.pb_divide2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_divide2.BackColor = System.Drawing.Color.Transparent;
            this.pb_divide2.Image = global::Communication.Properties.Resources.divider;
            this.pb_divide2.Location = new System.Drawing.Point(0, 33);
            this.pb_divide2.Name = "pb_divide2";
            this.pb_divide2.Size = new System.Drawing.Size(460, 10);
            this.pb_divide2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_divide2.TabIndex = 8;
            this.pb_divide2.TabStop = false;
            // 
            // pb_maximize_icon
            // 
            this.pb_maximize_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_maximize_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_maximize_icon.Image = global::Communication.Properties.Resources.maximize_inactive;
            this.pb_maximize_icon.Location = new System.Drawing.Point(389, 12);
            this.pb_maximize_icon.Name = "pb_maximize_icon";
            this.pb_maximize_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_maximize_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_maximize_icon.TabIndex = 2;
            this.pb_maximize_icon.TabStop = false;
            this.pb_maximize_icon.Click += new System.EventHandler(this.pb_maximize_icon_Click);
            this.pb_maximize_icon.MouseLeave += new System.EventHandler(this.pb_maximize_icon_MouseLeave);
            this.pb_maximize_icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_maximize_icon_MouseMove);
            // 
            // pb_exit_icon
            // 
            this.pb_exit_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_exit_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_exit_icon.Image = global::Communication.Properties.Resources.exit_inactive;
            this.pb_exit_icon.Location = new System.Drawing.Point(431, 12);
            this.pb_exit_icon.Name = "pb_exit_icon";
            this.pb_exit_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_exit_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_exit_icon.TabIndex = 0;
            this.pb_exit_icon.TabStop = false;
            this.pb_exit_icon.Click += new System.EventHandler(this.pb_exit_icon_Click);
            this.pb_exit_icon.MouseLeave += new System.EventHandler(this.pb_exit_icon_MouseLeave);
            this.pb_exit_icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_exit_icon_MouseMove);
            // 
            // pb_minimize_icon
            // 
            this.pb_minimize_icon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_minimize_icon.BackColor = System.Drawing.Color.Transparent;
            this.pb_minimize_icon.Image = global::Communication.Properties.Resources.minimize_inactive;
            this.pb_minimize_icon.Location = new System.Drawing.Point(410, 12);
            this.pb_minimize_icon.Name = "pb_minimize_icon";
            this.pb_minimize_icon.Size = new System.Drawing.Size(15, 15);
            this.pb_minimize_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_minimize_icon.TabIndex = 1;
            this.pb_minimize_icon.TabStop = false;
            this.pb_minimize_icon.Click += new System.EventHandler(this.pb_minimize_icon_Click);
            this.pb_minimize_icon.MouseLeave += new System.EventHandler(this.pb_minimize_icon_MouseLeave);
            this.pb_minimize_icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_minimize_icon_MouseMove);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dfdfToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // dfdfToolStripMenuItem
            // 
            this.dfdfToolStripMenuItem.Name = "dfdfToolStripMenuItem";
            this.dfdfToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dfdfToolStripMenuItem.Text = "添加好友";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Communication.Properties.Resources.group_chat;
            this.pictureBox9.Location = new System.Drawing.Point(14, 327);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(32, 22);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 14;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // pb_single_chat
            // 
            this.pb_single_chat.Image = global::Communication.Properties.Resources.single_chat;
            this.pb_single_chat.Location = new System.Drawing.Point(17, 296);
            this.pb_single_chat.Name = "pb_single_chat";
            this.pb_single_chat.Size = new System.Drawing.Size(25, 25);
            this.pb_single_chat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_single_chat.TabIndex = 13;
            this.pb_single_chat.TabStop = false;
            this.pb_single_chat.Click += new System.EventHandler(this.pb_single_chat_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(17, 359);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(27, 23);
            this.pictureBox7.TabIndex = 12;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pb_add
            // 
            this.pb_add.BackColor = System.Drawing.Color.Transparent;
            this.pb_add.Image = global::Communication.Properties.Resources.Add;
            this.pb_add.Location = new System.Drawing.Point(22, 406);
            this.pb_add.Name = "pb_add";
            this.pb_add.Size = new System.Drawing.Size(15, 15);
            this.pb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_add.TabIndex = 11;
            this.pb_add.TabStop = false;
            this.pb_add.Click += new System.EventHandler(this.pb_add_Click);
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Image = global::Communication.Properties.Resources.logo;
            this.pb_logo.Location = new System.Drawing.Point(9, 8);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(40, 40);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 7;
            this.pb_logo.TabStop = false;
            // 
            // shake_timer
            // 
            this.shake_timer.Interval = 10;
            this.shake_timer.Tick += new System.EventHandler(this.shake_timer_Tick);
            // 
            // control_local_test
            // 
            this.control_local_test.BackColor = System.Drawing.Color.Gainsboro;
            this.control_local_test.Location = new System.Drawing.Point(57, 0);
            this.control_local_test.Name = "control_local_test";
            this.control_local_test.Size = new System.Drawing.Size(116, 50);
            this.control_local_test.TabIndex = 15;
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(631, 433);
            this.Controls.Add(this.control_local_test);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pb_single_chat);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pb_add);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.panel_toolstrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Client_Form";
            this.Activated += new System.EventHandler(this.Client_Form_Activated);
            this.Load += new System.EventHandler(this.Client_Form_Load);
            this.LocationChanged += new System.EventHandler(this.Client_Form_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Client_Form_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Client_Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Client_Form_MouseMove);
            this.panel_toolstrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_expression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_shake)).EndInit();
            this.gif_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_snapshot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_video)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_file)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_divide2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maximize_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_exit_icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimize_icon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_single_chat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_exit_icon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pb_minimize_icon;
        private System.Windows.Forms.PictureBox pb_maximize_icon;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.PictureBox pb_divide2;
        private System.Windows.Forms.PictureBox pb_divide1;
        private System.Windows.Forms.PictureBox pb_file;
        private System.Windows.Forms.PictureBox pb_video;
        private System.Windows.Forms.PictureBox pb_pic;
        private System.Windows.Forms.PictureBox pb_snapshot;
        private System.Windows.Forms.RichTextBox tb_input;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dfdfToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_add;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel gif_panel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.PictureBox pb_single_chat;
        private System.Windows.Forms.PictureBox pictureBox9;
        private control_friend control_local_test;
        private System.Windows.Forms.PictureBox pb_shake;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.PictureBox pb_expression;
        public System.Windows.Forms.RichTextBox tb_output;
        public System.Windows.Forms.Panel panel_toolstrip;
        private System.Windows.Forms.Timer shake_timer;
    }
}

