﻿using BusinessLogicLayer;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using iTextSharp.text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stand_up
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try { 
            guna2DataGridView1.DataSource = BLL.transacoes.loadTrans();
            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            timer1.Start();
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        int ano;
        int i = 0;
        int t = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int j = 0;

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            try { 
            Form1.flagCancTransacao = true;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            try { 
            if (d == 0)
            {
                guna2TextBox1.Clear();
                guna2Button32.FillColor = Color.DodgerBlue;
                d += 1;

                guna2Button3.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button4.FillColor = Color.Silver;
                t = 0;
                a = 0;
                b = 0;
                j = 0;
            }
            else
            {

                guna2Button32.FillColor = Color.Silver;
                d = 0;

            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            try { 
            if (d != 0 || t != 0 || a != 0 || b !=0) {

                guna2TextBox1.Enabled = true;

                if (d == 1)
            {
                guna2DataGridView1.DataSource = BLL.transacoes.queryFunc_Like_NIF(guna2TextBox1.Text);
            }
            if (t == 1)
            {
                guna2DataGridView1.DataSource = BLL.transacoes.queryFunc_Like_N_Matricula(guna2TextBox1.Text);
            }
            if (a == 1)
            {
                guna2DataGridView1.DataSource = BLL.transacoes.queryFunc_Like_N_data(guna2TextBox1.Text);
            }
            if (b == 1)
            {
                guna2DataGridView1.DataSource = BLL.transacoes.queryFunc_Like_N_valor(guna2TextBox1.Text);
            }

            }
            else
            {
                guna2TextBox1.Clear();
                guna2Button5.Visible=false;
                guna2TextBox1.Enabled = false;
                guna2DataGridView1.DataSource = BLL.transacoes.loadTrans();
            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try { 
            if (t == 0)
            {
                guna2TextBox1.Clear();
                guna2Button3.FillColor = Color.DodgerBlue;
                t += 1;

                guna2Button2.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button4.FillColor = Color.Silver;
                d = 0;
                a = 0;
                b = 0;
                j = 0;
                guna2Button5.Visible = true;
               


            }
            else
            {

                guna2Button5.Visible = false;
                guna2Button3.FillColor = Color.Silver;
                t = 0;

            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try { 
            if (a == 0)
            {
                guna2TextBox1.Clear();
                guna2Button2.FillColor = Color.DodgerBlue;
                a += 1;

                guna2Button3.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button4.FillColor = Color.Silver;
                d = 0;
                t = 0;
                b = 0;
                j = 0;
                guna2Button5.Visible = true;
            }
            else
            {

                guna2Button2.FillColor = Color.Silver;
                a = 0;
                guna2Button5.Visible = false;

            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try { 
            if (b == 0)
            {
                guna2TextBox1.Clear();
                guna2Button4.FillColor = Color.DodgerBlue;
                b += 1;

                guna2Button2.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;
                d = 0;
                a = 0;
                t = 0;
                j = 0;
            }
            else
            {

                guna2Button4.FillColor = Color.Silver;
                b = 0;

            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }
        int yy = 0;
        int jj = 0;

        string ano1 = "";
        string matricula = "";
        string[] words;
        string numeros = "";
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (a == 1)
            {


                if (guna2TextBox1.Text.Length == 6)
                {

                    string mes = guna2TextBox1.Text[3].ToString() + guna2TextBox1.Text[4].ToString();
                    if (mes == "01" || mes == "02" || mes == "03" || mes == "04" || mes == "05" || mes == "06" || mes == "07" || mes == "08" || mes == "09" || mes == "10" || mes == "11" || mes == "12")
                    {
                        string dia = guna2TextBox1.Text[0].ToString() + guna2TextBox1.Text[1].ToString();
                        if (mes == "01" || mes == "03" || mes == "05" || mes == "07" || mes == "08" || mes == "10" || mes == "12")
                        {
                            if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                            {

                            }
                            else
                            {
                                MessageBox.Show("insira um dia válido");
                                guna2TextBox1.Clear();
                                i = 0;
                            }
                        }
                        if (mes == "04" || mes == "06" || mes == "09" || mes == "11")
                        {

                            if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30")
                            {

                            }
                            else
                            {
                                MessageBox.Show("insira um dia válido");
                                guna2TextBox1.Clear();
                                i = 0;
                            }

                        }
                        if (mes == "02")
                        {
                            if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28")
                            {

                            }
                            else
                            {
                                MessageBox.Show("insira um dia válido");
                                guna2TextBox1.Clear();
                                i = 0;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("insira um mês válido");
                        guna2TextBox1.Clear();
                        i = 0;
                    }

                }
                if (guna2TextBox1.Text.Length == 3)
                {

                    string dia = guna2TextBox1.Text[0].ToString() + guna2TextBox1.Text[1].ToString();

                    if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                    {

                    }
                    else
                    {
                        MessageBox.Show("insira um dia válido");
                        guna2TextBox1.Clear();
                        i = 0;
                    }

                }
                if (guna2TextBox1.Text.Length == 10)
                {
                    i = 1;

                    DateTime data = DateTime.ParseExact(guna2TextBox1.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                    ano = data.Year;
                    if (data.Year >= DateTime.Now.Year || data.Year <= 1931)
                    {
                        MessageBox.Show("insira um ano válido");
                        guna2TextBox1.Clear();
                        i = 0;
                    }



                }

                if (guna2TextBox1.Text.Length < 2)
                {
                    i = 0;
                }
                if (guna2TextBox1.Text.Length == 2 || guna2TextBox1.Text.Length == 5)
                {
                    if (i != 1)
                    {
                        guna2TextBox1.Text += "/";
                        guna2TextBox1.Select(guna2TextBox1.Text.Length, 0);
                    }
                }
            }

            if (t == 1)
            {
                if (guna2TextBox1.Text.Length < 2 || guna2TextBox1.Text.Length > 3 && guna2TextBox1.Text.Length < 5 || guna2TextBox1.Text.Length > 6 && guna2TextBox1.Text.Length < 8)
                {
                    jj = 0;
                }
                if (guna2TextBox1.Text.Length == 2 || guna2TextBox1.Text.Length == 5)
                {
                    if (jj != 1)
                    {
                        guna2TextBox1.Text += "-";
                        guna2TextBox1.Select(guna2TextBox1.Text.Length, 0);
                    }

                }
                if (guna2TextBox1.Text.Length == 0)
                {
                    jj = 0;
                }
            }
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }

        }
  

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try { 
            guna2TextBox1.Clear();
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
        
    

