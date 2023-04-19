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
    }
}
