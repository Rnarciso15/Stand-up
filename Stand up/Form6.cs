using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
namespace Stand_up
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = BLL.Func.Load();
        }
        int t = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int j = 0;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (t == 0)
            {
                guna2Button3.FillColor = Color.DodgerBlue;
                t += 1;

            }
            else
            {

                guna2Button3.FillColor = Color.Silver;
                t = 0;

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                guna2Button2.FillColor = Color.DodgerBlue;
                a += 1;

            }
            else
            {

                guna2Button2.FillColor = Color.Silver;
                a = 0;

            }
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            if (b == 0)
            {
                guna2Button32.FillColor = Color.DodgerBlue;
                b += 1;

            }
            else
            {

                guna2Button32.FillColor = Color.Silver;
                b = 0;

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (c == 0)
            {
                guna2Button4.FillColor = Color.DodgerBlue;
                c += 1;

            }
            else if (c == 1)
            {
                guna2Button4.FillColor = Color.DarkRed;
                c += 1;

            }
            else
            {

                guna2Button4.FillColor = Color.Silver;
                c = 0;

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (d == 0)
            {
                guna2Button5.FillColor = Color.DodgerBlue;
                d += 1;
 
                guna2Button6.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

            }
            else
            {

                guna2Button5.FillColor = Color.Silver;
                d = 0;

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (j == 0)
            {
                guna2Button6.FillColor = Color.DodgerBlue;
                j += 1;
                guna2Button5.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

            }
            else
            {

                guna2Button6.FillColor = Color.Silver;
                j = 0;

            }
        }
    }
}
