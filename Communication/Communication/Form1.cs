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
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
//using DynamicGifLib;
using Microsoft.CSharp;
using System.Net;
using System.Timers;
using System.Management;

namespace Communication
{

    public delegate void copyToFatherTextBox(Rectangle r);
    public partial class Client_Form : Form
    {
        control_friend current_select;
        Point mouse_offset;
        bg_form bg_form;
        public string StudentNum;
        Thread threadWatch = null; // 负责监听客户端连接请求的 线程；  
        Socket socketWatch = null;
        Thread threadClient = null; // 创建用于接收服务端消息的 线程；  
        Thread threadServer = null;
        Socket sockClient = null;
        int count;
        bool isgif = false;
        Shake shake = null;
        byte[] img = null;
        SaveFileDialog sfd;
        bool finish = false;
        delegate void MsgShow(string msg,Color color,HorizontalAlignment direction);
        delegate void SaveDialogShow(byte[] arrMsgRec,int length);
        delegate void showgif(string path);
        delegate void Shake();
        showgif gif_show = null;
        SaveDialogShow sdshow = null;
        MsgShow msgshow = null;
        Dictionary<string, Socket> dict = new Dictionary<string, Socket>();
        List<string> want_frd = new List<string>();

        Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();
        List<ImageList> imagelist = new List<ImageList>();
        PictureBox pic = null;
        ListViewItem lvi = new ListViewItem();
        static public List<string> fr = new List<string>();
        int sequence = 0;
        
        public List<IPAddress> iplist = new List<System.Net.IPAddress>();
        public List<Socket> apply_socket = new List<Socket>();
        public List<RichTextBox> boxlist = new List<RichTextBox>();
        public RichTextBox curr_box = new RichTextBox();

        public bool changed = false;
        int group_curr_x = 55;
        int group_curr_y = 60;
        int current_x = 60;
        int current_y = 0;
        bool appear;
        public bool accept_frd = false;
        public List<int> index_frd = new List<int>();
        Button group_create = new Button();
        Button frd_ad = new Button();
        bool group = false;
        List<List<control_friend>> group_frd = new List<List<control_friend>>();
        List<int> group_index = new List<int>();
        string path = null;
        public List<string> frd_list = new List<string>();
        public List<string> apply_frd = new List<string>();
        public List<int> apply_id = new List<int>();
        public List<string> group_name = new List<string>();
        public bool group_name_change;
        public List<group_talk> grouptalk = new List<group_talk>();
        public List<control_friend> friend = new List<control_friend>();

        public int selected_frd;

        public List<PictureBox> picturebox = new List<PictureBox>();
        int current_pos = 0;
        List<int> gif_y = new List<int>();
        List<int> gif_x = new List<int>();
        List<int> gif_id = new List<int>();
        int send_type;

        int current_group_x = 60;
        int current_group_y = 50;

        public Client_Form()
        {
            InitializeComponent();
            appear = true;
            this.Opacity = 0.0;
            timer1.Enabled = true;
            this.TransparencyKey = this.BackColor;
            timer1.Start();
            watch();

            control_local_test.lb_name.Click += new EventHandler(control_friend_lbclick);
            control_local_test.pb_photo.Click += new EventHandler(control_friend_pbclick);
            control_local_test.Click += new EventHandler(control_friend_backclick);

            msgshow = new MsgShow(ShowMsg);
            shake = new Shake(form_shake);
            sdshow = new SaveDialogShow(ShowSaveDialog);
            bg_form = new bg_form();
            sfd = new SaveFileDialog();
            control_local_test.lb_name.Text = "本机测试";
            gif_show = new showgif(rec_show_gif);
            gif_panel.SendToBack();
            isgif = false;
            changed = false;
            accept_frd = false;
            timer5.Enabled = true;
            group_create.Text = "创建群";
            this.Controls.Add(group_create);
            group_create.Hide();
            group_create.Click += group_create_Click;
            frd_ad.Text = "邀请好友";
            this.Controls.Add(frd_ad);
            frd_ad.Click += frd_ad_Click;
            group = false;

            path = StudentNum;
            //apply_frd.Add("2012011493");
            friend.Add(control_local_test);
            friend[0].form = this;
            friend[0].index = 0;
            frd_list.Add(StudentNum);
            iplist.Add(IPAddress.Parse(GetLocalIP()));
            frd_list.Add("2012011493");
            iplist.Add(IPAddress.Parse("166.111.111.111"));

            timer3_Tick(this, null);
            group_name_change = false;
            control_local_test.islocal = true;
            boxlist.Add(this.tb_input);
            curr_box = tb_input;
        }
        void control_friend_lbclick(object sender, EventArgs e)
        {
            current_select = (control_friend)(sender as Label).Parent;
            this.tb_input = curr_box;
            //friend[0].reset();
            panel_toolstrip.Visible = true;
            panel_toolstrip.BringToFront();
            tb_output.Focus();
            string ip = GetLocalIP();
            connect(ip);
        }
        void control_friend_pbclick(object sender, EventArgs e)
        {
            current_select = (control_friend)(sender as PictureBox).Parent;
            this.tb_input = curr_box;

            friend[0].reset();
            panel_toolstrip.Visible = true;
            panel_toolstrip.BringToFront();
            tb_output.Focus();
            string ip = GetLocalIP();
            connect(ip);
        }
        void control_friend_backclick(object sender, EventArgs e)
        {
            current_select =(sender as control_friend);
            this.tb_input = curr_box;

            friend[0].reset();
            panel_toolstrip.Visible = true;
            panel_toolstrip.BringToFront();
            tb_output.Focus();
            string ip = GetLocalIP();
            connect(ip);
        }
        #region 事件
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (changed == true && group == false)
            {
                
            }
            else
            {
                if (changed == true && group == true)          
                {

                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (appear)
            {
                pictureBox7.Image.Dispose();
                pictureBox7.Image = null;
                pictureBox7.Refresh();
                appear = false;
            }
            else
            {
                pictureBox7.Image = new Bitmap("../../Resources/alarm.png");
                pictureBox7.Refresh();
                appear = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;
            want_befrd frd_wanting = new want_befrd();
            frd_wanting.form = this;
            timer5.Enabled = true;
            frd_wanting.apply_socket = apply_socket;
            frd_wanting.Show();
            frd_wanting.show_apply(apply_frd.Count, apply_frd, apply_id);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            string sd = null;
            byte[] ct_sd;
            if (accept_frd == true)
            {
                sd = "yes";
                ct_sd = System.Text.Encoding.UTF8.GetBytes(sd);

                //Type t = dict.ElementAt(0).GetType();

            }
        }

        private void pb_single_chat_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < index_frd.Count; j++)
            {
                this.Controls[j].Show();
            }
            for (int i = 0; i < group_index.Count; i++)
            {
                this.Controls[i].Hide();
            }
            this.group_create.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < index_frd.Count; j++)
            {
                this.Controls[j].Hide();
            }
            Point p = new Point(55, 56);
            group_create.Location = p;
            group_create.Width = 80;
            group_create.Height = 30;
            group_create.BringToFront();
            group_create.Show();
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
                    sockClient.Send(arrSendMsg); // 发送消息；  

                    byte[] arrFile = new byte[1024 * 1024 * 2];
                    int length = fs.Read(arrFile, 0, arrFile.Length);  // 将文件中的数据读到arrFile数组中；  
                    byte[] arrFileSend = new byte[length + 1];
                    arrFileSend[0] = 1; // 用来表示发送的是文件数据；  
                    Buffer.BlockCopy(arrFile, 0, arrFileSend, 1, length);
                    // 还有一个 CopyTo的方法，但是在这里不适合； 当然还可以用for循环自己转化；  
                    sockClient.Send(arrFileSend);// 发送数据到服务端；  
                }
            }
        }

        private void pb_snapshot_Click(object sender, EventArgs e)
        {
            ScreenForm screen = new ScreenForm();
            screen.copytoFather += new copyToFatherTextBox(copytoTextBox);
            screen.ShowDialog();
        }

        private void tb_output_KeyPress(object sender, KeyPressEventArgs e)
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
                send(send_type,sockClient);
                tb_output.Clear();
              //  tb_output.Controls.Remove(pic);
            }
        }

        private void pb_add_Click(object sender, EventArgs e)
        {
            Point p = new Point(this.pb_add.Width / 2, this.pb_add.Height / 2);
            contextMenuStrip1.Show(this.pb_add, p);
            timer3.Enabled = true;
            find frd = new find();
            frd.form = this;
            frd.Show();
            // while (true)

            //Button b = new Button();

            //this.Controls.Add(b);
            //b.BringToFront();
            /*panel1.Location = p;
            panel1.Controls.Add(fr);
            p.X = panel1.Location.X;
            p.Y = panel1.Location.Y;*/
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            gif_panel.BringToFront();

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            gif_panel.BringToFront();
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
            isgif = true;
            string s = "1/r/n";
            img = System.Text.Encoding.UTF8.GetBytes(s);
            this.gif_panel.SendToBack();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.04;//每次改变Form的不透明属性
            if (this.Opacity >= 1.0)  //当Form完全显示时，停止计时
            {
                this.timer1.Enabled = false;
            }
        }
        private void pb_exit_icon_Click(object sender, EventArgs e)
        {
            Server_Connect();
            string strMsg = "logout" + StudentNum;
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            sockClient.Send(arrMsg);
            threadServer = new Thread(RecMsg1);
            threadServer.IsBackground = false;
            timer2.Enabled = true;
            timer2.Start();
            threadServer.Start();
        }
        private void Client_Form_Paint(object sender, PaintEventArgs e)
        {
            SetWindowRegion();
        }

        private void panel_toolstrip_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X - panel_toolstrip.Location.X, -e.Y - panel_toolstrip.Location.Y);
        }

        private void panel_toolstrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
                bg_form.Location = mousePos;
            }
        }

        private void pb_maximize_icon_MouseMove(object sender, MouseEventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_active;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_active;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_active;
        }

        private void pb_maximize_icon_MouseLeave(object sender, EventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_inactive;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_inactive;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_inactive;
        }

        private void pb_minimize_icon_MouseMove(object sender, MouseEventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_active;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_active;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_active;
        }
        private void pb_exit_icon_MouseMove(object sender, MouseEventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_active;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_active;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_active;
        }

        private void pb_exit_icon_MouseLeave(object sender, EventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_inactive;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_inactive;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_inactive;
        }

        private void pb_minimize_icon_MouseLeave(object sender, EventArgs e)
        {
            pb_maximize_icon.Image = Communication.Properties.Resources.maximize_inactive;
            pb_minimize_icon.Image = Communication.Properties.Resources.minimize_inactive;
            pb_exit_icon.Image = Communication.Properties.Resources.exit_inactive;
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

        private void pb_minimize_icon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            bg_form.WindowState = FormWindowState.Minimized;
        }

        private void Client_Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void Client_Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
                bg_form.Location = mousePos;
            }
        }
        void frd_ad_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            inviting invite = new inviting();
            //invite.form = this;
            //invite.list_show();
        }
        void group_create_Click(object sender, EventArgs e)
        {
            group_name_input input = new group_name_input();
            timer6.Start();
            input.form = this;
            input.Show();
            group_talk gp = new group_talk();
            Point p = new Point();
            p.X = group_curr_x;
            p.Y = group_curr_y + 30;
            group_curr_y += 30;
            gp.Location = p;
            this.Controls.Add(gp);
            group_index.Add(this.Controls.Count - 1);
            gp.BringToFront();
            gp.frd_list = this.frd_list;
            gp.list_ip = this.iplist;
            gp.StudentNum = this.StudentNum;
            grouptalk.Add(gp);
            //throw new NotImplementedException();
        }
        #endregion

        void ShowSaveDialog(byte[] arrMsgRec, int length)
        {
            if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string fileSavePath = sfd.FileName;// 获得文件保存的路径；  
                // 创建文件流，然后根据路径创建文件；  
                using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                {
                    fs.Write(arrMsgRec, 1, length - 1);
                    ShowMsg("文件保存成功：" + fileSavePath,Color.Black,HorizontalAlignment.Center);
                }
            }
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


        
#region 初始化窗口

        private void Client_Form_Load(object sender, EventArgs e)
        {
            bg_form.Location = this.Location;
            bg_form.Size = this.Size;
            bg_form.Parent_Form = this;
            bg_form.StartPosition = this.StartPosition;
            bg_form.Location = this.Location;
            control_friend local_test = new control_friend();
            local_test.Location = new Point(55,0);
            local_test.Show();
            bg_form.Show();
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
#endregion
#region 通信
        private void watch()
        {
            // 创建负责监听的套接字，注意其中的参数；  
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 获得文本框中的IP对象；  
            string IP = GetLocalIP();
            IPAddress address = IPAddress.Parse(IP);
            // 创建包含ip和端口号的网络节点对象；  
            IPEndPoint endPoint = new IPEndPoint(address, 56433);
            try
            {
                // 将负责监听的套接字绑定到唯一的ip和端口上；  
                socketWatch.Bind(endPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show("异常：" + se.Message);
                return;
            }
            // 设置监听队列的长度；  
            socketWatch.Listen(10);
            // 创建负责监听的线程；  
            threadWatch = new Thread(WatchConnecting);
            threadWatch.IsBackground = true;
            threadWatch.Start();
            //}  
        }
        void WatchConnecting()
        {
            while (true)  // 持续不断的监听客户端的连接请求；  
            {
                // 开始监听客户端连接请求，Accept方法会阻断当前的线程； 
                Socket sokConnection = socketWatch.Accept(); // 一旦监听到一个客户端的请求，就返回一个与该客户端通信的 套接字；  
                // 想列表控件中添加客户端的IP信息；  
                //lbOnline.Items.Add(sokConnection.RemoteEndPoint.ToString());
                // 将与客户端连接的 套接字 对象添加到集合中；  
                //want_frd.Add(sokConnection.RemoteEndPoint.ToString());
                apply_socket.Add(sokConnection);
                dict.Add(sokConnection.RemoteEndPoint.ToString(), sokConnection);
                /*Thread req = new Thread(request);
                req.IsBackground = true;
                req.Start();*/
                //MessageBox.Show("客户端连接成功！");
                Thread thr = new Thread(RecMsg);
                thr.IsBackground = true;
                thr.Start(sokConnection);
                dictThread.Add(sokConnection.RemoteEndPoint.ToString(), thr);  //  将新建的线程 添加 到线程的集合中去。  
            }
        }

        void request()
        {

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
                    case 3: //接收到的是添加好友请求
                        {
                            timer4.Enabled = true;
                            apply_frd.Add(strMsg);
                            apply_id.Add(3);
                            break;
                        }
                    case 4: //接收到的是加群的请求
                        {
                            timer4.Enabled = true;
                            apply_frd.Add(strMsg);
                            apply_id.Add(4);
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
        void RecMsg1()
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
                //MessageBox.Show(se.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            string strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 0, length);
            if (strMsg == "loo")
            {
                finish = true;
            }
        }
        void Server_Connect()
        {
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
        }
        #endregion

        
        public void ShowMsg(string str,Color color,HorizontalAlignment direction)
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
                for (int i = 0; i <gif_x.Count; i++)
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
        public void connect(string ipAddress)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            IPEndPoint endPoint = new IPEndPoint(ip, 56433);
            sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sockClient.Connect(endPoint);
            }
            catch (SocketException se)
            {
                //MessageBox.Show(se.Message);
                return;
            }
            /*threadClient = new Thread(RecMsg);
            threadClient.IsBackground = true;
            threadClient.Start();*/

        }
        private void send(int type,Socket socket)           //好友账号
        {
            Font oldFont = this.tb_input.SelectionFont;
            string strMsg = tb_output.Text;
            //tb_input.SelectionFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            this.Invoke(msgshow, new object[] { StudentNum+"  "+ DateTime.Now.ToLongTimeString().ToString() +"\n",Color.Blue,HorizontalAlignment.Right});
            //tb_input.SelectionFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
            this.Invoke(msgshow, new object[] { strMsg ,Color.Black,HorizontalAlignment.Right});
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (finish == true)
            {
                this.Opacity -= 0.04;//每次改变Form的不透明属性
                if (this.Opacity <= 0.0)  //当Form完全显示时，停止计时
                {
                    if (threadWatch != null)
                        threadWatch.Suspend();
                    if(threadClient != null)
                        threadClient.Suspend();
                    foreach (Thread value in dictThread.Values)
                    {
                        if (value != null)
                            value.Suspend();
                    }
                    foreach (Socket key in dict.Values)
                    {

                        key.Close();

                    }
                    socketWatch.Close();
                    sockClient.Close();
                    
                    
                    this.timer1.Enabled = false;
                    Application.Exit();
                }
            }
        }

        private void Client_Form_Activated(object sender, EventArgs e)
        {
            if (bg_form.WindowState == FormWindowState.Minimized)
                bg_form.WindowState = FormWindowState.Normal;
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

        private void pb_shake_Click(object sender, EventArgs e)
        {
            byte[] arrSendMsg;
            arrSendMsg = new byte[1];
            arrSendMsg[0] = 5;
            sockClient.Send(arrSendMsg); // 发送消息； 
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (group_name_change == true)
            {
                grouptalk[grouptalk.Count - 1].label1.Text = group_name[grouptalk.Count - 1];
                group_name_change = false;
            }
        }

        private void pb_expression_Click(object sender, EventArgs e)
        {
            gif_panel.BringToFront();
        }
        public string GetLocalIP()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    return (nic["IPAddress"] as String[])[0];
                }
            }
            return null;

        }

        private void scroll(object sender, EventArgs e)
        {
            Point p_top = new Point();
            Point []p = new Point[picturebox.Count];
            
            
            p_top = this.tb_input.GetPositionFromCharIndex(0);
            for (int i = 0; i < p.Length; i++)
            {
                p[i].X = gif_x[i] - 10;
                p[i].Y = gif_y[i] + p_top.Y;
                this.tb_input.Controls[gif_id[i]].Location = p[i];
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
        void form_shake()
        {
            count = 0;
            shake_timer.Start();
        }
        private void pb_file_Click(object sender, EventArgs e)
        {

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

        private void Client_Form_LocationChanged(object sender, EventArgs e)
        {
            this.bg_form.Location = this.Location;
        }

        public void addnewfrd(string str, int id, Socket socket)
        {
            if (id == 3)
            {
                string record = path;
                control_friend fd = new control_friend();
                Point p = new Point();
                p.X = current_x;
                p.Y = current_y + 50;
                current_y += 50;
                fd.Location = p;
                this.Controls.Add(fd);
                fd.BringToFront();
                fd.form = this;
                //fd.mypanel.Location = this.panel_toolstrip.Location;
                //fd.mypanel.Visible = true;
                //this.Controls.Add(fd.mypanel);
                fd.panel_index = this.Controls.Count - 1;
                fd.index = friend.Count;
                fd.chatting_socket = socket;
                friend.Add(fd);
                timer3.Enabled = false;
                index_frd.Add(this.Controls.Count - 1);
                path += "./" + frd_list[frd_list.Count - 1] + ".txt";
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                sockClient = socket;
            }
            else
            {
                if (id == 4)
                {
                    group_talk gt = new group_talk();
                    grouptalk.Add(gt);
                    List<control_friend> frd_list = new List<control_friend>();
                    group_frd.Add(frd_list);
                    control_friend fd = new control_friend();
                    Point p = new Point();
                    p.X = current_group_x;
                    p.Y = current_group_y;
                    gt.Location = p;
                    this.Controls.Add(gt);
                    gt.BringToFront();
                    
                }
            }
        }

    }
}
