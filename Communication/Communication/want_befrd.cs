﻿using System;
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

namespace Communication
{
    public partial class want_befrd : Form
    {
        int current_x = 0;
        int current_y = 12;
        int width = 280;
        int height = 100;
        int dy = 120;
        int i;
        public Client_Form form;
        int total;
        List<string> wait_ack = new List<string>();
        public List<Socket> apply_socket = new List<Socket>();
        public List<string> apply_frd = new List<string>();
        public List<int> apply_id = new List<int>();

        public List<Socket> accept_socket = new List<Socket>();
        public List<string> accept_frd = new List<string>();
        public List<int> accept_id = new List<int>();

        public RichTextBox box = new RichTextBox();

        public want_befrd()
        {
            InitializeComponent();
            i = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.boxlist.Add(box);
            form.accept_frd = true;
            form.frd_list.Add(wait_ack[i]);
            form.addnewfrd(wait_ack[i], 3, apply_socket[i]);
            form.tb_input = box;
            this.Controls[i].Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form.accept_frd = false;
            this.Controls[i].Enabled = false;
        }

        public void show_apply(int num, List<string> apply, List<int> apply_id)
        {
            wait_ack = apply;
            Point p = new Point();
            for (i = 0; i < apply.Count; i++)
            {
                Panel panel = new Panel();
                p.X = current_x;
                p.Y = current_y;
                current_y += dy;
                panel.Width = 280;
                panel.Height = 100;
                this.Controls.Add(panel);
                panel.BringToFront();

                Label label = new Label();
                if (apply_id[i] == 3)
                {
                    label.Text = apply[i] + "想加您为好友";
                    accept_socket.Add(apply_socket[i]);
                    accept_frd.Add(apply_frd[i]);
                    accept_id.Add(apply_id[i]);
                }
                else
                {
                    if (apply_id[i] == 4)
                    {
                        string frd = apply[i].Substring(0, 10);
                        string name = apply[i].Substring(10, apply[i].Length - 10);
                        label.Text = frd + "想加您进入群" + name;
                        accept_socket.Add(apply_socket[i]);
                        accept_frd.Add(apply_frd[i]);
                        accept_id.Add(apply_id[i]);
                    }
                }
                label.Font = new Font("宋体", 12);
                p.X = 39;
                p.Y = 20;
                label.Location = p;
                label.Width = 204;
                label.Height = 40;
                this.Controls[i].Controls.Add(label);
                label.BringToFront();

                Button button1 = new Button();
                button1.Text = "确认";
                p.X = 40;
                p.Y = 74;
                button1.Location = p;
                button1.Width = 75;
                button1.Height = 23;
                this.Controls[i].Controls.Add(button1);
                button1.Click += button1_Click;
                button1.BringToFront();

                Button button2 = new Button();
                button2.Text = "拒绝";
                button2.Width = 75;
                button2.Height = 23;
                p.X = 167;
                p.Y = 74;
                button2.Location = p;
                this.Controls[i].Controls.Add(button2);
                button2.Click += button2_Click;
                button2.BringToFront();
            }
            for (int i = 0; i < accept_frd.Count; i++)
            {
                string str = "yes";
                byte [] sd = System.Text.Encoding.UTF8.GetBytes(str);
                form.apply_socket.Remove(accept_socket[i]);
                form.apply_id.Remove(accept_id[i]);
                form.apply_frd.Remove(accept_frd[i]);
                accept_socket[i].Send(sd);
            }
        }
    }
}
