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
            DoubleBuffered = true;
            string admin = BLL.Func.Buscar_admin(Form5.n_func);
            if (admin != "True")
            {
            
            }
            if(admin == "True" && Form1.flagCliente==true)
            {
                guna2DataGridView1.DataSource = BLL.Clientes.Load();
            }
            if (admin == "True" && Form1.flagFunc == true)
            {
                guna2DataGridView1.DataSource = BLL.Func.Load();
            }
            timer1.Start();
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
                guna2TextBox1.Clear();
                guna2Button3.FillColor = Color.DodgerBlue;
                t += 1;
                guna2Button6.FillColor = Color.Silver;
                guna2Button5.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                a = 0;
                b = 0;
                d = 0;
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

                guna2Button6.FillColor = Color.Silver;
                guna2Button5.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

                t = 0;
                b = 0;
                d = 0;
                j = 0;
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
                guna2TextBox1.Clear();
                guna2Button32.FillColor = Color.DodgerBlue;
                b += 1;

                 guna2Button6.FillColor = Color.Silver;
                guna2Button5.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

                t = 0;
                a = 0;
                d = 0;
                j = 0;
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
                guna2TextBox1.Clear();
                guna2Button5.FillColor = Color.DodgerBlue;
                d += 1;
 
                guna2Button6.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

                t = 0;
                a = 0;
                b = 0;
                j = 0;
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
                guna2TextBox1.Clear();
                guna2Button6.FillColor = Color.DodgerBlue;
                j += 1;
                guna2Button5.FillColor = Color.Silver;
                guna2Button32.FillColor = Color.Silver;
                guna2Button2.FillColor = Color.Silver;
                guna2Button3.FillColor = Color.Silver;

                t = 0;
                a = 0;
                b = 0;
                d = 0;
            }
            else
            {

                guna2Button6.FillColor = Color.Silver;
                j = 0;

            }
        }
        int ano;
        int i = 0;
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
                guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_idade(guna2TextBox1.Text);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Form1.flagCliente != true)
            {


     
            if (b == 1)
            {

                guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nome(guna2TextBox1.Text);
            }
            if (t == 1)
            {
                guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_id(guna2TextBox1.Text);
            }
         
            if (d == 1)
            {

                guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nif(guna2TextBox1.Text);
            }
            if (j == 1)
            {

                guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_genero(guna2TextBox1.Text);
            }
            if (c == 1)
            {
                if (b == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nome_ativo(guna2TextBox1.Text, true);
                }
                if (t == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_id_ativo(guna2TextBox1.Text, true);
                }
                if (a == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_idade_ativo(guna2TextBox1.Text, true);
                }
                if (d == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nif_ativo(guna2TextBox1.Text, true);
                }
                if (j == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_genero_ativo(guna2TextBox1.Text, true);
                }
            }
            if (c == 2)
            {
                if (b == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nome_ativo(guna2TextBox1.Text, false);
                }
                if (t == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_id_ativo(guna2TextBox1.Text, false);
                }
                if (a == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_idade_ativo(guna2TextBox1.Text, false);
                }
                if (d == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_nif_ativo(guna2TextBox1.Text, false);
                }
                if (j == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Func.queryFunc_Like_genero_ativo(guna2TextBox1.Text, false);
                }
            }
            }
            else
            {





                if (b == 1)
                {

                    guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nome(guna2TextBox1.Text);
                }
                if (t == 1)
                {
                    guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_id(guna2TextBox1.Text);
                }
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
                    guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_idade(guna2TextBox1.Text);
                }
                if (d == 1)
                {

                    guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nif(guna2TextBox1.Text);
                }
                if (j == 1)
                {

                    guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_genero(guna2TextBox1.Text);
                }
                if (c == 1)
                {
                    if (b == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nome_ativo(guna2TextBox1.Text, true);
                    }
                    if (t == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_id_ativo(guna2TextBox1.Text, true);
                    }
                    if (a == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_idade_ativo(guna2TextBox1.Text, true);
                    }
                    if (d == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nif_ativo(guna2TextBox1.Text, true);
                    }
                    if (j == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_genero_ativo(guna2TextBox1.Text, true);
                    }
                }
                if (c == 2)
                {
                    if (b == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nome_ativo(guna2TextBox1.Text, false);
                    }
                    if (t == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_id_ativo(guna2TextBox1.Text, false);
                    }
                    if (a == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_idade_ativo(guna2TextBox1.Text, false);
                    }
                    if (d == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_nif_ativo(guna2TextBox1.Text, false);
                    }
                    if (j == 1)
                    {
                        guna2DataGridView1.DataSource = BLL.Clientes.queryCliente_Like_genero_ativo(guna2TextBox1.Text, false);
                    }
                }

            }
        }

        private void listaDeFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagFunc = true;
            Form1.flagCliente = false;
            Form1.flag_lista_func = true;
            Form1.flag_config = false;
        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1.flag_config = true;
            Form1.flagFunc = true;
            Form1.flagCliente = false;
            Form1.flagInsertFunc = true;
            Form1.flagEditFunc = false;
            Form1.flagInsertCliente = false;
            Form1.flagEditCliente = false;
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flag_config = true;
            Form1.flagFunc = true;
            Form1.flagCliente = false;
            Form1.flagInsertFunc = false;
            Form1.flagEditFunc = true;
            Form1.flagInsertCliente = false;
            Form1.flagEditCliente = false;
        }

        private void inserirEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flag_config = true;
            Form1.flagFunc = false;
            Form1.flagCliente = true;
            Form1.flagInsertCliente = true;
            Form1.flagEditCliente = false;
            Form1.flagInsertFunc = false;
            Form1.flagEditFunc = false;
        }

        private void editarEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flag_config = true;
            Form1.flagFunc = false;
            Form1.flagCliente = true;
            Form1.flagInsertCliente = false;
            Form1.flagEditCliente = true;
            Form1.flagInsertFunc = false;
            Form1.flagEditFunc = false;
        }

        private void listaDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagFunc = false;
            Form1.flagCliente = true;
            Form1.flag_lista_func = true;
            Form1.flag_config = false;
        }

        private void especificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enviarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagEmail = true;
            Form1.flag_config = false;
            Form1.flagFunc = false;
            Form1.flagCliente = false;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
