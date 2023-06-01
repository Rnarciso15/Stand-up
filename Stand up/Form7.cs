using System;
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
        string caminhoArquivo = "";
        int i = 0;
        int ww = 0;
        ImageList images2 = new ImageList();
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
          

            if(ww == 0)
            {
                guna2GroupBox3.Visible = true;
                ww = 1;
            }
            else
            {
                guna2GroupBox3.Visible = false;
                ww = 0;
            }
            string texto = "Bom dia Sr " + nomeCliente + "," + "\r\n" +
                "\r\n" +
                              guna2TextBox7.Text +
                                 "\r\n" +
                "\r\n" +
                       "\r\n" +
                       "Obrigado, \r\n"
                        + "Stand Up";
            guna2TextBox2.Text = texto;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2GroupBox3.Visible = false;
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
            else
            {

                MessageBox.Show("Preencha todos os campos");
            }
        }
    }
}
