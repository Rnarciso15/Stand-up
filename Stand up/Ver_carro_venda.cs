using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            DataTable info = BLL.veiculos.Load_dados(carros_para_venda.Matricula);

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
    }
}
