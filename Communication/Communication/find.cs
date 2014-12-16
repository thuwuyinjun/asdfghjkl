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
using System.IO;

namespace Communication
{
    public partial class find : Form
    {
        public string str = null;
        Socket socket;
        Socket fr_socket;
        public bool clicked = false;
        int num;
        public control_friend new_frd = new control_friend();
        public Client_Form form;

        public RichTextBox box = new RichTextBox();
        public find()
        {
            InitializeComponent();
            button1.Enabled = false;
            clicked = false;
        }

        private void frd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                num = Int32.Parse(frd.Text);
                if ((num > 2012000000) && (num <= 2012999999))
                {
                    button1.Enabled = true;
                }
            }
            catch
            {
                errorProvider1.SetError(frd, "input error");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string send_message = null;
            byte[] rec = new byte[20];
            byte[] send;
            byte[] sd;
            int lenth = -1;
            Point p = new Point();
            str = "q" + num.ToString();
            IPAddress ip = IPAddress.Parse("166.111.180.60");
            IPEndPoint endPoint = new IPEndPoint(ip, 8000);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(endPoint);
                socket.Send(System.Text.Encoding.UTF8.GetBytes(str));
                lenth = socket.Receive(rec);
                string temp = System.Text.Encoding.UTF8.GetString(rec);
                if (temp.Substring(0, 1) != "n")
                {
                    IPAddress IP = IPAddress.Parse(temp.Substring(0, lenth - 4));
                    endPoint = new IPEndPoint(IP, 56433);
                    fr_socket.Connect(endPoint);
                    send_message = form.StudentNum;       //改为本用户名
                    sd = System.Text.Encoding.UTF8.GetBytes(send_message);
                    send = new byte[sd.Length + 1];
                    send[0] = 3;
                    Buffer.BlockCopy(sd, 0, send, 1, sd.Length);
                    fr_socket.Send(send);
                    lenth = fr_socket.Receive(rec);
                    temp = System.Text.Encoding.UTF8.GetString(rec);
                    if (temp == "yes")
                    {
                        errorProvider1.Clear();
                        form.changed = true;
                        form.iplist.Add(IP);
                        form.frd_list.Add(num.ToString());
                        form.addnewfrd(num.ToString(), 3, socket);
                        form.tb_input = box;
                        MessageBox.Show("添加好友成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("好友拒绝了您的邀请");
                    }
                    // string fr_list = "好友列表,txt";
                    // FileStream file = new FileStream(fr_list, FileMode.OpenOrCreate);
                    //StreamWriter wt = new StreamWriter(file);
                    //   wt.Write("2012011493");
                    /*p.X = 55;
                    p.Y = Client_Form.list.Count * 50;
                    new_frd.Location = p;
                    new_frd.BringToFront();*/
                    //  Client_Form.changed = true;
                    //  Login_Form.list.Add(new_frd);

                }
                else
                {
                    MessageBox.Show("您搜索的好友不在线");
                }
            }
            catch
            {
                MessageBox.Show("系统服务器异常！");
            }
        }
      } 
}
