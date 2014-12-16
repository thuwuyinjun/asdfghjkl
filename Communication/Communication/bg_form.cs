using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communication
{
    public partial class bg_form : Form
    {
        Point mouse_offset;
        public PictureBox pb_logo;
        public Client_Form Parent_Form;
        public bg_form()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
         
        }

        private void bg_form_Paint(object sender, PaintEventArgs e)
        {
            SetWindowRegion();
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

        private void bg_form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
                this.Parent_Form.Location = mousePos;
            }
        }

        private void bg_form_MouseDown(object sender, MouseEventArgs e)
        {
            
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Location = Parent_Form.Location;
            this.Opacity += 0.04;//每次改变Form的不透明属性
            if (this.Opacity >= 0.9)  //当Form完全显示时，停止计时
            {
                this.timer1.Enabled = false;
            }
        }
        private void pb_bg_MouseDown(object sender, MouseEventArgs e)
        {
            Parent_Form.TopMost = true;
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void pb_bg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
                this.Parent_Form.Location = mousePos;
            }
        }

        private void pb_bg_MouseUp(object sender, MouseEventArgs e)
        {
            Parent_Form.TopMost = false;
        }  

    }
}
