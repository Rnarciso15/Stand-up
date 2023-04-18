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

        private void Form2_Load(object sender, EventArgs e)
        {
            //DataTable dr = BLL.Imovel.Load();

            //listView1.Clear();



            //ImageList images = new ImageList();

            //foreach (DataRow row in dr.Rows)

            //{

            //    images.ColorDepth = ColorDepth.Depth32Bit;

            //    listView1.LargeImageList = images;

            //    listView1.LargeImageList.ImageSize = new System.Drawing.Size(255, 255);



            //    byte[] imagebyte = (byte[])(row[5]);

            //    MemoryStream image_stream = new MemoryStream(imagebyte);

            //    image_stream.Write(imagebyte, 0, imagebyte.Length);

            //    images.Images.Add(row[5].ToString(), new Bitmap(image_stream));



            //    image_stream.Close();



            //    ListViewItem item = new ListViewItem();

            //    item.ImageIndex = i;

            //    item.Text = row["id_p"].ToString();

            //    i += 1;

            //    this.listView1.Items.Add(item);





            //}





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

