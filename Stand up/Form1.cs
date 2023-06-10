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
using System.Threading.Tasks;
using System.Threading;

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
        public static bool flag_lista_func = false;
        public static bool flag_config = false;

        public static bool flagInsertFunc = false;
        public static bool flagEditFunc = false;
        public static bool flagFunc = false;
        public static bool flagCliente = false;
        public static bool flagInsertCliente = false;
        public static bool flagEditCliente = false;
        public static bool flagEmail = false;

        public static bool flagTransacao = false;


        public static bool flagCancTransacao = false;
        int l = 0;
        int K = 0;
        int j = 0;
        int y = 0;
        int w = 0;
        int ww = 0;
        int yyy = 0;
        int yy = 0;
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
        public static int ll = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            timer1.Start();
            watch f2 = new watch();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
            string admin = BLL.Func.Buscar_admin(Form5.n_func);

            if (admin != "True")
            {
                Form1.flagFunc = false;
                Form1.flagCliente = true;
            }
            else
            {
              
                Form1.flagFunc = true;
                Form1.flagInsertFunc = true;


            }
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
            if (flag_lista_func == true)
            {
                Form6 f2 = new Form6();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                j = 1;

            }
            if (j == 1)
            {
                flag_lista_func = false;
                j = 0;
            }
            if (flagEmail == true)
            {
                Form7 f2 = new Form7();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                ww = 1;

            }
            if (ww == 1)
            {
                flagEmail = false;
                ww = 0;
            }
            if (flag_config == true)
            {
                Form4 f2 = new Form4();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                y = 1;

            }
            if (y == 1)
            {
                flag_config = false;
                y = 0;
            }


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
                w = 1;

            }
            if (w == 1)
            {
                flagEditCAR = false;
                w = 0;
            }
            if (flagTransacao == true)
            {
                Form8 f2 = new Form8();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                yy = 1;
            }
            if (yy == 1)
            {
                flagTransacao = false;
                yy = 0;
            }
            if (flagCancTransacao == true)
            {
                carros_para_venda f2 = new carros_para_venda();
                guna2Panel3.Controls.Clear();
                f2.TopLevel = false;
                f2.Parent = guna2Panel3;
                f2.Show();
                yyy = 1;
            }
            if (yyy == 1)
            {
                flagCancTransacao = false;
                yyy = 0;
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

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            if (K == 0)
            {
                guna2Panel4.Visible = true;
                K += 1;
            }
            else
            {
                guna2Panel4.Visible = false;
                K = 0;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (K == 0)
            {
                guna2Panel4.Visible = true;
                K += 1;
            }
            else
            {
                guna2Panel4.Visible = false;
                K = 0;
            }

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form5 f2 = new Form5();
            this.Hide();
            f2.Show();

           
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Form5 f2 = new Form5();
            this.Hide();
            f2.Show();
            
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4();
            guna2Panel3.Controls.Clear();
            f2.TopLevel = false;
            f2.Parent = guna2Panel3;
            f2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
