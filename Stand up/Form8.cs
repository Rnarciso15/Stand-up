using BusinessLogicLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using Image = System.Drawing.Image;
using PdfSharp.Drawing;

namespace Stand_up
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        ImageList images1 = new ImageList();
        ImageList images2 = new ImageList();
        int i = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text !="")
            {
                carregar_cliente_PARA_LISTVIEW1();
            }
            else
            {
                carregar_cliente_PARA_LISTVIEW();
            }
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

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(123, 123);



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





            DataTable dt = BLL.Clientes.queryCliente_Like_nome_ativo(guna2TextBox1.Text,true);

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

                item.Text = " " + row["n_cliente"].ToString() + " " + row["nome"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }



        }
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)

        {

            using (MemoryStream mStream = new MemoryStream(byteArrayIn))

            {

                return System.Drawing.Image.FromStream(mStream);

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
        int valor=0;
        private void Form8_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            DataTable info = BLL.veiculos.Load_dados(carros_para_venda.Matricula);

            foreach (DataRow row in info.Rows)
            {
                label2.Text = (string)row["Data"];
                label4.Text = (string)row["Marca"];
                label3.Text = (string)row["Modelo"];
                label1.Text = (string)row["Matricula"];
                valor = (int)row["Valor"];
                label24.Text = Convert.ToString((int)row["Valor"]) + " €";
                guna2PictureBox1.Image = byteArrayToImage((Byte[])row["Imagem"]);
                

            }
            carregar_cliente_PARA_LISTVIEW();

        }
        string id_cliente = "";
        string nomeCliente = "";
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string phrase = listView1.SelectedItems[0].Text; ;
                string[] words = phrase.Split(' ');

                id_cliente = words[1];
                nomeCliente = words[2];
                DataTable info = BLL.Clientes.LoadCliente_proc(Convert.ToInt32(id_cliente));

                foreach (DataRow row in info.Rows)
                {
                    label7.Text = (string)row["nome"];
                    label9.Text = (string)row["email"];
                    label5.Text = (string)row["nib"];
                    label6.Text = Convert.ToString((int)row["n_cliente"]);
                    guna2PictureBox2.Image = byteArrayToImage((Byte[])row["imagem"]);


                }

            }
        }
    
        private void guna2Button32_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                int nif_cliente = 0;
                DataTable nif = BLL.transacoes.loadnif_Cliente (Convert.ToInt32(id_cliente));
                foreach (DataRow row in nif.Rows)
                {
                    nif_cliente = Convert.ToInt32( (string)row["nif"]);
                }
                    DialogResult dr = MessageBox.Show("Pertende efetuar a compra ?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                BLL.transacoes.insertTrans(nif_cliente, carros_para_venda.Matricula,DateTime.Now.ToString(),valor,nomeCliente);
                int x = BLL.veiculos.updateVendido(carros_para_venda.Matricula, true);
                carros_para_venda.flagVendido = true;
                Form1.flagCancTransacao = true;
            }
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        DataTable informacao = BLL.veiculos.Load_dados_imagem(carros_para_venda.Matricula);
                        string data = "";
                        string Marca = "";
                        string Modelo = "";
                        string Matricula = "";
                        string Quilometros = "";
                        string Combustivel = "";
                        string Descricao = "";
                        string Valor = "";
                        string Traccao = "";
                        string Cor = "";
                        string Tipo_de_Caixa = "";
                        string N_Portas = "";
                        byte[] imageBytes = null;
                        foreach (DataRow row in informacao.Rows)
                        {
                            data = (string)row["Data"];
                            Marca = (string)row["Marca"];
                            Modelo = (string)row["Modelo"];
                            Matricula = (string)row["Matricula"];
                            Quilometros = Convert.ToString((int)row["Quilometros"]);
                            Combustivel = (string)row["Combustivel"];
                            Descricao = (string)row["Descricao"];
                            Valor = Convert.ToString((int)row["Valor"]) + " €";
                            imageBytes = (Byte[])row["Imagem"];
                            Cor = (string)row["Cor"];
                            Tipo_de_Caixa = (string)row["Tipo_de_Caixa"];
                            N_Portas = Convert.ToString((int)row["N_Portas"]);
                            Traccao = (string)row["Traccao"];

                        }
                        // Cria um novo documento PDF
                        PdfDocument document = new PdfDocument();

                        // Cria uma nova página
                        PdfPage page = document.AddPage();

                        // Obtém um objeto XGraphics para desenhar na página
                        XGraphics gfx = XGraphics.FromPdfPage(page);
                        DataTable logo = BLL.Imagem.loadlogo();
                        XImage image9 = null;
                        foreach (DataRow row in logo.Rows)
                        {

                            Image img5 = byteArrayToImage((Byte[])row["logo"]);
                            byte[] img7 = imgToByteArray(img5);
                            using (MemoryStream stream = new MemoryStream(img7))
                            {
                                image9 = XImage.FromStream(stream);

                                // Usar o objeto XImage como necessário (por exemplo, desenhar ou adicionar ao PDF)
                            }

                        }
                        // Carrega as imagens

                        XImage image;

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            image = XImage.FromStream(ms);
                        }

                        double x = 50;
                        double y = 50;

                        // Redimensiona o logo para um tamanho menor
                        double logoWidth = 75;  // Largura desejada para o logo
                        double logoHeight = logoWidth * image9.PixelHeight / image9.PixelWidth;

                        // Obtém as coordenadas para posicionar o logo no canto superior direito
                        double logoX = page.Width - logoWidth - 15;
                        double logoY = 2;

                        // Adiciona o logo no canto superior direito com ajuste de tamanho
                        gfx.DrawImage(image9, logoX, logoY, logoWidth, logoHeight);

                        // Adiciona o título

                        XFont titleFont = new XFont("Arial", 28, XFontStyle.Bold);
                        XSize titleSize = gfx.MeasureString(Marca + " " + Modelo, titleFont);
                        double titleX = (page.Width - titleSize.Width) / 2;
                        double titleY = y + 65;
                        gfx.DrawString(Marca + " " + Modelo, titleFont, XBrushes.Black, titleX, titleY);

                        // Adiciona a imagem do carro
                        double carImageWidth = 400;  // Largura desejada para a imagem do carro
                        double carImageHeight = carImageWidth * image.PixelHeight / image.PixelWidth;
                        double carImageX = (page.Width - carImageWidth) / 2;
                        double carImageY = y + 100;
                        gfx.DrawImage(image, carImageX, carImageY, carImageWidth, carImageHeight);
                        // Adiciona as especificações
                        XFont contentFont = new XFont("Arial", 12);
                        gfx.DrawString("Especificações:", contentFont, XBrushes.Black, x, y + 500);
                        y += 20;
                        // Restante das especificações
                        gfx.DrawString("Data: " + data, contentFont, XBrushes.Black, x, y + 520);
                        gfx.DrawString("Cor: " + Cor, contentFont, XBrushes.Black, x + 200, y + 520);
                        y += 20;
                        // Restante das especificações
                        gfx.DrawString("Marca: " + Marca, contentFont, XBrushes.Black, x, y + 520);
                        gfx.DrawString("Tipo de Caixa: " + Tipo_de_Caixa, contentFont, XBrushes.Black, x + 200, y + 520);
                        y += 20;
                        // Restante das especificações
                        gfx.DrawString("Modelo: " + Modelo, contentFont, XBrushes.Black, x, y + 520);
                        gfx.DrawString("Nº de Portas: " + N_Portas, contentFont, XBrushes.Black, x + 200, y + 520);
                        y += 20;
                        // Restante das especificações
                        gfx.DrawString("Matricula: " + Matricula, contentFont, XBrushes.Black, x, y + 520);
                        gfx.DrawString("Traccção: " + Traccao, contentFont, XBrushes.Black, x + 200, y + 520);
                        y += 20;
                        // Restante das especificações
                        gfx.DrawString("Quilómetros: " + Quilometros, contentFont, XBrushes.Black, x, y + 520);
                        gfx.DrawString("Combustivel: " + Combustivel, contentFont, XBrushes.Black, x + 200, y + 520);

                        y += 40;
                        // Restante das especificações
                        gfx.DrawString("Valor: " + Valor, contentFont, XBrushes.Black, x + 200, y + 520);
                        // Restante das especificações...

                        DataTable addcl = BLL.Clientes.LoadCliente_proc(Convert.ToInt32(id_cliente));
                        foreach (DataRow row in addcl.Rows)
                        {
                            string fromemail = "standuprla@gmail.com";
                            string frompassword = "qisznqsrmsszpvif";

                            MailMessage message = new MailMessage();
                            // Criando a mensagem de e-mail
                            message.From = new MailAddress(fromemail);
                            message.To.Add(new MailAddress((string)row["email"]));
                            message.Subject = guna2TextBox1.Text;
                            string texto = "Bom dia Sr " + (string)row["nome"] + "," + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "Obrigado, \r\n" + "Stand Up";
                            message.Body = "<html><body>" + texto + "</body></html>";
                            message.IsBodyHtml = true;

                            var smtpClient = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromemail, frompassword),
                                EnableSsl = true
                            };

                            // Criar o arquivo PDF em um fluxo de memória
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                // Salvar o documento PDF no fluxo de memória
                                document.Save(memoryStream);
                                memoryStream.Position = 0;

                                // Anexar o arquivo PDF ao email
                                Attachment attachment = new Attachment(memoryStream, "" + Modelo + ".pdf", "application/pdf");
                                message.Attachments.Add(attachment);

                                // Enviar o email
                                smtpClient.Send(message);
                            }
                        }

                        MessageBox.Show("Email enviados com sucesso!");
                    }
                    catch
                    {
                        MessageBox.Show("Falha ao enviar email");
                    }
                    }


            }
            else
            {
                MessageBox.Show("Selecione o cliente que irá efetuar a compra do veiculo");
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
          Form1.flagCancTransacao = true;
        }
    }
}
