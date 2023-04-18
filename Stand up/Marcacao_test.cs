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
    public partial class Marcacao_test : Form
    {
        public Marcacao_test()
        {
            InitializeComponent();
        }
        int dia = 1;
        int mes=1;
        int ano = 2023;
        void verificar_mes() {

            switch (mes)
            {

                case 1:
                    guna2Button29.Visible = true;
                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Janeiro";
                    break;
                case 2:


                    if ((ano % 4 == 0 && ano % 100 != 0) || ano % 400 == 0)
                    {
                        // ano bissexto
                        guna2Button30.Visible = false;
                        guna2Button31.Visible = false;
                    }
                    else
                    {
                        // ano  não bissexto
                        guna2Button29.Visible = false;
                        guna2Button30.Visible = false;
                        guna2Button31.Visible = false;
                    }
                    guna2TextBox1.Text = "Fevereiro";
                    break;
                case 3:


                    guna2Button29.Visible = true;
                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Março";
                    break;
                case 4:

                    guna2Button31.Visible = false;
                    guna2Button30.Visible = true;
                    guna2TextBox1.Text = "Abril";
                    break;

                case 5:

                  
                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Maio";
                    break;
                case 6:

                    guna2Button31.Visible = false;
                    guna2Button30.Visible = true;
                    guna2TextBox1.Text = "Junho";
                    break;
                case 7:

                   
                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Julho";
                    break;
                case 8:


                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Agosto";
                    break;
                case 9:


                    guna2Button30.Visible = true;
                    guna2Button31.Visible = false;
                    guna2TextBox1.Text = "Setembro";
                    break;
                case 10:


                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Outubro";
                    break;
                case 11:


                    guna2Button30.Visible = true;
                    guna2Button31.Visible = false;
                    guna2TextBox1.Text = "Novembro";
                    break;
                case 12:

                    guna2Button30.Visible = true;
                    guna2Button31.Visible = true;
                    guna2TextBox1.Text = "Dezembro";
                    break;
            }
        
        
        }
        void verificar_dia() {

            switch (dia)
            {

                case 1:

                    guna2Button1.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
              
                    break;
                case 2:
                    guna2Button2.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                 
                    break;
                case 3:

                    guna2Button3.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 4:

                    guna2Button4.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 5:

                    guna2Button5.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 6:

                    guna2Button6.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 7:

                    guna2Button7.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 8:

                    guna2Button8.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);
                    break;
                case 9:

                    guna2Button9.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 10:

                    guna2Button10.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 11:

                    guna2Button11.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 12:

                    guna2Button12.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 13:

                    guna2Button13.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 14:

                    guna2Button14.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 15:

                    guna2Button15.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 16:

                    guna2Button16.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 17:

                    guna2Button17.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;


                case 18:

                    guna2Button18.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 19:

                    guna2Button19.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 20:

                    guna2Button20.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 21:

                    guna2Button21.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 22:

                    guna2Button22.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 23:

                    guna2Button23.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 24:

                    guna2Button24.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 25:

                    guna2Button25.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;

                case 26:

                    guna2Button26.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 27:

                    guna2Button27.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 28:

                    guna2Button28.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 29:

                    guna2Button29.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 30:

                    guna2Button30.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 31:

                    guna2Button31.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);

                    break;
            }
        
        }
        private void Marcacao_test_Load(object sender, EventArgs e)
        {
            mes = DateTime.Now.Month;
            ano = DateTime.Now.Year;
            dia = DateTime.Now.Day;
            guna2TextBox2.Text = ano.ToString();
            verificar_dia();
            verificar_mes();
        }

        private void guna2Button42_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button38_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button39_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button40_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button43_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            mes += 1;
            if (mes == 13)
            {
                ano += 1;
                guna2TextBox2.Text = Convert.ToString(ano);
                mes = 1;
            }
            verificar_mes();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            mes -= 1;
            if (mes == 0)
            {
                ano -= 1;
                guna2TextBox2.Text = Convert.ToString(ano);
                mes = 12;
            }
            verificar_mes();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dia = 1;
            verificar_dia();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dia = 2;
            verificar_dia();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dia = 3;
            verificar_dia();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dia = 4;
            verificar_dia();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dia = 5;
            verificar_dia();
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            dia = 23;
            verificar_dia();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dia = 6;
            verificar_dia();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            dia = 7;
            verificar_dia();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            dia = 8;
            verificar_dia();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            dia = 9;
            verificar_dia();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            dia = 10;
            verificar_dia();
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            dia = 24;
            verificar_dia();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            dia = 11;
            verificar_dia();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            dia = 12;
            verificar_dia();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            dia = 13;
            verificar_dia();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            dia = 14;
            verificar_dia();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            dia = 15;
            verificar_dia();
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            dia = 25;
            verificar_dia();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            dia = 16;
            verificar_dia();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            dia = 17;
            verificar_dia();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            dia = 18;
            verificar_dia();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            dia = 19;
            verificar_dia();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            dia = 20;
            verificar_dia();
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            dia = 26;
            verificar_dia();
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            dia = 21;
            verificar_dia();
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            dia = 22;
            verificar_dia();
        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            dia = 27;
            verificar_dia();
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            dia = 28;
            verificar_dia();
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            dia = 29;
            verificar_dia();
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            dia = 30;
            verificar_dia();
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            dia = 31;
            verificar_dia();
        }
    }
}
