using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication
{
    public partial class ScreenForm : Form
    {
        public ScreenForm()
        {
            InitializeComponent();
        }
        public event copyToFatherTextBox copytoFather;
        public bool begin = false;   //是否开始截屏
        public bool isDoubleClick = false;
        public Point firstPoint = new Point(0, 0);  //鼠标第一点
        public Point secondPoint = new Point(0, 0);  //鼠标第二点
        public Image cachImage = null;  //用来缓存截获的屏幕
        public int halfWidth = 0;//保存屏幕一半的宽度
        public int halfHeight = 0;//保存屏幕一般的高度
        /*复制整个屏幕,并让窗体填充屏幕*/
        public void copyScreen()
        {
            Rectangle r = Screen.PrimaryScreen.Bounds;
            Image img = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), r.Size);

            //窗体最大化，及相关处理
            this.Width = r.Width;
            this.Height = r.Height;
            this.Left = 0;
            this.Top = 0;
            pictureBox1.Width = r.Width;
            pictureBox1.Height = r.Height;
            pictureBox1.BackgroundImage = img;
            cachImage = img;
            halfWidth = r.Width / 2;
            halfHeight = r.Height / 2;
        }

        private void ScreenForm_Load(object sender, EventArgs e)
        {
            copyScreen();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDoubleClick)
            {
                copyScreen();
                begin = true;
                firstPoint = new Point(e.X, e.Y);
                msg.Location = new Point(firstPoint.X-msg.Width,firstPoint.Y);
                msg.Visible = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (begin)
            {
                if (MousePosition.X < firstPoint.X)
                    msg.Location = new Point(firstPoint.X, firstPoint.Y);
                else
                    msg.Location = new Point(firstPoint.X - msg.Width, firstPoint.Y);
                //获取新的右下角坐标
                secondPoint = new Point(e.X, e.Y);
                int minX = Math.Min(firstPoint.X, secondPoint.X);
                int minY = Math.Min(firstPoint.Y, secondPoint.Y);
                int maxX = Math.Max(firstPoint.X, secondPoint.X);
                int maxY = Math.Max(firstPoint.Y, secondPoint.Y);

                //重新画背景图
                Image tempimage = new Bitmap(cachImage);
                Graphics g = Graphics.FromImage(tempimage);
                //画裁剪框
                g.DrawRectangle(new Pen(Color.DeepSkyBlue), minX, minY, maxX - minX, maxY - minY);
                pictureBox1.Image = tempimage;
                //计算坐标信息
                msg.Text = "左上角坐标：(" + minX.ToString() + "," + minY.ToString() + ")\r\n";
                msg.Text += "右下角坐标：(" + maxX.ToString() + "," + maxY.ToString() + ")\r\n";
                msg.Text += "截图大小：" + (maxX - minX) + "×" + (maxY - minY) + "\r\n";
                msg.Text += "双击保存截图，ESC退出";

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            begin = false;
            isDoubleClick = true; //之后再点击就是双击事件了
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (firstPoint != secondPoint)
            {
                int minX = Math.Min(firstPoint.X, secondPoint.X);
                int minY = Math.Min(firstPoint.Y, secondPoint.Y);
                int maxX = Math.Max(firstPoint.X, secondPoint.X);
                int maxY = Math.Max(firstPoint.Y, secondPoint.Y);
                Rectangle r = new Rectangle(minX, minY, maxX - minX, maxY - minY);
                copytoFather(r);
            }
            this.Close();
        }

        private void ScreenForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }
    }
}
