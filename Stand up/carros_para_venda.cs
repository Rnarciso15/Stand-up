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
        string Cor;
        ImageList images = new ImageList();
        public static bool flagPanel = true ;
    
        int k=0;
        int l = 0;
        int j = 0;
        private void carros_para_venda_Load(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW();
            timer1.Start();
        }
        void carregar_car_PARA_LISTVIEW10()
        {





            DataTable dr = BLL.veiculos.queryCarro4(Combustivel, Cor);

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
        void carregar_car_PARA_LISTVIEW6()
        {





            DataTable dr = BLL.veiculos.queryCarro(Cor, Marca);

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
        void carregar_car_PARA_LISTVIEW8()
        {





            DataTable dr = BLL.veiculos.queryCarro3(Combustivel,Marca ,Cor);

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
        void carregar_car_PARA_LISTVIEW7()
        {





            DataTable dr = BLL.veiculos.queryCarro2(Combustivel, Marca);

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
            k = 1;
            funcoesCarregadas = false;
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Combustivel = "Gasóleo";
            k = 1;
        }

        private void elétricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Combustivel = "Elétrico";
            k = 1;
        }

        private void hibridoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Combustivel = "Hibrido";
            k = 1;
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
            l = 1;
            funcoesCarregadas = false;
        }

        private void audiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marca = "Audi";
            l = 1;
            funcoesCarregadas = false;
        }

        private void bMWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "BMW";
            l = 1;
        }

        private void chevroletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Chevrolet";
            l = 1;
        }

        private void citroënToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Citroën";
            l = 1;
        }

        private void cupraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Cupra";
            l = 1;
        }

        private void daciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Dacia";
            l = 1;
        }

        private void fiatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Fiat";
            l = 1;
        }

        private void fordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Ford";
            l = 1;
        }

        private void hondaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Honda";
            l = 1;
        }

        private void hyondaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Hyundai";
            l = 1;
        }

        private void jaguarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Jaguar";
            l = 1;
        }

        private void jeepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Jeep";
            l = 1;
        }

        private void kiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Kia";
            l = 1;
        }

        private void landRoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Land Rover";
            l = 1;
        }

        private void lexusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Lexus";
            l = 1;
        }

        private void mazdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Mazda";
            l = 1;
        }

        private void mercedesBenzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Mercedes-Benz";
            l = 1;
        }

        private void miniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Mini";
            l = 1;
        }

        private void mitsubishiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Mitsubishi";
            l = 1;
        }

        private void nissanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Nissan";
            l = 1;
        }

        private void opelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Opel";
            l = 1;
        }

        private void peugeotToolStripMenuItem_Click(object sender, EventArgs e)
        {

            funcoesCarregadas = false;
            Marca = "Peugeot";
            l = 1;
        }

        private void renaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Renault";
            l = 1;
        }

        private void seatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Seat";
            l = 1;
        }

        private void skodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Skoda";
            l = 1;
        }

        private void smartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Smart";
            l = 1;
        }

        private void teslaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Tesla";
            l = 1;
        }

        private void toyotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Toyota";
            l = 1;
        }

        private void volkswagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Volkswagen";
            l = 1;
        }

        private void volvoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Marca = "Volvo";
            l = 1;
        }
        bool funcoesCarregadas = false;
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
            //  if (k == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW1();
            //  }
            //  if (l == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW4();
            //  }
            // if (j == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW5();
            //  }
            //  if (k == 1 && j == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW10();
            //  }
            //  if (l == 1 &&  j == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW6();
            //  }
            //if (l == 1 && k == 1)
            //  {
            //      carregar_car_PARA_LISTVIEW7();
            //  }
            //  if (l == 1 && k == 1 && j==1)
            //  {
            //      carregar_car_PARA_LISTVIEW8();
            //  }
          

            if (k == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW1();
                funcoesCarregadas = true;
            }
            if (l == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW4();
                funcoesCarregadas = true;
            }
            if (j == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW5();
                funcoesCarregadas = true;
            }
            if (k == 1 && j == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW10();
                funcoesCarregadas = true;
            }
            if (l == 1 && j == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW6();
                funcoesCarregadas = true;
            }
            if (l == 1 && k == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW7();
                funcoesCarregadas = true;
            }
            if (l == 1 && k == 1 && j == 1 && funcoesCarregadas == false)
            {
                carregar_car_PARA_LISTVIEW8();
                funcoesCarregadas = true;
            }

        }

        private void escurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Amarelo";
            j = 1;
        }

        private void claraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Azul";
            j = 1;

        }

        private void begeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Bege";
            j = 1;

        }

        private void brancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Branco";
            j = 1;

        }

        private void castanhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Castanho";
            j = 1;

        }


        private void cinzentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Cinzento";
            j = 1;

        }

        private void douradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Dourado";
            j = 1;

        }

        private void laranjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Laranja";
            j = 1;

        }

        private void prateadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Prateado";
            j = 1;

        }

        private void pretoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Preto";
            j = 1;

        }

        private void roxoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Roxo";
            j = 1;

        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Verde";
            j = 1;

        }

        private void vermelhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funcoesCarregadas = false;
            Cor = "Vermelho";
            j = 1;

        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            l = 1;
        }

        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            j = 1;
        }

        private void todosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            k = 3;
            funcoesCarregadas = true;
        }

        private void limparFiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 0;
            j = 0;
            l = 0;
            Combustivel = "";
             Marca = "";
             Cor = "";
            carregar_car_PARA_LISTVIEW();
        }
    }
}
