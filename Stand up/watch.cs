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
    public partial class watch : Form
    {
        public watch()
        {
            InitializeComponent();
        }
        
private void watch_Load(object sender, EventArgs e)
        {
            timer1.Start();
            DoubleBuffered = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {

                WindowState = FormWindowState.Maximized;          
            
            }
        }
    }
}
