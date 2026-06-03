using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stand_up;

namespace Stand_up
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ImageList images = new ImageList();
        private static System.Drawing.Bitmap CreateThumbnail(byte[] bytes)
        {
            if (bytes != null && bytes.Length > 0)
            {
                try
                {
                    using (var ms = new System.IO.MemoryStream(bytes))
                    using (var src = System.Drawing.Image.FromStream(ms))
                        return new System.Drawing.Bitmap(src);
                }
                catch { }
            }
            var bmp = new System.Drawing.Bitmap(255, 255);
            using (var g = System.Drawing.Graphics.FromImage(bmp))
                g.Clear(System.Drawing.Color.FromArgb(45, 45, 50));
            return bmp;
        }
     public static   bool flagInsertCAR = false;
        public static bool flagEditCAR = false;

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





            DataTable dr = ApiService.veiculos.queryLoad_veiculo(false);

            listView1.Clear();
            int i = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize =  new System.Drawing.Size(255, 255);


                images.Images.Add(row["Matricula"].ToString(), CreateThumbnail(row["Imagem"] as byte[]));



                ListViewItem item = new ListViewItem();

                item.ImageIndex = i;

                item.Text = row["Matricula"].ToString();

                i += 1;

                this.listView1.Items.Add(item);











            }





        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try { 
            carregar_car_PARA_LISTVIEW();
            DoubleBuffered = true;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }

        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            Form1.flagInsertCAR = true;
            Form1.flagEditCAR = false;
            flagInsertCAR = true ;
            flagEditCAR = false;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            Form1.flagEditCAR = true;
            Form1.flagInsertCAR = false;
            flagEditCAR = true;
            flagInsertCAR = false;
            }
            catch
            {
                MessageBox.Show("Erro ao processar as informações, Por favor reinicie a aplicação");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
    }


