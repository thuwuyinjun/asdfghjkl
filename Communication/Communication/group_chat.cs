using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Communication
{
    public partial class group_chat : Form
    {
        public List<string> frd_list = new List<string>();
        public List<IPAddress> frd_IP = new List<IPAddress>(); 
        public List<string> sel_frd = new List<string>();
        public List<IPAddress> sel_IP = new List<IPAddress>();
        public string StudentNum;
        public string groupname;

        public group_chat()
        {
            InitializeComponent();
            panel_toolstrip.Enabled = true;
            panel_toolstrip.Visible = true;
            panel_toolstrip.BringToFront();
            this.gif_panel.SendToBack();
            
        }

        private void pb_exit_icon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_minimize_icon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pb_maximize_icon_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                SetWindowRegion();
            }
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

        private void invite_Click(object sender, EventArgs e)
        {
            inviting invite_frd = new inviting();
            invite_frd.StudentNum = StudentNum;
            invite_frd.groupname = groupname;
            invite_frd.chatting = this;
            invite_frd.listView1.Clear();
            invite_frd.listView1.Columns.Add("",20,HorizontalAlignment.Center);
            invite_frd.listView1.Columns.Add("好友账户",50,HorizontalAlignment.Center);
            invite_frd.listView1.Visible = true;
            for(int i = 1;i<frd_list.Count;i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = 0;
                //item.SubItems.Add("12345678");
                item.SubItems.Add(frd_list[i]);
                invite_frd.frd_ip.Add(frd_IP[i]);
                //item.SubItems.Add(frd_IP[i].ToString());
                //invite_frd.listView1.SmallImageList = invite_frd.imageList1;                
                item.EnsureVisible();
                invite_frd.listView1.Items.Add(item);
            }
            invite_frd.listView1.Visible = true;
            invite_frd.listView1.Refresh();
            invite_frd.Show();
        }

        private void pb_expression_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.gif_panel.BringToFront();
        }

        private void pb_snapshot_Click(object sender, EventArgs e)
        {
            ScreenForm screen = new ScreenForm();
            screen.copytoFather += new copyToFatherTextBox(copytoTextBox);
            screen.ShowDialog();
        }
        public void copytoTextBox(Rectangle rec)
        {
            Rectangle rec2 = rec; //改造一下，去掉红色边框
            if (rec.Width > 2 && rec.Height > 2)
                rec2 = new Rectangle(rec.X + 1, rec.Y + 1, rec.Width - 2, rec.Height - 2);
            Rectangle r = Screen.PrimaryScreen.Bounds;
            Image img = new Bitmap(rec2.Width, rec2.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(rec2.Location, new Point(0, 0), rec2.Size);
            Clipboard.SetDataObject(img, false);
            tb_output.Paste();
        }

        private void pb_pic_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = this.openFileDialog1.FileName;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    string fileName = System.IO.Path.GetFileName(filename);
                    string fileExtension = System.IO.Path.GetExtension(filename);
                    string strMsg = "我给你发送的文件为： " + fileName + "\r\n";
                    byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
                    byte[] arrSendMsg = new byte[arrMsg.Length + 1];
                    arrSendMsg[0] = 0; // 用来表示发送的是消息数据  
                    Buffer.BlockCopy(arrMsg, 0, arrSendMsg, 1, arrMsg.Length);
                   // sockClient.Send(arrSendMsg); // 发送消息；  

                    byte[] arrFile = new byte[1024 * 1024 * 2];
                    int length = fs.Read(arrFile, 0, arrFile.Length);  // 将文件中的数据读到arrFile数组中；  
                    byte[] arrFileSend = new byte[length + 1];
                    arrFileSend[0] = 1; // 用来表示发送的是文件数据；  
                    Buffer.BlockCopy(arrFile, 0, arrFileSend, 1, length);
                    // 还有一个 CopyTo的方法，但是在这里不适合； 当然还可以用for循环自己转化；  
                    //sockClient.Send(arrFileSend);// 发送数据到服务端；  
                }
            }
        }

        private void tb_key_press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     //检测是否按Enter键
            {
                e.Handled = true;
                /*if (tb_output.Rtf.IndexOf(@"{\pict\") > -1)
                    MessageBox.Show("a");*/

                //send();
                tb_output.Clear();
                //tb_output.Controls.Remove(pic);
            }
        }

    }
}
