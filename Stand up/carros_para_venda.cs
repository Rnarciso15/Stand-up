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
    public partial class carros_para_venda : Form
    {
        public carros_para_venda()
        {
            InitializeComponent();
        }
        string Combustivel;
        string Marca;
        ImageList images = new ImageList();
        private void carros_para_venda_Load(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW();
        }
        void carregar_car_PARA_LISTVIEW()
        {





            DataTable dr = BLL.veiculos.queryLoad_veiculo();

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }

        void carregar_car_PARA_LISTVIEW1()
        {





            DataTable dr = BLL.veiculos.queryGasolina_veiculo(Combustivel);

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }

        void carregar_car_PARA_LISTVIEW2()
        {





            DataTable dr = BLL.veiculos.querymaior_quiilometros();

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }

        void carregar_car_PARA_LISTVIEW3()
        {





            DataTable dr = BLL.veiculos.queryMenor_quiilometros();

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }


        void carregar_car_PARA_LISTVIEW4()
        {





            DataTable dr = BLL.veiculos.queryMarca_veiculo(Marca);

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }
        private void carroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
         


        }

        private void listView1_MouseHover(object sender, EventArgs e)
        {
        
        }
        public static string Matricula ;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
              Matricula = listView1.SelectedItems[0].Text;           

            }



            Ver_carro_venda f2 = new Ver_carro_venda();
                guna2Panel1.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel1;
                f2.Show();
        
           

               

            
        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Combustivel = "Gasolina";
            carregar_car_PARA_LISTVIEW1();
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Combustivel = "Gasóleo";
            carregar_car_PARA_LISTVIEW1();
        }

        private void elétricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Combustivel = "Elétrico";
            carregar_car_PARA_LISTVIEW1();
        }

        private void hibridoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Combustivel = "Hibrído";
            carregar_car_PARA_LISTVIEW1();
        }

        private void inserirEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW2();
        }

        private void ediitarEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW3();

        }

        private void bMWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Alfa Romeo";
            carregar_car_PARA_LISTVIEW4();
        }

        private void audiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Audi";
            carregar_car_PARA_LISTVIEW4();
        }

        private void bMWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Marca = "BMW";
            carregar_car_PARA_LISTVIEW4();
        }

        private void chevroletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Chevrolet";
            carregar_car_PARA_LISTVIEW4();
        }

        private void citroënToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Citroën";
            carregar_car_PARA_LISTVIEW4();
        }
    }
}
