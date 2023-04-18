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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        DateTime data;
        private void button1_Click(object sender, EventArgs e)
        {
         

            int paragrafos = Convert.ToInt32(textBox3.Text);
            string modelo;
            string fullText = textBox1.Text;
            for(int i = 1; i  < paragrafos; i++)
            {

                string desiredParagraph = fullText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)[i];

                modelo = desiredParagraph;
                int x = BLL.veiculos.insert_modelo(textBox2.Text, modelo, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));


            }
                    
            textBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {

                WindowState = FormWindowState.Maximized;

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
