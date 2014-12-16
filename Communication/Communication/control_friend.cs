using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Communication
{
    public partial class control_friend : UserControl
    {
        public string name;
        public Client_Form form;
        public bool selected;
        public Color[] backcolor = new Color[3];
        public int index;
       // public chatting_panel mypanel = new chatting_panel();
        public int panel_index;
        public Socket chatting_socket;
        //public chatting_panel panel = new chatting_panel();
        public bool islocal;
        Thread thread;
        public RichTextBox box = new RichTextBox();

        public control_friend()
        {
            InitializeComponent();
            selected = false;
            backcolor[0] = this.BackColor;
            backcolor[1] = this.lb_name.BackColor;
            backcolor[2] = this.pb_photo.BackColor;
            
        }

        public void whether_online()
        {
            if (!islocal)
            {
                IPAddress ip = IPAddress.Parse("166.111.180.60");
                string sd;
                byte[] query = new byte[20];
                int length;
                string rec;
                IPEndPoint endPoint = new IPEndPoint(ip, 8000);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                while (true)
                {
                    try
                    {
                        socket.Connect(endPoint);
                    }
                    catch (SocketException se)
                    {
                        MessageBox.Show(se.Message);
                        return;
                    }
                    sd = "q" + name;
                    socket.Send(System.Text.Encoding.UTF8.GetBytes(sd));
                    length = socket.Receive(query);
                    rec = System.Text.Encoding.UTF8.GetString(query, 0, length);
                    if (rec == "n")
                    {
                        MessageBox.Show("好友已下线！");
                        chatting_socket.Close();
                    }
                }
            }
        }
        private void lb_name_Click(object sender, EventArgs e)
        {
            name = lb_name.Text;
            this.BackColor = Color.Silver;
            lb_name.BackColor = Color.Silver;
            pb_photo.BackColor = Color.Silver;
            selected = true;
            form.selected_frd = index;
            reset();
            form.Controls[panel_index].Visible = true;
            form.Controls[panel_index].BringToFront();
            if (!islocal)
            {
                thread = new Thread(whether_online);
                thread.IsBackground = true;
                thread.Start();
            }
            form.connect(form.iplist[index].ToString());
        }

        private void pb_photo_Click(object sender, EventArgs e)
        {
            name = lb_name.Text;
            this.BackColor = Color.Silver;
            lb_name.BackColor = Color.Silver;
            pb_photo.BackColor = Color.Silver;

            selected = true;
            form.selected_frd = index;
            reset();
            form.Controls[panel_index].Visible = true;
            form.Controls[panel_index].BringToFront();
            form.connect(form.iplist[index].ToString());
        }
        private void control_friend_Click(object sender, EventArgs e)
        {
            name = lb_name.Text;
            this.BackColor = Color.Silver;
            lb_name.BackColor = Color.Silver;
            pb_photo.BackColor = Color.Silver;
            selected = true;
            reset();
            form.selected_frd = index;
            form.Controls[panel_index].Visible = true;
            form.Controls[panel_index].BringToFront();
            form.connect(form.iplist[index].ToString());
        }

        public void reset()
        {

            for (int j = 0; j < form.friend.Count; j++)
            {
                if (j != form.selected_frd)
                {
                    form.friend[j].BackColor = form.friend[j].backcolor[0];
                    form.friend[j].lb_name.BackColor = form.friend[j].backcolor[1];
                    form.friend[j].pb_photo.BackColor = form.friend[j].backcolor[2];
                    form.Controls[form.friend[j].panel_index].SendToBack();
                }
            }
            if (form.selected_frd != 0)
            {
                form.panel_toolstrip.SendToBack();
            }
        }
    }
}
