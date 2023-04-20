using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        static public int n_func;
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
        static string Hash(string input)

        {

            using (SHA1Managed sha1 = new SHA1Managed())

            {

                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder(hash.Length * 2);



                foreach (byte b in hash)

                {

                    // can be "x2" if you want lowercase

                    sb.Append(b.ToString("X2"));

                }



                return sb.ToString();

            }

        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable x = BLL.Func.login(Convert.ToInt32(guna2TextBox3.Text), Hash(guna2TextBox1.Text));
            if(x.Rows.Count > 0)
            {
                n_func = Convert.ToInt32(guna2TextBox3.Text);
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();

            }
            else
            {
                guna2TextBox1.Clear();
                guna2TextBox3.Clear();
                MessageBox.Show("Dados incorretos");

            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            guna2TextBox1.UseSystemPasswordChar = true;
        }
    }
}
