using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Communication
{
    public partial class Login_Form : Form
    {
        Socket sockClient = null;
        Thread threadClient = null;
        Client_Form cf;
        Form bg_form;
        Point mouse_offset;
        bool finish;
        public Login_Form()
        {
            InitializeComponent();
            this.Opacity = 1.0;
            finish = false;
            tb_StudentNum.LostFocus += new System.EventHandler(this.tb_StudentNum_LostFocus);
            tb_StudentNum.GotFocus += new System.EventHandler(this.tb_StudentNum_GotFocus);
            tb_Password.LostFocus += new System.EventHandler(this.tb_Password_LostFocus);
            tb_Password.GotFocus += new System.EventHandler(this.tb_Password_GotFocus);
            pb_login_icon.Focus();

        }

        void RecMsg()
        {
            byte[] arrMsgRec = new byte[1024 * 1024 * 2];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int length = -1;
            try
            {
                length = sockClient.Receive(arrMsgRec);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            string strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);
            if (strMsg == "lol")
                finish = true;
            else if (strMsg != "lol")
            {
                MessageBox.Show("登录错误");
            }
            sockClient.Close();
        }
        private void tb_StudentNum_LostFocus(object sender, EventArgs e)
        {
            if (tb_StudentNum.Text == "")
            {
                tb_StudentNum.ForeColor = Color.Gray;
                tb_StudentNum.Text = "输入学号";
            }
        }
        private void tb_Password_LostFocus(object sender, EventArgs e)
        {
            if (tb_Password.Text == "")
            {
                tb_Password.ForeColor = Color.Gray;
                tb_Password.PasswordChar = '\0';
                tb_Password.Text = "输入密码";
            }
        }
        private void tb_StudentNum_GotFocus(object sender, EventArgs e)
        {
            if (tb_StudentNum.Text == "输入学号")
            {
                tb_StudentNum.ForeColor = Color.Black;
                tb_StudentNum.Text = "";
            }
        }
        private void tb_Password_GotFocus(object sender, EventArgs e)
        {
            if (tb_Password.Text == "输入密码")
            {
                tb_Password.PasswordChar = '●';
                tb_Password.ForeColor = Color.Black;
                tb_Password.Text = "";
            }

        }
        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath;

            FormPath = new System.Drawing.Drawing2D.GraphicsPath();

            Rectangle rect = new Rectangle(-1, -1, this.Width + 1, this.Height);

            FormPath = GetRoundedRectPath(rect, 24);

            this.Region = new Region(FormPath);
        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            GraphicsPath path = new GraphicsPath();

            //   左上角 
            path.AddArc(arcRect, 185, 90);

            //   右上角 
            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 275, 90);

            //   右下角 
            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 356, 90);

            //   左下角 
            arcRect.X = rect.Left;

            arcRect.Width += 2;

            arcRect.Height += 2;

            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;
        }

        private void Login_Form_Paint(object sender, PaintEventArgs e)
        {
            SetWindowRegion();
        }

        private void Login_Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }
        }

        private void Login_Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void pb_exit_icon_MouseMove(object sender, MouseEventArgs e)
        {
            pb_exit_icon.Image = Communication.Properties.Resources.exit_active;
        }

        private void pb_exit_icon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_exit_icon_MouseLeave(object sender, EventArgs e)
        {
            pb_exit_icon.Image = Communication.Properties.Resources.exit_inactive;
        }

        private void pb_login_icon_Click(object sender, EventArgs e)
        {
            string path = null;
            IPAddress ip = IPAddress.Parse("166.111.180.60");
            IPEndPoint endPoint = new IPEndPoint(ip, 8000);
            sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sockClient.Connect(endPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                return;
            }
            string strMsg = tb_StudentNum.Text + "_" + tb_Password.Text;
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            sockClient.Send(arrMsg);
            path = tb_StudentNum.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            threadClient = new Thread(RecMsg);
            threadClient.IsBackground = false;
            threadClient.Start();
            timer1.Enabled = true;
            timer1.Start();

        }

        private void pb_login_icon_MouseMove(object sender, MouseEventArgs e)
        {
            pb_login_icon.Image = Communication.Properties.Resources.login_active;
        }

        private void pb_login_icon_MouseLeave(object sender, EventArgs e)
        {
            pb_login_icon.Image = Communication.Properties.Resources.login_inactive;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (finish == true)
            {
                this.Opacity -= 0.04;//每次改变Form的不透明属性
                if (this.Opacity <= 0.0)  //当Form完全显示时，停止计时
                {
                    this.timer1.Enabled = false;
                    this.Enabled = false;
                    this.ShowInTaskbar = false;
                    sockClient.Close();
                    cf = new Client_Form();
                    cf.StudentNum = tb_StudentNum.Text;
                    cf.ShowDialog();

                }
            }

        }
    }
}
