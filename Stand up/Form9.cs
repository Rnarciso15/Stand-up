using BusinessLogicLayer;
using Guna.UI2.WinForms;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            guna2DataGridView1.DataSource = BLL.transacoes.loadTrans();
            timer1.Start();
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
            Form1.flagCancTransacao = true;
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (t== 0)
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
            }
            else
            {

                guna2Button2.FillColor = Color.Silver;
                a = 0;

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
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
        int yy = 0;
        int jj = 0;
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
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
            if (t == 1) { 
            }
            
            if (guna2TextBox1.Text.Length < 8 && guna2TextBox1.Text.Length > 5 || guna2TextBox1.Text.Length > 8 && guna2TextBox1.Text.Length < 11 || guna2TextBox1.Text.Length > 11 && guna2TextBox1.Text.Length < 14)
            {
                yy = 0;
            }
            if (guna2TextBox1.Text.Length == 7 || guna2TextBox1.Text.Length == 10)
            {
                if (yy != 1)
                {
                    guna2TextBox1.Text += "-";
                    guna2TextBox1.Select(guna2TextBox1.Text.Length, 0);
                }

            }
            if (guna2TextBox1.Text.Length == 5)
            {
                yy = 0;
            }
            guna2TextBox1.MaxLength = 13;
            if (jj == 0)
            {         
            MessageBox.Show("Insira o ano do veiculo e em seguida insira a matricula"+", EX.:(2020 AA-00-AA)");
                jj = 1;
            }

            if (guna2TextBox1.Text.Length == 13)
            {         
            string phrase = guna2TextBox1.Text;
            string[] words = phrase.Split(' ');
            string ano1  = words[0];
            string matricula = words[1];
                if (ano1 != "")
                {



                    for (int j = 0; j < ano1.Length; j++)
                    {

                        if (ano1[j] == '0' || ano1[j] == '1' || ano1[j] == '2' || ano1[j] == '3' || ano1[j] == '4' || ano1[j] == '5' || ano1[j] == '6' || ano1[j] == '7' || ano1[j] == '8' || ano1[j] == '9')
                        {

                        }
                        else
                        {

                            guna2TextBox1.Clear();
                            MessageBox.Show("Insira um ano válido");
                        }

                    }


                }
                if (matricula != "")
                {

           
                if (Convert.ToInt32(ano1) >= 1932 && Convert.ToInt32(ano1) <= 1992)
                {
                    
                        for (int l = 0; l < 2; l++)
                        {
                            if (matricula[l] == '0' || matricula[l] == '1' || matricula[l] == '2' || matricula[l] == '3' || matricula[l] == '4' || matricula[l] == '5' || matricula[l] == '6' || matricula[l] == '7' || matricula[l] == '8' || matricula[l] == '9')
                            {
                                MessageBox.Show("Tem de usar o formato AA-00-00, devido à idade do seu carro ");
                                matricula="";
                            matricula = ano1 + " "+matricula;
                                break;

                            }
                            else
                            {

                            }

                        }
                  

                        for (int o = 3; o < 5; o++)
                        {
                            if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                            {

                            }
                            else
                            {

                                MessageBox.Show("Tem de usar o formato AA-00-00, devido á idade do seu carro ");
                            matricula = "";
                            matricula = ano1 + " " + matricula;
                            break;
                            }

                        }
            
                    
                        for (int o = 7; o < 8; o++)
                        {
                            if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                            {

                            }
                            else
                            {

                                MessageBox.Show("Tem de usar o formato AA-00-00, devido á idade do seu carro ");
                            matricula = "";
                            matricula = ano1 + " " + matricula;
                            break;
                            }

                    
                    }
                }


                if (Convert.ToInt32(ano1) >= 1993 && Convert.ToInt32(ano1) <= 2005)
                {
                   
                        for (int l = 0; l < 2; l++)
                        {
                            if (matricula[l] == '0' || matricula[l] == '1' || matricula[l] == '2' || matricula[l] == '3' || matricula[l] == '4' || matricula[l] == '5' || matricula[l] == '6' || matricula[l] == '7' || matricula[l] == '8' || matricula[l] == '9')
                            {


                            }
                            else
                            {
                                MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                            matricula = "";
                            matricula = ano1 + " " + matricula;
                            break;
                            }

                        }
                 
                 
                        for (int o = 3; o < 5; o++)
                        {
                            if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                            {

                            }
                            else
                            {

                                MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                            matricula = "";
                            matricula = ano1 + " " + matricula;
                            break;
                            }

                        }
                    
                        for (int o = 7; o < 8; o++)
                        {
                            if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                            {
                                MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                            matricula = "";
                            matricula = ano1 + " " + matricula;
                            break;
                            }
                            else
                            {


                            }

                        }
                   

                }

                    if (Convert.ToInt32(ano1) >= 2006 && Convert.ToInt32(ano1) <= 2020)
                    {
                            for (int l = 0; l < 2; l++)
                            {
                                if (matricula[l] == '0' || matricula[l] == '1' || matricula[l] == '2' || matricula[l] == '3' || matricula[l] == '4' || matricula[l] == '5' || matricula[l] == '6' || matricula[l] == '7' || matricula[l] == '8' || matricula[l] == '9')
                                {


                                }
                                else
                                {
                                    MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;
                                }

                            }
                  
                     

                            for (int o = 3; o < 5; o++)
                            {
                                if (matricula[
                                    o] == '0' || matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                                {
                                    MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;
                                }
                                else
                                {


                                }

                            }
                     
                            for (int o = 6; o < 8; o++)
                            {
                                if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;

                                }

                            }
                     

                    }

                    if (Convert.ToInt32(ano1) >= 2021)
                    {
                       
                            for (int l = 0; l < 2; l++)
                            {
                                if (matricula[l] == '0' || matricula[l] == '1' || matricula[l] == '2' || matricula[l] == '3' || matricula[l] == '4' || matricula[l] == '5' || matricula[l] == '6' || matricula[l] == '7' || matricula[l] == '8' || matricula[l] == '9')
                                {
                                    MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;

                                }
                                else
                                {

                                }

                            }
                        
                       

                            for (int o = 3; o < 5; o++)
                            {
                                if (matricula[
                                    o] == '0' || matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                                {

                                }
                                else
                                {
                                    MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;

                                }

                            }
                        
                        
                            for (int o = 7; o < 8; o++)
                            {
                                if (matricula[o] == '0' || matricula[o] == '0' || matricula[o] == '1' || matricula[o] == '2' || matricula[o] == '3' || matricula[o] == '4' || matricula[o] == '5' || matricula[o] == '6' || matricula[o] == '7' || matricula[o] == '8' || matricula[o] == '9')
                                {
                                    MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                matricula = "";
                                matricula = ano1 + " " + matricula;
                                break;
                                }
                                else
                                {


                                }

                            }
                        

                    }



                }
            }

        }
        
    }
}
