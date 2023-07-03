﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BusinessLogicLayer;
using System.IO;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Guna.UI2.WinForms;

namespace Stand_up
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        void carregar_cliente_PARA_LISTVIEW()
        {





            DataTable dt = BLL.Clientes.queryLoad_cliente();

            listView1.Clear();
            images2.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images2.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images2;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images2.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_cliente"].ToString() + " " + row["nome"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }



        }
        void carregar_cliente_PARA_LISTVIEW1()
        {





            DataTable dt = BLL.Clientes.queryLoad_cliente();

            listView2.Clear();
            images2.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images2.ColorDepth = ColorDepth.Depth32Bit;

                listView2.LargeImageList = images2;

                listView2.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images2.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_cliente"].ToString() + " " + row["nome"].ToString();

                i += 1;

                this.listView2.Items.Add(item);











            }



        }
        string caminhoArquivo = "";
        int i = 0;
        int ww = 0;
        ImageList images2 = new ImageList();

        ImageList images1 = new ImageList();
        ImageList images3 = new ImageList();
        string id_cliente;
        string nomeCliente;
        DataTable dt = null;
        void limpar_caixas()
        {
            guna2TextBox7.Clear();
            guna2TextBox5.Clear();
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               caminhoArquivo = openFileDialog1.FileName;
            }
        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            // Configurar o cliente SMTP
            if (guna2TextBox5.Text != "" && guna2TextBox1.Text != "" && guna2TextBox7.Text != "")
            {
                try { 
                string fromemail = "standuprla@gmail.com";
                string frompasssword = "qisznqsrmsszpvif";

                MailMessage message = new MailMessage();
                // Criando a mensagem de e-mail
                message.From = new MailAddress(fromemail);
                message.To.Add(new MailAddress( guna2TextBox5.Text));
                message.Subject = guna2TextBox1.Text;
                string texto = "Bom dia Sr " + nomeCliente + "," + "\r\n" +"\r\n" + guna2TextBox7.Text +"\r\n" +"\r\n" +"\r\n" +"Obrigado, \r\n"+ "Stand Up";
                message.Body = "<html><body>"+ texto + "</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                Credentials = new NetworkCredential(fromemail,frompasssword),
                EnableSsl = true,
                };


                
                if(caminhoArquivo != "")
                {
                    Attachment anexo = new Attachment(caminhoArquivo);
                    message.Attachments.Add(anexo);
                }
                smtpClient.Send(message);
                MessageBox.Show("Email enviado com sucesso!");
                }
                catch
                {

                    MessageBox.Show("Falha ao enviar email");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            carregar_cliente_PARA_LISTVIEW();
            DoubleBuffered = true;
        }

     
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 )
            {
                string phrase = listView1.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');

                id_cliente = words[1];
                nomeCliente = words[2];
                guna2Button32.Enabled = true;
                dt = BLL.Clientes.queryCliente_mostrar_dados(Convert.ToInt32(id_cliente));
                foreach (DataRow row in dt.Rows)
                {
                    guna2TextBox5.Text = (string)row["email"];   
                    nomeCliente = (string)row["nome"];

                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();
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

        private void listaDeFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1.flagFunc = true;
            Form1.flagCliente = false;
            Form1.flag_lista_func = true;
            Form1.flag_config = false;
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

        private void enviadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagEmail = true;
            Form1.flag_config = false;
            Form1.flagFunc = false;
            Form1.flagCliente = false;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void caixaDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox7.Text != "")
            {
                try
                {

             
                DataTable dt1 = BLL.Clientes.queryLoad_cliente();
            foreach (DataRow row in dt1.Rows)
            {   
            

                string fromemail = "standuprla@gmail.com";
                string frompasssword = "qisznqsrmsszpvif";

                MailMessage message = new MailMessage();
                // Criando a mensagem de e-mail
                message.From = new MailAddress(fromemail);
                message.To.Add(new MailAddress((string)row["email"]));
                message.Subject = guna2TextBox1.Text;
                message.Body = "<html><body>" + guna2TextBox7.Text + "</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                       {
                    Port = 587,
                    Credentials = new NetworkCredential(fromemail, frompasssword),
                    EnableSsl = true,
                        };



                     if (caminhoArquivo != "")
                      {
                      Attachment anexo = new Attachment(caminhoArquivo);
                       message.Attachments.Add(anexo);
                      }
    
                          smtpClient.Send(message);
                         }

                          MessageBox.Show("Email enviados com sucesso!");
                        }
                catch
                {

                    MessageBox.Show("Falha ao enviar email");
                }
                   }
            else
            {

                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if(q == 1)
            {
                try
                {

                
          
            foreach (DataRow row in addCl)
            {


                string fromemail = "standuprla@gmail.com";
                string frompasssword = "qisznqsrmsszpvif";

                MailMessage message = new MailMessage();
                // Criando a mensagem de e-mail
                message.From = new MailAddress(fromemail);
                message.To.Add(new MailAddress((string)row["email"]));
                message.Subject = guna2TextBox1.Text;
                string texto = "Bom dia Sr " + (string)row["nome"] + "," + "\r\n" + "\r\n" + guna2TextBox7.Text + "\r\n" + "\r\n" + "\r\n" + "Obrigado, \r\n" + "Stand Up";
                message.Body = "<html><body>" + texto + "</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromemail, frompasssword),
                    EnableSsl = true,
                };



                if (caminhoArquivo != "")
                {
                    Attachment anexo = new Attachment(caminhoArquivo);
                    message.Attachments.Add(anexo);
                }
                smtpClient.Send(message);
            }
                        MessageBox.Show("Email enviados com sucesso!");
            }
                catch
                {

                MessageBox.Show("Falha ao enviar email");
            }
        }
            else
            {
                MessageBox.Show("Confirme os clientes selecionados para poder enviar o email");
            }
        }

    
        ArrayList addCl = new ArrayList();

        string email = "";
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
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            if (listView2.SelectedItems.Count > 0)
            {
                string phrase = listView2.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');
                
                id_cliente = words[1];
                nomeCliente = words[2];
                guna2Button32.Enabled = true;
                dt = BLL.Clientes.queryCliente_mostrar_dados(Convert.ToInt32(id_cliente));
                foreach (DataRow row in dt.Rows)
                {
                    email = (string)row["email"];
                    nomeCliente = (string)row["nome"];
                    guna2PictureBox1.Image = byteArrayToImage((Byte[])row["imagem"]);
                    }

                    if (guna2PictureBox1.Image != null)
                    {
                        guna2Button10.Visible = true;
                        guna2Button9.Visible = true;
                    }
                    else
                    {

                        guna2Button10.Visible = false;
                        guna2Button9.Visible = false;
                    }
                

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
          if(guna2TextBox1.Text!= "" && guna2TextBox7.Text != "") { 
            guna2GroupBox4.Visible = true;
                carregar_cliente_PARA_LISTVIEW1();
          }
            else
            {
                MessageBox.Show("Escreva a menssagem de texto primeiro");
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2GroupBox4.Visible = false;
            guna2TextBox7.Clear();
            listView2.Clear();
            listView3.Clear();
            guna2PictureBox1.Image = null;
            q = 0;
        }
        int q = 0;
        
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if(q == 0)
            {
               
                guna2Button8.Text = "x";
                guna2Button8.Image = null;
                guna2Button8.FillColor =Color.FromArgb(234, 45, 63);
                DialogResult dr = MessageBox.Show("\"Têm a certeza que quer enviar a email aos clientes selecionados ?\"", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    q = 1;
                }
                else
                {

                    q = 0;
                    guna2Button8.Text = "";
                    guna2Button8.Image = Properties.Resources.correct1;
                    guna2Button8.FillColor = Color.FromArgb(75, 174, 79);
                }
                }
            else
            {
                q = 0;
                guna2Button8.Text = "";
                guna2Button8.Image = Properties.Resources.correct1;
                guna2Button8.FillColor = Color.FromArgb(75, 174, 79);
            }
         
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                dt = BLL.Clientes.queryCliente_mostrar_dados(Convert.ToInt32(id_cliente));
                foreach (DataRow row in dt.Rows)
                {
                    email = (string)row["email"];
                    nomeCliente = (string)row["nome"];
                    id_cliente = Convert.ToString((int)row["n_cliente"]);
                    addCl.Add(row);
                }
              
                    listView3.Clear();
                images3.Images.Clear();

                    i = 0;





                    foreach (DataRow row1 in addCl)

                    {



                    images3.ColorDepth = ColorDepth.Depth32Bit;

                        listView3.LargeImageList = images3;

                        listView3.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                        byte[] imagebyte = (byte[])(row1["imagem"]);

                        MemoryStream image_stream = new MemoryStream(imagebyte);

                        image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images3.Images.Add(row1["imagem"].ToString(), new Bitmap(image_stream));



                        image_stream.Close();



                        ListViewItem item = new ListViewItem();

                        item.ImageIndex = i;

                        item.Text = " " + row1["n_cliente"].ToString() + " " + row1["nome"].ToString();

                        i += 1;

                        this.listView3.Items.Add(item);











                    }
                
                }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            for (int i = addCl.Count - 1; i >= 0; i--)
            {
                DataRow row = (DataRow)addCl[i];
                // Condição para remover a linha
                if (row["n_cliente"].ToString() == id_cliente)

                {
                    addCl.RemoveAt(i);
                    guna2PictureBox1.Image = null;
                    MessageBox.Show("Removido");
                }
            }

            listView3.Clear();
                images3.Images.Clear();

                i = 0;





                foreach (DataRow row1 in addCl)

                {



                    images3.ColorDepth = ColorDepth.Depth32Bit;

                    listView3.LargeImageList = images3;

                    listView3.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                    byte[] imagebyte = (byte[])(row1["imagem"]);

                    MemoryStream image_stream = new MemoryStream(imagebyte);

                    image_stream.Write(imagebyte, 0, imagebyte.Length);

                    images3.Images.Add(row1["imagem"].ToString(), new Bitmap(image_stream));



                    image_stream.Close();



                    ListViewItem item = new ListViewItem();

                    item.ImageIndex = i;

                    item.Text = " " + row1["n_cliente"].ToString() + " " + row1["nome"].ToString();

                    i += 1;

                    this.listView3.Items.Add(item);











                
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                string phrase = listView3.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');

                id_cliente = words[1];
                nomeCliente = words[2];
            }
            }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivo = openFileDialog1.FileName;
            }
        }
        void carregar_cliente_PARA_LISTVIEW1234()
        {
            




            DataTable dt = BLL.Clientes.queryLoad_cliente1234(guna2TextBox3.Text);

            listView2.Clear();
            images1.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images1.ColorDepth = ColorDepth.Depth32Bit;

                listView2.LargeImageList = images1;

                listView2.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images1.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_cliente"].ToString() + " " + row["nome"].ToString();

                i += 1;

                this.listView2.Items.Add(item);











            }



        }
        void carregar_cliente_PARA_LISTVIEW12345()
        {





            DataTable dt = BLL.Clientes.queryLoad_cliente1234(guna2TextBox2.Text);

            listView1.Clear();
            images2.Images.Clear();

            i = 0;





            foreach (DataRow row in dt.Rows)

            {



                images2.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images2;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images2.Images.Add(row["imagem"].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = " " + row["n_cliente"].ToString() + " " + row["nome"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }



        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {
            
                carregar_cliente_PARA_LISTVIEW12345();
            
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
           
                carregar_cliente_PARA_LISTVIEW1234();
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
