using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Stand_up
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ImageList images = new ImageList();
        private void inserirCarroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removerVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void especificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void Form2_Load(object sender, EventArgs e)
        {
            carregar_car_PARA_LISTVIEW();



        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Form1.flagInsertCAR = true ;
           
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.flagEditCAR = true;
        }
    }
    }

