using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stand_up
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        int u = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (u == 0)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
                guna2Button1.Image = Properties.Resources.show1;
                u += 1;
            }
            else
            {
                guna2TextBox1.UseSystemPasswordChar = true;
                guna2Button1.Image = Properties.Resources.invisible1;
                u = 0;
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
