using BusinessLogicLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stand_up
{
    public partial class Marcacao_test : Form
    {
        public Marcacao_test()
        {
            InitializeComponent();
        }
        int i = 0;
        int dia = 1;
        int mes = 1;
        int ano = 2023;
        ImageList images = new ImageList();
        ImageList images1 = new ImageList();
        ImageList images2 = new ImageList();
        DateTime Insertdata;
        string data123 = "";
        string datastring2 = "";
        string dataString = "" ;
        string hora = "";
        string id_func;
        string id_cliente;
        string nomeFunc;
        string nomeCliente;
        string matricula;
        string marca;
        string modelo;
        bool flag_dataValida=true;
     Image imageM;
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

                    guna2Button23.FillColor = Color.FromArgb(128, 64, 64);
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
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
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

                    guna2Button6.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
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

                    guna2Button7.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
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

                    guna2Button8.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
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

                    guna2Button9.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button10.FillColor = Color.FromArgb(197, 109, 109);
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

                    guna2Button10.FillColor = Color.FromArgb(128, 64, 64);
                    guna2Button2.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button3.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button4.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button5.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button6.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button7.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button8.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button9.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button11.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button12.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 13:

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
                    guna2Button13.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button14.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button15.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button16.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button17.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button18.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 19:

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
                    guna2Button19.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button20.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button21.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button22.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button23.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button1.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button24.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button27.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button28.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button29.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button30.FillColor = Color.FromArgb(197, 109, 109);
                    guna2Button31.FillColor = Color.FromArgb(197, 109, 109);

                    break;
                case 25:

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
                    guna2Button25.FillColor = Color.FromArgb(197, 109, 109);
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
                    guna2Button26.FillColor = Color.FromArgb(197, 109, 109);
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
        void carregar_car_PARA_LISTVIEW()
        {





            DataTable dr = BLL.veiculos.queryLoad_veiculo(false);

            listView3.Clear();
            images.Images.Clear();
            i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView3.LargeImageList = images;

                listView3.LargeImageList.ImageSize = new System.Drawing.Size(123, 123);



                byte[] imagebyte = (byte[])(row["Imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView3.Items.Add(item);











            }


        }

        void carregar_func_PARA_LISTVIEW()
        {





            DataTable dt = BLL.Func.queryLoad_Func();

            listView1.Clear();
            images1.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images1.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images1;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(123, 123);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images1.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_func"].ToString() + " " +row["nome"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }



        }

        void carregar_cliente_PARA_LISTVIEW()
        {





            DataTable dt = BLL.Clientes.queryLoad_cliente();

            listView2.Clear();
            images2.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images2.ColorDepth = ColorDepth.Depth32Bit;

                listView2.LargeImageList = images2;

                listView2.LargeImageList.ImageSize = new System.Drawing.Size(123, 123);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images2.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_cliente"].ToString()+" " + row["nome"].ToString();

                i += 1;

                this.listView2.Items.Add(item);











            }



        }

        private void Marcacao_test_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            mes = DateTime.Now.Month;
            ano = DateTime.Now.Year;
            dia = DateTime.Now.Day;
            guna2TextBox2.Text = ano.ToString();
            verificar_dia();
            verificar_mes();
            carregar_car_PARA_LISTVIEW();
            Ativar_marcacao();
        }

        void Ativar_marcacao()
        {
            data123 = "";
            dataString = "";
            datastring2 = "";
          
            dataString = (dia + "/" + mes + "/" + ano);
            DateTime data;
           if(dia <= 9 && mes <= 9)
            {
                dataString = ("0"+dia + "/" + "0" + mes + "/" + ano);
            }
           else if (dia <= 9)
            {
                dataString = ("0" + dia + "/" + mes + "/" + ano);
            }
           else if (mes<=9)
            {
                dataString = ( dia + "/" + "0" + mes + "/" + ano);
            }

            if (DateTime.TryParseExact(dataString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                DateTime data_sem_hora = DateTime.ParseExact(dataString + " 12:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                datastring2 = dataString + " 12:00:00";

                guna2DataGridView1.DataSource = BLL.testDrive.queryLoad_Test(data_sem_hora);
                DateTime hoje = DateTime.Now;

                if (data >= hoje.Date)
                {
                    guna2ComboBox1.Enabled = true;
                    guna2ComboBox1.Enabled = true;
                    data123 = dataString +" " + hora;
                    flag_dataValida = true;
                }
               
                else
                {
                    listView2.Clear();
                    listView1.Clear();
                    guna2ComboBox1.Enabled = false;
                    guna2Button32.Enabled = false;
                    guna2Button33.Enabled = false;
                    flag_dataValida = false;
                    
                }

              


            }
            else
            {
                MessageBox.Show("Data inválida." + dataString);
            }

            string hora1 = DateTime.Now.ToString("HH:mm:ss");
            string data_atual = DateTime.Now.ToShortDateString();
            DateTime data_sem_hora2 = DateTime.ParseExact(datastring2, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            string data_sem_hora1 = data_sem_hora2.ToShortDateString();
            if(data_atual == data_sem_hora1)
            {
                if (hora1[0] == '0' && hora1[1] == '8' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("08:30 - 09:00");
                    guna2ComboBox1.Items.Add("09:00 - 09:30");
                    guna2ComboBox1.Items.Add("09:30 - 10:00");
                    guna2ComboBox1.Items.Add("10:00 - 10:30");
                    guna2ComboBox1.Items.Add("10:30 - 11:00");
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '0' && hora1[1] == '8' && hora1[3] == '3' || hora1[0] == '0' && hora1[1] == '8' && hora1[3] == '4' || hora1[0] == '0' && hora1[1] == '8' && hora1[3] == '5' || hora1[0] == '0' && hora1[1] == '8' && hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("09:00 - 09:30");
                    guna2ComboBox1.Items.Add("09:30 - 10:00");
                    guna2ComboBox1.Items.Add("10:00 - 10:30");
                    guna2ComboBox1.Items.Add("10:30 - 11:00");
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                    if (hora1[0] == '0' && hora1[1] == '9' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("09:30 - 10:00");
                    guna2ComboBox1.Items.Add("10:00 - 10:30");
                    guna2ComboBox1.Items.Add("10:30 - 11:00");
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '0' && hora1[1] == '9' && hora1[3] == '3' || hora1[0] == '0' && hora1[1] == '9' && hora1[3] == '4' || hora1[0] == '0' && hora1[1] == '9' && hora1[3] == '5' || hora1[0] == '0' && hora1[1] == '9' && hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("10:00 - 10:30");
                    guna2ComboBox1.Items.Add("10:30 - 11:00");
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }



                if (hora1[0] == '1' && hora1[1] == '0' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("10:30 - 11:00");
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '0' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '0' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '0' && hora1[3] == '5' || hora1[0] == '1' && hora1[1] == '0' && hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("11:00 - 11:30");
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }

                if (hora1[0] == '1' && hora1[1] == '1' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("11:30 - 12:00");
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '1' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '1' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '1' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("12:00 - 12:30");
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }


                if (hora1[0] == '1' && hora1[1] == '2' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '2' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '2' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '2' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("12:30 - 13:00");
                    guna2ComboBox1.Items.Add("13:00 - 13:30");
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '1' && hora1[1] == '3' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("13:30 - 14:00");
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '3' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '3' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '3' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("14:00 - 14:30");
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '1' && hora1[1] == '4' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("14:30 - 15:00");
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                  
                }
                if (hora1[0] == '1' && hora1[1] == '4' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '4' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '4' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("15:00 - 15:30");
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '1' && hora1[1] == '5' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("15:30 - 16:00");
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '5' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '5' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '5' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("16:00 - 16:30");
                    guna2ComboBox1.Items.Add("16:30 - 17:00");

                }
                if (hora1[0] == '1' && hora1[1] == '6' && hora1[3] != '3' && hora1[3] != '4' && hora1[3] != '5' && hora1[3] != '6')
                {
                    guna2ComboBox1.Items.Clear();
                    guna2ComboBox1.Items.Add("16:30 - 17:00");
                }
                if (hora1[0] == '1' && hora1[1] == '6' && hora1[3] == '3' || hora1[0] == '1' && hora1[1] == '6' && hora1[3] == '4' || hora1[0] == '1' && hora1[1] == '6' && hora1[3] == '5' || hora1[3] == '6')
                {

                    guna2ComboBox1.Items.Clear();

                }
            }
            else
            {


                guna2ComboBox1.Items.Clear();
                guna2ComboBox1.Items.Add("08:00 - 08:30");
                guna2ComboBox1.Items.Add("08:30 - 09:00");
                guna2ComboBox1.Items.Add("09:00 - 09:30");
                guna2ComboBox1.Items.Add("09:30 - 10:00");
                guna2ComboBox1.Items.Add("10:00 - 10:30");
                guna2ComboBox1.Items.Add("10:30 - 11:00");
                guna2ComboBox1.Items.Add("11:00 - 11:30");
                guna2ComboBox1.Items.Add("11:30 - 12:00");
                guna2ComboBox1.Items.Add("12:00 - 12:30");
                guna2ComboBox1.Items.Add("12:30 - 13:00");
                guna2ComboBox1.Items.Add("13:00 - 13:30");
                guna2ComboBox1.Items.Add("13:30 - 14:00");
                guna2ComboBox1.Items.Add("14:00 - 14:30");
                guna2ComboBox1.Items.Add("14:30 - 15:00");
                guna2ComboBox1.Items.Add("15:00 - 15:30");
                guna2ComboBox1.Items.Add("15:30 - 16:00");
                guna2ComboBox1.Items.Add("16:00 - 16:30");
                guna2ComboBox1.Items.Add("16:30 - 17:00");
            }

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
            Ativar_marcacao();            Ativar_marcacao();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dia = 2;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dia = 3;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dia = 4;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            dia = 5;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            dia = 6;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dia = 7;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            dia = 8;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            dia = 9;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            dia = 10;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            dia = 11;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            dia = 12;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            dia = 13;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            dia = 14;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            dia = 15;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            dia = 16;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            dia = 17;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            dia = 18;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            dia = 19;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            dia = 20;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            dia = 21;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            dia = 22;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            dia = 23;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            dia = 24;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            dia = 25;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            dia = 26;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            dia = 27;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            dia = 28;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            dia = 29;
verificar_dia();
            Ativar_marcacao();        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            dia = 30;
verificar_dia();
            Ativar_marcacao();
            
        
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            dia = 31;
verificar_dia();
            Ativar_marcacao();        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

            Ativar_marcacao();

            if (listView3.SelectedItems.Count > 0 && flag_dataValida==true)
            {
               matricula = listView3.SelectedItems[0].Text; ;
              
                

                carregar_func_PARA_LISTVIEW();
            }
        
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Ativar_marcacao();

            if (listView1.SelectedItems.Count > 0 && flag_dataValida == true)
            {
                string phrase = listView1.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');

                id_func = words[1];
                nomeFunc = words[2];
                

                carregar_cliente_PARA_LISTVIEW();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0 && flag_dataValida == true)
            {
                string phrase = listView2.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');

                id_cliente = words[1];
                nomeCliente = words[2];
                guna2Button32.Enabled = true;
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)

        {

            using (MemoryStream mStream = new MemoryStream(byteArrayIn))

            {

                return Image.FromStream(mStream);

            }

        }


        public byte[] imgToByteArray(Image img)

        {

            using (MemoryStream mStream = new MemoryStream())

            {

                img.Save(mStream, img.RawFormat);

                return mStream.ToArray();

            }

        }
        private void guna2Button32_Click(object sender, EventArgs e)
        {
          if( listView3.SelectedItems.Count < 1)
            {
                MessageBox.Show("Selecione um veiculo");
            }
            else
            {
                if (listView1.SelectedItems.Count < 1)
                {
                    MessageBox.Show("Selecione um funcionário");
                }
                else
                {
                    if(listView2.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("Selecione um cliente");
                    }
                    else
                    {
                        if (guna2ComboBox1.SelectedIndex == -1){


                            MessageBox.Show("Selecione uma hora para efetuar o Test-drive");
                        }
                        else
                        {
                            DataTable info = BLL.veiculos.Load_dados(matricula);

                            foreach (DataRow row in info.Rows)
                            {
                                marca = (string)row["Marca"];
                                modelo = (string)row["Modelo"];
                                imageM = byteArrayToImage((Byte[])row["Imagem"]);

                            }

                            DateTime data_sem_hora = DateTime.ParseExact(datastring2, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            Insertdata = DateTime.ParseExact(data123, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            DataTable DH = BLL.testDrive.procurarFuncOcupado(Insertdata,Convert.ToInt32(id_func));
                            if (DH.Rows.Count <= 0)
                            {
                               DataTable DH1 = BLL.testDrive.procurarClienteOcupado(Insertdata, Convert.ToInt32(id_cliente));
                                if (DH1.Rows.Count <= 0)
                                {
                                   DataTable DH2 = BLL.testDrive.procurarCarroOcupado(Insertdata, matricula);
                                    if (DH2.Rows.Count <= 0)
                                    {
                                        int x = BLL.testDrive.insertTest(data_sem_hora, Insertdata, Convert.ToInt32(id_func), nomeFunc, Convert.ToInt32(id_cliente), nomeCliente, marca, modelo, matricula, imgToByteArray(imageM));
                                        guna2DataGridView1.DataSource = BLL.testDrive.queryLoad_Test(data_sem_hora);

                                    }
                                    else
                                    {
                                        MessageBox.Show("Não pode inserir pois o veiculo está a ser utilizado nesse horário");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Não pode inserir pois o Cliente está ocupado nesse horário");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não pode inserir pois o funcionário está ocupado nesse horário");
                            }


                        }
                    }
                }

            }
        }
        string hora231 = "";
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            hora231 = guna2ComboBox1.Text;
            switch (guna2ComboBox1.Text)
            {

                case "08:00 - 08:30":
                    hora = "08:30:00";

                    break;
                case "08:30 - 09:00":
                    hora = "09:00:00";

                    break;
                case "09:00 - 09:30":
                    hora = "09:30:00";

                    break;
                case "09:30 - 10:00":
                    hora = "10:00:00";

                    break;
                case "10:00 - 10:30":
                    hora = "10:30:00";

                    break;
                case "10:30 - 11:00":
                    hora = "11:00:00";

                    break;
                case "11:00 - 11:30":
                    hora = "11:30:00";

                    break;
                case "11:30 - 12:00":
                    hora = "12:00:00";

                    break;
                case "12:00 - 12:30":
                    hora = "12:30:00";

                    break;
                case "12:30 - 13:00":
                    hora = "13:00:00";

                    break;

               case "13:00 - 13:30":
                    hora = "13:30:00";

                    break;
                case "13:30 - 14:00":
                    hora = "14:00:00";

                    break;
                case "14:00 - 14:30":
                    hora = "14:30:00";

                    break;
                case "14:30 - 15:00":
                    hora = "15:00:00";

                    break;
                case "15:00 - 15:30":
                    hora = "15:30:00";

                    break;
                case "15:30 - 16:00":
                    hora = "16:00:00";

                    break;
                case "16:00 - 16:30":
                    hora = "16:30:00";

                    break;
                case "16:30 - 17:00":
                    hora = "17:00:00";
                    break;
           
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView3.SelectedItems.Count > 0 && flag_dataValida == false)
            {
                MessageBox.Show("Para fazer uma marcação necessita de selecionar a data de hoje ou uma posterior");
                listView3.SelectedItems.Clear();
            }
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Pertende remover a marcação"+ data123+"", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                BLL.testDrive.EleminarTest(id_test);
                Ativar_marcacao();
            }
        }
        int id_test = 0;
        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                guna2Button33.Enabled = true;
                id_test = (int)guna2DataGridView1.Rows[e.RowIndex].Cells["id"].Value;
            }
        }

        private void guna2ComboBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
