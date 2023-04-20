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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        static public bool flagInsertCAR = false;
        static public bool flagEditCAR = false;
        int l = 0;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            watch f2 = new watch();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();

            DataTable dt = BLL.Func.LoadPerfil(Form5.n_func);

            foreach (DataRow row in dt.Rows)
            {
                label1.Text = (string)row["nome"];
                guna2CirclePictureBox2.Image = byteArrayToImage((Byte[])row["Imagem"]);

            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            watch f2 = new watch();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flagInsertCAR == true)
            {
                Inserir_Carro f2 = new Inserir_Carro();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                l = 1;

            }
            if (l == 1) {
                flagInsertCAR = false;
                l = 0;
            }


            if (flagEditCAR == true)
            {
                Inserir_Carro f2 = new Inserir_Carro();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                l = 1;

            }
            if (l == 1)
            {
                flagEditCAR = false;
                l = 0;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
                carros_para_venda f2 = new carros_para_venda();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
             

          
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Marcacao_test f2 = new Marcacao_test();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
        }
    }
}
