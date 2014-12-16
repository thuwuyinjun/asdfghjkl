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

namespace Communication
{
    public partial class inviting : Form
    {
        public group_chat chatting = new group_chat();
        public List<IPAddress> frd_ip = new List<IPAddress>();
        Dictionary<IPAddress, Socket> dict = new Dictionary<IPAddress, Socket>();
        public string StudentNum;
        public string groupname;
        Thread thr;
        int current_x = 103;
        int current_y = 62;

        public inviting()
        {
            InitializeComponent();
            this.listView1.GridLines = false;
            this.listView1.FullRowSelect = true;
            this.listView1.View = View.Details;
            this.listView1.Scrollable = true;
            this.listView1.MultiSelect = false;
            this.listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            this.listView2.Columns.Add("", 20, HorizontalAlignment.Center);
            this.listView2.Columns.Add("好友账户", 50, HorizontalAlignment.Center);
            this.listView2.Visible = true;
            this.listView2.GridLines = false;
            this.listView2.FullRowSelect = true;
            this.listView2.View = View.Details;
            this.listView2.Scrollable = true;
            this.listView2.MultiSelect = false;
            this.listView2.HeaderStyle = ColumnHeaderStyle.Clickable;
        }

        public void request()
        {
            string str = StudentNum + "/" + groupname;
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] tp = new byte[temp.Length + 1];
            byte[] rec = new byte[100];
            int length;
            tp[0] = 4;
            Buffer.BlockCopy(temp, 0, tp, 1, temp.Length);
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                IPAddress ip = frd_ip[i];
                IPEndPoint end = new IPEndPoint(ip, 56433);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socket.Connect(end);
                dict.Add(frd_ip[i], socket);
                //socket.Send(tp);
               // length = socket.Receive(rec);
                //string strMsg = System.Text.Encoding.UTF8.GetString(rec, 1, length - 1);
               // if (strMsg == "yes")
                {
                    chatting.sel_frd.Add(listView2.Items[i].SubItems[1].Text);
                    chatting.sel_IP.Add(frd_ip[i]);
                    control_friend fd = new control_friend();
                    Point p = new Point();
                    p.X = current_x;
                    p.Y = current_y + 50;
                    current_y += 50;
                    fd.Location = p;
                    chatting.Controls.Add(fd);
                    fd.BringToFront();
                    //显示
                }
               // else
                {
                    //显示
                }
            }
        }
        private void select(object sender, EventArgs e)
        {
            String str = this.listView1.SelectedItems[0].SubItems[1].Text;
            ListViewItem item = new ListViewItem();
            item.ImageIndex = 0;
            item.SubItems.Add(str);
            this.listView2.Items.Add(item);
            item.EnsureVisible();
            this.listView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thr = new Thread(new ThreadStart(request));
            int i = 0;
            chatting.sel_frd.Add(listView2.Items[i].SubItems[1].Text);
            chatting.sel_IP.Add(frd_ip[i]);
            control_friend fd = new control_friend();
            Point p = new Point();
            p.X = current_x;
            p.Y = current_y + 50;
            current_y += 50;
            fd.Location = p;
            chatting.Controls.Add(fd);
            fd.BringToFront();
            this.Close();
        }
    }
}
