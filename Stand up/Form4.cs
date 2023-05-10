﻿using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        int i = 0;
        int h = 0;
        int w = 0;
        int ano;
        int n_func;
        int n_cliente;
        
        void clear_caoxas()
        {
            guna2PictureBox2.Image = null;
            guna2TextBox9.Clear();
            guna2TextBox4.Clear();
            guna2TextBox2.Clear();
            guna2TextBox5.Clear();
            guna2TextBox6.Clear();
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2TextBox10.Clear();
            guna2TextBox11.Clear();
            guna2ComboBox8.SelectedIndex = -1;
            guna2ImageButton1.Image = Properties.Resources.flash_black;

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
            guna2GroupBox2.Text = "Inserir Cliente";
            guna2Button4.Visible = false;
            guna2DataGridView1.DataSource = BLL.Clientes.Load();
            clear_caoxas();
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

                guna2HtmlLabel1.Location = new Point(308, 311);
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
          
            guna2HtmlLabel1.Location = new Point(308, 311);
            guna2TextBox1.UseSystemPasswordChar = true;
            guna2TextBox11.UseSystemPasswordChar = true;
            
            DataTable dt = BLL.Func.LoadPerfil(Form5.n_func);
            string admin = BLL.Func.Buscar_admin(Form5.n_func);
            if(admin != "True")
            {
                guna2GroupBox2.Visible = true;
                guna2GroupBox3.Visible = true;
                guna2DataGridView1.DataSource = BLL.Clientes.Load();
             
            }
            else
            {
               guna2GroupBox2.Visible = true;
                guna2GroupBox3.Visible = true;            
            
                    guna2DataGridView1.DataSource = BLL.Func.Load(false);
             
               
            }
            if (Form1.flagInsertFunc == true)
            {
                guna2GroupBox2.Text = "Inserir Funcionário";
            }
          if(Form1.flagEditFunc == true)
            {
                guna2GroupBox2.Text = "Editar Funcionário";
            }

            if (Form1.flagInsertCliente == true)
            {
                guna2GroupBox2.Text = "Inserir Cliente";
            }
            if (Form1.flagEditCliente == true)
            {
                guna2GroupBox2.Text = "Editar Cliente";
            }
            foreach (DataRow row in dt.Rows)
            {
                guna2TextBox3.Text = (string)row["nome"];
                guna2PictureBox1.Image = byteArrayToImage((Byte[])row["Imagem"]);              

            }

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

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }
        string Nome;
        string ativo;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                if(Form1.flagFunc == true)
                {            
                ativo = guna2DataGridView1.Rows[e.RowIndex].Cells["ativo"].Value.ToString();
                guna2TextBox10.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["n_func"].Value.ToString();
                    n_cliente = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["n_func"].Value);
                guna2PictureBox2.Image = byteArrayToImage((Byte[])guna2DataGridView1.Rows[e.RowIndex].Cells["imagem"].Value);
               Nome= guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                guna2TextBox9.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                guna2TextBox4.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["data_nascimento"].Value.ToString();
                guna2TextBox2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                guna2TextBox5.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
                guna2TextBox6.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nib"].Value.ToString();
                guna2TextBox7.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["morada"].Value.ToString();
                guna2TextBox8.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nif"].Value.ToString();
                guna2ComboBox8.SelectedItem = guna2DataGridView1.Rows[e.RowIndex].Cells["genero"].Value.ToString();
                }
                else
                {

                    ativo = guna2DataGridView1.Rows[e.RowIndex].Cells["ativo"].Value.ToString();
                    guna2TextBox10.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["n_cliente"].Value.ToString();
                    n_func = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["n_cliente"].Value);
                    guna2PictureBox2.Image = byteArrayToImage((Byte[])guna2DataGridView1.Rows[e.RowIndex].Cells["imagem"].Value);
                    Nome = guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                    guna2TextBox9.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                    guna2TextBox4.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["data_nascimento"].Value.ToString();
                    guna2TextBox2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                    guna2TextBox5.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
                    guna2TextBox6.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nib"].Value.ToString();
                    guna2TextBox7.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["morada"].Value.ToString();
                    guna2TextBox8.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nif"].Value.ToString();
                    guna2ComboBox8.SelectedItem = guna2DataGridView1.Rows[e.RowIndex].Cells["genero"].Value.ToString();


                }
                if (ativo == "True")
                {
                    guna2ImageButton1.Image = Properties.Resources.flash1;
                    t = 0;
                    Ativo = true;

                }
                else
                {
                    guna2ImageButton1.Image = Properties.Resources.flash_black;
                    t = 1;
                    Ativo = false;
                }
            }
        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox8.Text != "")
            {



                for (int j = 0; j < guna2TextBox8.Text.Length; j++)
                {

                    if (guna2TextBox8.Text[j] == '0' || guna2TextBox8.Text[j] == '1' || guna2TextBox8.Text[j] == '2' || guna2TextBox8.Text[j] == '3' || guna2TextBox8.Text[j] == '4' || guna2TextBox8.Text[j] == '5' || guna2TextBox8.Text[j] == '6' || guna2TextBox8.Text[j] == '7' || guna2TextBox8.Text[j] == '8' || guna2TextBox8.Text[j] == '9')
                    {

                    }
                    else
                    {

                        guna2TextBox8.Clear();
                        MessageBox.Show("Insira um nif válido ");
                    }

                }


            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "")
            {



                for (int j = 0; j < guna2TextBox6.Text.Length; j++)
                {

                    if (guna2TextBox6.Text[j] == '0' || guna2TextBox6.Text[j] == '1' || guna2TextBox6.Text[j] == '2' || guna2TextBox6.Text[j] == '3' || guna2TextBox6.Text[j] == '4' || guna2TextBox6.Text[j] == '5' || guna2TextBox6.Text[j] == '6' || guna2TextBox6.Text[j] == '7' || guna2TextBox6.Text[j] == '8' || guna2TextBox6.Text[j] == '9')
                    {

                    }
                    else
                    {

                        guna2TextBox6.Clear();
                        MessageBox.Show("Insira um nib válido ");
                    }

                }


            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text != "")
            {



                for (int j = 0; j < guna2TextBox5.Text.Length; j++)
                {

                    if (guna2TextBox5.Text[j] == '0' || guna2TextBox5.Text[j] == '1' || guna2TextBox5.Text[j] == '2' || guna2TextBox5.Text[j] == '3' || guna2TextBox5.Text[j] == '4' || guna2TextBox5.Text[j] == '5' || guna2TextBox5.Text[j] == '6' || guna2TextBox5.Text[j] == '7' || guna2TextBox5.Text[j] == '8' || guna2TextBox5.Text[j] == '9'|| guna2TextBox5.Text[3] == ' ' || guna2TextBox5.Text[6] == ' ')
                    {

                    }
                    else
                    {

                        guna2TextBox5.Clear();
                        MessageBox.Show("Insira um Nº de telefone válido ");
                    }

                }


        
            if (guna2TextBox5.Text.Length < 3)
            {
                h = 0;
            }
            if (guna2TextBox5.Text.Length == 3 || guna2TextBox5.Text.Length == 7)
            {
                if (h != 1)
                {
                    guna2TextBox5.Text += " ";
                    guna2TextBox5.Select(guna2TextBox5.Text.Length, 0);
                }
            }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text.Length == 6)
            {

                string mes = guna2TextBox4.Text[3].ToString() + guna2TextBox4.Text[4].ToString();
                if (mes == "01" || mes == "02" || mes == "03" || mes == "04" || mes == "05" || mes == "06" || mes == "07" || mes == "08" || mes == "09" || mes == "10" || mes == "11" || mes == "12")
                {
                    string dia = guna2TextBox4.Text[0].ToString() + guna2TextBox4.Text[1].ToString();
                    if (mes == "01" || mes == "03" || mes == "05" || mes == "07" || mes == "08" || mes == "10" || mes == "12")
                    {
                        if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                        {

                        }
                        else
                        {
                            MessageBox.Show("insira um dia válido");
                            guna2TextBox4.Clear();
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
                            guna2TextBox4.Clear();
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
                            guna2TextBox4.Clear();
                            i = 0;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("insira um mês válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox4.Text.Length == 3)
            {

                string dia = guna2TextBox4.Text[0].ToString() + guna2TextBox4.Text[1].ToString();

                if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                {

                }
                else
                {
                    MessageBox.Show("insira um dia válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox4.Text.Length == 10)
            {
                i = 1;

                DateTime data = DateTime.ParseExact(guna2TextBox4.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                ano = data.Year;
                if (data.Year >= DateTime.Now.Year || data.Year <= 1931)
                {
                    MessageBox.Show("insira um ano válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }



            }

            if (guna2TextBox4.Text.Length < 2)
            {
                i = 0;
            }
            if (guna2TextBox4.Text.Length == 2 || guna2TextBox4.Text.Length == 5)
            {
                if (i != 1)
                {
                    guna2TextBox4.Text += "/";
                    guna2TextBox4.Select(guna2TextBox4.Text.Length, 0);
                }
            }
        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox2.ImageLocation = openFileDialog1.FileName;
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
        bool Ativo;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(Form1.flagFunc == true)
            {         
            if(Form1.flagInsertFunc == true)
            {
                    if (guna2PictureBox2.Image == null)
                    {
                        MessageBox.Show("Insira uma foto");
                    }
                    else
                    {

                        if (guna2TextBox9.Text != "")
                        {
                            if (guna2TextBox4.Text.Length == 10)
                            {

                                if (guna2TextBox2.Text != "")
                                {

                                    if (guna2TextBox5.Text.Length == 11)
                                    {

                                        if (guna2TextBox6.Text.Length == 21)
                                        {

                                            if (guna2TextBox7.Text != "")
                                            {

                                                if (guna2TextBox8.Text.Length == 9)
                                                {

                                                    if (guna2ComboBox8.SelectedIndex != -1)
                                                    {


                                                        DialogResult dr = MessageBox.Show("Tem a certeza que quer adicionar um novo funcionário ?", "", MessageBoxButtons.YesNo);
                                                        if (dr == DialogResult.Yes)
                                                        {
                                                            int x = BLL.Func.insertFunc(guna2TextBox9.Text, Hash("123"), true, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox5.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.SelectedItem.ToString(), false);
                                                            guna2DataGridView1.DataSource = BLL.Func.Load(false);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Insira um género válido");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Insira um nif válido");

                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Insira uma morada válida");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Insira um nib válido");
                                        }
                                    }
                                    else
                                    {

                                        MessageBox.Show("Insira um email válido");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Insira um nº de telefone válido");

                                }
                            }
                            else
                            {
                                MessageBox.Show("Insira uma data válida");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insira um nome");

                        }

                    }
                }
            else
            {

                    if (guna2PictureBox2.Image == null)
                    {
                        MessageBox.Show("Insira uma foto");
                    }
                    else
                    {

                        if (guna2TextBox9.Text != "")
                        {
                            if (guna2TextBox4.Text.Length == 10)
                            {

                                if (guna2TextBox2.Text != "")
                                {

                                    if (guna2TextBox5.Text.Length == 11)
                                    {

                                        if (guna2TextBox6.Text.Length == 21)
                                        {

                                            if (guna2TextBox7.Text != "")
                                            {

                                                if (guna2TextBox8.Text.Length == 9)
                                                {

                                                    if (guna2ComboBox8.SelectedIndex != -1)
                                                    {


                                                        DialogResult dr = MessageBox.Show("Tem a certeza que quer alterar as informções do funcionário " + Nome + "?", "", MessageBoxButtons.YesNo);
                                                        if (dr == DialogResult.Yes)
                                                        {
                                                            int x = BLL.Func.updateFunc(n_func, guna2TextBox9.Text, Ativo, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox5.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.Text);
                                                            guna2DataGridView1.DataSource = BLL.Func.Load(false);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Insira um género válido");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Insira um nif válido");

                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Insira uma morada válida");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Insira um nib válido");
                                        }
                                    }
                                    else
                                    {

                                        MessageBox.Show("Insira um email válido");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Insira um nº de telefone válido");

                                }
                            }
                            else
                            {
                                MessageBox.Show("Insira uma data válida");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insira um nome");

                        }

                    }
                
            }
            }
            else
            {

                if (Form1.flagInsertCliente == true)
                {

                    if (guna2PictureBox2.Image == null)
                    {
                        MessageBox.Show("Insira uma foto");
                    }
                    else
                    {

                        if (guna2TextBox9.Text != "")
                        {
                            if (guna2TextBox4.Text.Length == 10)
                            {

                                if (guna2TextBox2.Text != "")
                                {

                                    if (guna2TextBox5.Text.Length == 11)
                                    {

                                        if (guna2TextBox6.Text.Length == 21)
                                        {

                                            if (guna2TextBox7.Text != "")
                                            {

                                                if (guna2TextBox8.Text.Length == 9)
                                                {

                                                    if (guna2ComboBox8.SelectedIndex != -1)
                                                    {


                                                        DialogResult dr = MessageBox.Show("Tem a certeza que quer adicionar um novo Cliente ?", "", MessageBoxButtons.YesNo);
                                                        if (dr == DialogResult.Yes)
                                                        {
                                                            int x = BLL.Clientes.insertCliente(guna2TextBox5.Text, guna2TextBox9.Text, true, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.Text, Hash("1234"));
                                                            guna2DataGridView1.DataSource = BLL.Clientes.Load();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Insira um género válido");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Insira um nif válido");

                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Insira uma morada válida");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Insira um nib válido");
                                        }
                                    }
                                    else
                                    {

                                        MessageBox.Show("Insira um email válido");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Insira um nº de telefone válido");

                                }
                            }
                            else
                            {
                                MessageBox.Show("Insira uma data válida");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insira um nome");

                        }

                    }
                   
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Tem a certeza que quer alterar as informações do Cliente " + Nome + "?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        int x = BLL.Clientes.updateCliente(n_cliente, guna2TextBox9.Text, Ativo, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox5.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.Text);
                        guna2DataGridView1.DataSource = BLL.Clientes.Load();
                    }

                }

            }

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar a senha?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int x = BLL.Func.senhaFunc(Hash(guna2TextBox1.Text), Form5.n_func);
                guna2TextBox1.Clear();

            }

           

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

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
            guna2GroupBox2.Text = "Inserir Funcionário";
            guna2Button4.Visible = false;
            guna2DataGridView1.DataSource = BLL.Func.Load(false);
            clear_caoxas();
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
            guna2GroupBox2.Text = "Editar Funcionário";
            guna2Button4.Visible = true;
            guna2DataGridView1.DataSource = BLL.Func.Load(false);
            clear_caoxas();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (Form1.flagFunc == true)
            {
                DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar a senha do funcionário " + Nome + "?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    BLL.Func.senhaFunc(Hash(guna2TextBox11.Text), n_func);
                    guna2TextBox11.Clear();
                    guna2TextBox10.Clear();

                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar a senha do cliente " + Nome + "?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    BLL.Func.senhaFunc(Hash(guna2TextBox11.Text), n_cliente);
                    guna2TextBox11.Clear();
                    guna2TextBox10.Clear();

                }


            }
           
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (w == 0)
            {
                guna2TextBox11.UseSystemPasswordChar = false;
                guna2Button5.Image = Properties.Resources.show1;
                w += 1;
            }
            else
            {
                guna2TextBox11.UseSystemPasswordChar = true;
                guna2Button5.Image = Properties.Resources.invisible1;
                w = 0;
            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
        int t = 0;
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (t == 0)
            {               
                guna2ImageButton1.Image = Properties.Resources.flash_black;
                t += 1;
                Ativo = false;
            }
            else
            {
              
                guna2ImageButton1.Image = Properties.Resources.flash1;
                t = 0;
                Ativo = true;
            }
        }

        private void listaDeFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagFunc = true;
            Form1.flagCliente = false;
            Form1.flag_lista_func = true;
            Form1.flag_config = false;

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
            guna2GroupBox2.Text = "editar Cliente";
            guna2Button4.Visible = true;
            guna2DataGridView1.DataSource = BLL.Clientes.Load();
            clear_caoxas();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
    }
}
