using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            DialogResult dr = MessageBox.Show("Pertende efetuar a compra ?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                BLL.transacoes.insertTrans(Convert.ToInt32(id_cliente), carros_para_venda.Matricula,DateTime.Now,Convert.ToInt32(label24.Text));
                int x = BLL.veiculos.updateVendido(carros_para_venda.Matricula, true);
                carros_para_venda.flagVendido = true;
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
