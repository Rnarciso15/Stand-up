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
        public static bool flagPanel = true ;
        string Cor;
        private void carros_para_venda_Load(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW();
            timer1.Start();
        }
        void carregar_car_PARA_LISTVIEW()
        {





            DataTable dr = BLL.veiculos.queryLoad_veiculo();
          
            listView1.Clear();
            images.Images.Clear();
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



                listView1.ForeColor = Color.Black;







            }





        }

        void carregar_car_PARA_LISTVIEW1()
        {





            DataTable dr = BLL.veiculos.queryGasolina_veiculo(Combustivel);

            listView1.Clear();
            images.Images.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["Imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row["Imagem"].ToString(), new Bitmap(image_stream));



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
            images.Images.Clear();
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
            images.Images.Clear();
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
            images.Images.Clear();
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

        void carregar_car_PARA_LISTVIEW5()
        {





            DataTable dr = BLL.veiculos.queryCor_veiculo(Cor);

            listView1.Clear();
            images.Images.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(200, 200);



                byte[] imagebyte = (byte[])(row["Imagem"]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row["Imagem"].ToString(), new Bitmap(image_stream));



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
                guna2Panel1.Visible = true;
                flagPanel = false;
            }
            else
            {
                guna2Panel1.Visible = false;
                flagPanel = true;
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
            Combustivel = "Hibrido";
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

        private void cupraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Cupra";
            carregar_car_PARA_LISTVIEW4();
        }

        private void daciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Dacia";
            carregar_car_PARA_LISTVIEW4();
        }

        private void fiatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Fiat";
            carregar_car_PARA_LISTVIEW4();
        }

        private void fordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Ford";
            carregar_car_PARA_LISTVIEW4();
        }

        private void hondaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Honda";
            carregar_car_PARA_LISTVIEW4();
        }

        private void hyondaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Hyundai";
            carregar_car_PARA_LISTVIEW4();
        }

        private void jaguarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Jaguar";
            carregar_car_PARA_LISTVIEW4();
        }

        private void jeepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Jeep";
            carregar_car_PARA_LISTVIEW4();
        }

        private void kiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Kia";
            carregar_car_PARA_LISTVIEW4();
        }

        private void landRoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Land Rover";
            carregar_car_PARA_LISTVIEW4();
        }

        private void lexusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Lexus";
            carregar_car_PARA_LISTVIEW4();
        }

        private void mazdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Mazda";
            carregar_car_PARA_LISTVIEW4();
        }

        private void mercedesBenzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Mercedes-Benz";
            carregar_car_PARA_LISTVIEW4();
        }

        private void miniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Mini";
            carregar_car_PARA_LISTVIEW4();
        }

        private void mitsubishiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Mitsubishi";
            carregar_car_PARA_LISTVIEW4();
        }

        private void nissanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Nissan";
            carregar_car_PARA_LISTVIEW4();
        }

        private void opelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Opel";
            carregar_car_PARA_LISTVIEW4();
        }

        private void peugeotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Peuge0t";
            carregar_car_PARA_LISTVIEW4();
        }

        private void renaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Renault";
            carregar_car_PARA_LISTVIEW4();
        }

        private void seatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Seat";
            carregar_car_PARA_LISTVIEW4();
        }

        private void skodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Skoda";
            carregar_car_PARA_LISTVIEW4();
        }

        private void smartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Smart";
            carregar_car_PARA_LISTVIEW4();
        }

        private void teslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Tesla";
            carregar_car_PARA_LISTVIEW4();
        }

        private void toyotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Toyota";
            carregar_car_PARA_LISTVIEW4();
        }

        private void volkswagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Volkswagen";
            carregar_car_PARA_LISTVIEW4();
        }

        private void volvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Volvo";
            carregar_car_PARA_LISTVIEW4();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
          if(flagPanel == false)
            {

                guna2Panel1.Visible = true;

            }
            else
            {
                guna2Panel1.Visible = false;

            }


        }

        private void escurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Amarelo";
            carregar_car_PARA_LISTVIEW5();
        }

        private void claraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Azul";
            carregar_car_PARA_LISTVIEW5();
        }

        private void begeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Bege";
            carregar_car_PARA_LISTVIEW5();
        }

        private void brancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Branco";
            carregar_car_PARA_LISTVIEW5();
        }

        private void castanhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Castanho";
            carregar_car_PARA_LISTVIEW5();
        }

        private void cinzentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Cinzento";
            carregar_car_PARA_LISTVIEW5();
        }

        private void douradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Dourado";
            carregar_car_PARA_LISTVIEW5();
        }

        private void laranjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Laranja";
            carregar_car_PARA_LISTVIEW5();
        }

        private void prateadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Prateado";
            carregar_car_PARA_LISTVIEW5();
        }

        private void pretoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Preto";
            carregar_car_PARA_LISTVIEW5();
        }

        private void roxoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Roxo";
            carregar_car_PARA_LISTVIEW5();
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Verde";
            carregar_car_PARA_LISTVIEW5();
        }

        private void vermelhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cor = "Vermelho";
            carregar_car_PARA_LISTVIEW5();
        }
    }
}
