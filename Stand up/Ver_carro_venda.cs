using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Windows.Forms;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using Guna.UI2.WinForms;
using System.Collections;

namespace Stand_up
{
    public partial class Ver_carro_venda : Form
    {
        public Ver_carro_venda()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            carros_para_venda.flagPanel = true;
            this.Close();
        
    }

        private void Ver_carro_venda_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            DataTable info = BLL.veiculos.Load_dados(carros_para_venda.Matricula);

            DataTable iMG_CAR = BLL.Imagem.LoadImagensCarro(carros_para_venda.Matricula);
            foreach (DataRow row in iMG_CAR.Rows)
            {
                imagem_carro.Add((byte[])row["Image"]);
            
            }
                foreach (DataRow row in info.Rows)
            {
                label2.Text = (string)row["Data"];
                label4.Text = (string)row["Marca"];
                label3.Text = (string)row["Modelo"];
                label1.Text = (string)row["Matricula"];
                label23.Text = Convert.ToString((int)row["Quilometros"]);
                label22.Text = (string)row["Combustivel"];
                label21.Text = (string)row["Descricao"];
                label24.Text = Convert.ToString((int)row["Valor"]) + " €";
                guna2PictureBox1.Image = byteArrayToImage((Byte[])row["Imagem"]);
                label20.Text = (string)row["Cor"];
                label7.Text = (string)row["Tipo_de_Caixa"];
                label6.Text = Convert.ToString((int)row["N_Portas"]);
                label5.Text = (string)row["Traccao"];

            }
            
        }

        private void Ver_carro_venda_FormClosed(object sender, FormClosedEventArgs e)
        {
            carros_para_venda.flagPanel = true;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DataTable informacao = BLL.veiculos.Load_dados_imagem(carros_para_venda.Matricula);
            string data ="";
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
                byte[] img7= imgToByteArray(img5);
                using (MemoryStream stream = new MemoryStream(img7))
                {
                     image9= XImage.FromStream(stream);

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
            double logoX = page.Width - logoWidth -15;
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
            gfx.DrawString("Especificações:", contentFont, XBrushes.Black, x, y+500);
            y += 20;
            // Restante das especificações
            gfx.DrawString("Data: "+ data, contentFont, XBrushes.Black, x, y+520);
            gfx.DrawString("Cor: " + Cor, contentFont, XBrushes.Black, x + 200, y+520);
            y += 20;
            // Restante das especificações
            gfx.DrawString("Marca: "+ Marca, contentFont, XBrushes.Black, x, y + 520);
            gfx.DrawString("Tipo de Caixa: "+Tipo_de_Caixa, contentFont, XBrushes.Black, x + 200, y + 520);
            y += 20;
            // Restante das especificações
            gfx.DrawString("Modelo: " +Modelo, contentFont, XBrushes.Black, x, y + 520);
            gfx.DrawString("Nº de Portas: "+N_Portas, contentFont, XBrushes.Black, x + 200, y + 520);
            y += 20;
            // Restante das especificações
            gfx.DrawString("Matricula: "+Matricula, contentFont, XBrushes.Black, x, y + 520);
            gfx.DrawString("Traccção: "+Traccao, contentFont, XBrushes.Black, x + 200, y + 520);
            y += 20;
            // Restante das especificações
            gfx.DrawString("Quilómetros: "+Quilometros, contentFont, XBrushes.Black, x, y + 520);
            gfx.DrawString("Combustivel: "+Combustivel, contentFont, XBrushes.Black, x + 200, y + 520);

            y += 40;
            // Restante das especificações
            gfx.DrawString("Valor: "+Valor, contentFont, XBrushes.Black, x+200, y + 520);
            // Restante das especificações...

            // Salva o documento em um arquivo

            // Fecha o documento

            saveFileDialog1.Title = "Salvar arquivo PDF";
            saveFileDialog1.Filter = "Arquivos PDF (*.pdf)|*.pdf|Todos os Arquivos (*.*)|*.*";
            saveFileDialog1.FileName = Marca + "_" + Modelo;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = saveFileDialog1.FileName;
                document.Save(caminhoArquivo);
                document.Close();
            }
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1.flagTransacao = true;
           

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        int IMG_Idx = 0;
        ArrayList imagem_carro = new ArrayList();
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            IMG_Idx++;
            if (IMG_Idx >= imagem_carro.Count)
            {
                IMG_Idx = 0;
            }

            if (IMG_Idx >= 0 && IMG_Idx < imagem_carro.Count)
            {
                byte[] imagePath = (byte[])imagem_carro[IMG_Idx];
                guna2PictureBox1.Image = byteArrayToImage( imagePath);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            IMG_Idx -= 1;
            if (IMG_Idx < 0)
            {
                IMG_Idx = imagem_carro.Count - 1;
            }

            if (IMG_Idx >= 0 && IMG_Idx < imagem_carro.Count)
            {
                byte[] imagePath = (byte[])imagem_carro[IMG_Idx];
                guna2PictureBox1.Image = byteArrayToImage(imagePath);
            }
        }
    }
}
