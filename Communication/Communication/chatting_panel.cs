using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Communication
{
    public partial class chatting_panel : UserControl
    {
        control_friend current_select;
        public Socket sockClient;
        public Client_Form form;
        public string StudentNum;
        delegate void MsgShow(string msg, Color color, HorizontalAlignment direction);
        delegate void Shake();
        Shake shake = null;
        MsgShow msgshow = null;
        int current_pos = 0;
        int send_type;
        List<int> gif_y = new List<int>();
        List<int> gif_x = new List<int>();
        List<int> gif_id = new List<int>();
        PictureBox pic = new PictureBox();
        int count;
        byte[] img;
        SaveDialogShow sdshow = null;
        delegate void SaveDialogShow(byte[] arrMsgRec, int length);
        showgif gif_show = null;
        delegate void showgif(string path);

        public List<PictureBox> picturebox = new List<PictureBox>();
        Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();
        Dictionary<string, Socket> dict = new Dictionary<string, Socket>();
        SaveFileDialog sfd;

        public chatting_panel()
        {
            InitializeComponent();
            shake = new Shake(form_shake);
            msgshow = new MsgShow(ShowMsg);
            gif_show = new showgif(rec_show_gif);
            sdshow = new SaveDialogShow(ShowSaveDialog);
            sfd = new SaveFileDialog();
        }
        void form_shake()
        {
            count = 0;
            shake_timer.Start();
        }
        private void tb_key_ress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)     //检测是否按Enter键
            {
                e.Handled = true;
                /*if (tb_output.Rtf.IndexOf(@"{\pict\") > -1)
                    MessageBox.Show("a");*/
                if (this.tb_output.Lines[0] != "")
                    send_type = 0;
                else
                {
                    send_type = 2;
                    int n = this.tb_output.Controls.Count - 1;
                    this.tb_output.Controls.RemoveAt(n);
                }
                send(send_type, sockClient);
                tb_output.Clear();
                //  tb_output.Controls.Remove(pic);
            }
        }
        public void RecMsg(object sokConnectionparn)
        {
            Socket sokClient = sokConnectionparn as Socket;
            while (true)
            {
                // 定义一个2M的缓存区；  
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                // 将接受到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = sokClient.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                }
                catch (SocketException se)
                {
                    //MessageBox.Show("异常：" + se.Message);
                    // 从 通信套接字 集合中删除被中断连接的通信套接字；  
                    dict.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从通信线程集合中删除被中断连接的通信线程对象；  
                    dictThread.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从列表中移除被中断的连接IP  
                    //lbOnline.Items.Remove(sokClient.RemoteEndPoint.ToString());
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show("异常：" + e.Message);
                    // 从 通信套接字 集合中删除被中断连接的通信套接字；  
                    dict.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从通信线程集合中删除被中断连接的通信线程对象；  
                    dictThread.Remove(sokClient.RemoteEndPoint.ToString());
                    // 从列表中移除被中断的连接IP  
                    //lbOnline.Items.Remove(sokClient.RemoteEndPoint.ToString());
                    break;
                }
                string strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 1, length - 1);// 将接受到的字节数据转化成字符串； 
                switch (arrMsgRec[0])
                {
                    case 0: // 表示接收到的是文本；  
                        {
                            this.Invoke(msgshow, new object[] { current_select.name + "  " + DateTime.Now.ToLongTimeString().ToString() + "\r\n", Color.Blue, HorizontalAlignment.Left });
                            this.Invoke(msgshow, new object[] { strMsg, Color.Black, HorizontalAlignment.Left });
                            break;
                        }
                    case 1:// 表示接收到的是文件；  
                        {
                            this.BeginInvoke(sdshow, new object[] { arrMsgRec, length });
                            break;
                        }
                    case 2: //接收到的是动态表情
                        {
                            string path = "../../Resources/gif";
                            string num = null;
                            num = strMsg.Substring(0, strMsg.Length - 4);
                            path += num + ".gif";
                            /* PictureBox pic = new PictureBox();
                                pic.ImageLocation = "../../Resources/gif1.gif";
                                pic.Load("../../Resources/gif1.gif");
                                pic.Width = 25;
                                pic.Height = 25;
                                pic.SizeMode = PictureBoxSizeMode.StretchImage;*/
                            int index = Int32.Parse(num);
                            this.BeginInvoke(gif_show, new object[] { path });
                            break;
                        }
                    
                    
                    case 5: //接收到的是窗口抖动请求
                        {
                            this.Invoke(msgshow, new object[] { "对方发来了一个窗口抖动\n", Color.Gray, HorizontalAlignment.Center });
                            this.Invoke(shake, new object[] { });
                            break;
                        }
                    default:
                        break;

                }
            }
        }
        private void send(int type, Socket socket)           //好友账号
        {
            Font oldFont = this.tb_input.SelectionFont;
            string strMsg = tb_output.Text;
            //tb_input.SelectionFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            this.Invoke(msgshow, new object[] { StudentNum + "  " + DateTime.Now.ToLongTimeString().ToString() + "\n", Color.Blue, HorizontalAlignment.Right });
            //tb_input.SelectionFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            this.Invoke(msgshow, new object[] { strMsg, Color.Black, HorizontalAlignment.Right });
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            byte[] arrSendMsg;
            if (type == 2)
            {
                arrSendMsg = new byte[img.Length + 1];
                arrSendMsg[0] = 2; // 用来表示发送的是消息数据  
                Buffer.BlockCopy(img, 0, arrSendMsg, 1, img.Length);
                socket.Send(arrSendMsg);
            }
            else
            {
                arrSendMsg = new byte[arrMsg.Length + 1];
                arrSendMsg[0] = 0; // 用来表示发送的是消息数据  
                Buffer.BlockCopy(arrMsg, 0, arrSendMsg, 1, arrMsg.Length);
                socket.Send(arrSendMsg); // 发送消息；  
            }
        }

        public void ShowMsg(string str, Color color, HorizontalAlignment direction)
        {
            this.tb_input.SelectionColor = color;
            this.tb_input.SelectionAlignment = direction;
            tb_input.AppendText(str);
            Point p = new Point();

            //  p.Y =this.tb_input.ClientRectangle.Bottom;
            p = this.tb_input.GetPositionFromCharIndex(this.tb_input.Lines.Length - 1);
            current_pos += 16;
            if (p.X > this.tb_input.Height)
            {
                for (int i = 0; i < gif_x.Count; i++)
                {
                    p.X = gif_x[i] - 10;
                    p.Y = this.tb_input.Controls[gif_id[i]].Location.Y;
                    this.tb_input.Controls[gif_id[i]].Location = p;
                    /*if (p[i].Y > this.tb_input.Height)
                    {
                        this.tb_input.Controls[gif_id[i]].Hide();
                    }
                    else
                    {
                        this.tb_input.Controls[gif_id[i]].Location = p[i];
                    }*/
                }
            }
            /*for (int i = 0; i < picturebox.Count; i++)
            {
                current_pos += picturebox[i].Height;
            }*/
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pic = new PictureBox();
            pic.ImageLocation = "../../Resources/gif1.gif";
            pic.Load("../../Resources/gif1.gif");
            pic.Width = 25;
            pic.Height = 25;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            tb_output.Controls.Add(pic);
            /*System.IO.MemoryStream Ms = new MemoryStream();
            pic.Image.Save(Ms, System.Drawing.Imaging.ImageFormat.Gif);
            img = new byte[Ms.Length];
            Ms.Position = 0;
            Ms.Read(img, 0, Convert.ToInt32(Ms.Length));*/
            string s = "1/r/n";
            img = System.Text.Encoding.UTF8.GetBytes(s);
            this.gif_panel.SendToBack();
        }

        private void shake_timer_Tick(object sender, EventArgs e)
        {
            if (count < 10)
            {
                Point new_loc = new Point(this.Location.X - 1, this.Location.Y - 1);
                this.Location = new_loc;
                count++;
            }
            else if (count < 20)
            {
                Point new_loc = new Point(this.Location.X + 1, this.Location.Y + 1);
                this.Location = new_loc;
                count++;
            }
            else if (count < 30)
            {
                Point new_loc = new Point(this.Location.X + 1, this.Location.Y - 1);
                this.Location = new_loc;
                count++;
            }
            else if (count < 40)
            {
                Point new_loc = new Point(this.Location.X - 1, this.Location.Y + 1);
                this.Location = new_loc;
                count++;
            }
            else
                shake_timer.Stop();

        }

        void rec_show_gif(string path)
        {
            PictureBox pic = new PictureBox();
            pic.Image = Image.FromFile(path);
            pic.Height = 48;
            pic.Width = 50;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Add(pic);
            Point p = new Point();
            p.X = this.tb_input.Width - pic.Width - 10;
            p.Y = current_pos;
            pic.Location = p;
            pic.Visible = true;
            pic.BringToFront();
            this.tb_input.Controls.Add(pic);
            gif_y.Add(pic.Location.Y);
            gif_x.Add(pic.Location.X);
            gif_id.Add(this.tb_input.Controls.Count - 1);
            for (int i = 0; i < 4; i++)
            {
                this.tb_input.AppendText("\r\n");
                current_pos += 16;
            }
            if (current_pos > this.tb_input.Height)
            {
                for (int i = 0; i < gif_x.Count; i++)
                {
                    p.X = gif_x[i] - 10;
                    p.Y = this.tb_input.Controls[gif_id[i]].Location.Y;
                    this.tb_input.Controls[gif_id[i]].Location = p;
                    /*if (p[i].Y > this.tb_input.Height)
                    {
                        this.tb_input.Controls[gif_id[i]].Hide();
                    }
                    else
                    {
                        this.tb_input.Controls[gif_id[i]].Location = p[i];
                    }*/
                }
            }
        }
        void ShowSaveDialog(byte[] arrMsgRec, int length)
        {
            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string fileSavePath = sfd.FileName;// 获得文件保存的路径；  
                // 创建文件流，然后根据路径创建文件；  
                using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                {
                    fs.Write(arrMsgRec, 1, length - 1);
                    ShowMsg("文件保存成功：" + fileSavePath, Color.Black, HorizontalAlignment.Center);
                }
            }
        }

        private void pb_file_Click(object sender, EventArgs e)
        {

        }

        private void pb_snapshot_Click(object sender, EventArgs e)
        {
            ScreenForm screen = new ScreenForm();
            screen.copytoFather += new copyToFatherTextBox(copytoTextBox);
            screen.ShowDialog();
        }

        private void pb_shake_Click(object sender, EventArgs e)
        {
            byte[] arrSendMsg;
            arrSendMsg = new byte[1];
            arrSendMsg[0] = 5;
            sockClient.Send(arrSendMsg); // 发送消息； 
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
    }
}
