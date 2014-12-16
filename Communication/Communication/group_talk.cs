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

namespace Communication
{
    public partial class group_talk : UserControl
    {
        public List<control_friend> group = new List<control_friend>();
        public List<string> frd_list = new List<string>();
        public List<IPAddress> list_ip = new List<IPAddress>();
        public string StudentNum;
        public group_talk()
        {
            InitializeComponent();
        }

        private void group_talk_Load(object sender, EventArgs e)
        {
            group_chat chatting = new group_chat();
            chatting.Show();
            chatting.frd_list = this.frd_list;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            group_chat chatting = new group_chat();
            chatting.Show();
            chatting.frd_list = this.frd_list;
            chatting.frd_IP = this.list_ip;
            chatting.StudentNum = StudentNum;
            chatting.groupname = this.label1.Text;
        }
    }
}
