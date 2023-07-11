using BusinessLogicLayer;
using Guna.UI2.WinForms;
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
            try { 
            timer1.Start();
            DoubleBuffered = true;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try { 
            label1.Text = DateTime.Now.ToString("T");
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try { 
            if (WindowState == FormWindowState.Normal) {

                WindowState = FormWindowState.Maximized;          
            
            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }
    }
}
