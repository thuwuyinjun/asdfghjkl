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
    public partial class group_name_input : Form
    {
        public Client_Form form;
        public group_name_input()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.group_name.Add(this.textBox1.Text);
            form.group_name_change = true;
            this.Close();
        }
    }
}
