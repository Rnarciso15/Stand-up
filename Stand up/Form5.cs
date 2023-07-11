using BusinessLogicLayer;
using Guna.UI2.WinForms;
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
        static public string admin;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try { 
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
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
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
            try { 
            this.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try { 
                for (int j = 0; j < guna2TextBox3.Text.Length; j++)
                {
                    if (guna2TextBox3.Text[j] == '0' || guna2TextBox3.Text[j] == '1' || guna2TextBox3.Text[j] == '2' || guna2TextBox3.Text[j] == '3' || guna2TextBox3.Text[j] == '4' || guna2TextBox3.Text[j] == '5' || guna2TextBox3.Text[j] == '6' || guna2TextBox3.Text[j] == '7' || guna2TextBox3.Text[j] == '8' || guna2TextBox3.Text[j] == '9')
                    {
                    }
                    else
                    {
                        guna2TextBox3.Clear();
                        MessageBox.Show("Dados incorretos");
                    }
                }
         

            if (guna2TextBox3.Text != "" && guna2TextBox3.Text != "")
            {
                DataTable x = BLL.Func.login(Convert.ToInt32(guna2TextBox3.Text), Hash(guna2TextBox1.Text));
                if(x.Rows.Count > 0)
                {
                    n_func = Convert.ToInt32(guna2TextBox3.Text);
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                    admin = BLL.Func.Buscar_admin(n_func);
                }
                else
                {
                    guna2TextBox3.Clear();
                    guna2TextBox1.Clear();
                    MessageBox.Show("Dados incorretos");
                }
            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try { 
            guna2TextBox1.UseSystemPasswordChar = true;
            DoubleBuffered = true;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }
    }
}
