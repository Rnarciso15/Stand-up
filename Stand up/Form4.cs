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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int q = 0;
        int u = 0;
        private void inserirEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            if (q == 0)
            {
                guna2HtmlLabel1.Location = new Point(326, 353);
                guna2HtmlLabel1.Text = "Cancelar";               
                guna2TextBox1.Visible = true;
                guna2Button1.Visible = true;
                label3.Visible = true;
                guna2Button2.Visible = true;
                q += 1;
            }
            else
            {

                guna2HtmlLabel1.Location = new Point(302, 311);
                guna2HtmlLabel1.Text = "Mudar Senha";
                guna2TextBox1.Visible = false;
                guna2Button1.Visible = false;
                label3.Visible = false;
                guna2Button2.Visible = false;
                q = 0;
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Location = new Point(302, 311);
            guna2TextBox1.UseSystemPasswordChar = true;
        }

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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
