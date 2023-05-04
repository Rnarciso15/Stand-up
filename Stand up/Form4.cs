using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Stand_up
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int q = 0;
        int u = 0;
        int i = 0;
        int h = 0;
        int w = 0;
        int ano;
        int n_func;
        private void inserirEspecificaçõesDoVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            if (q == 0)
            {
                guna2HtmlLabel1.Location = new Point(326, 353);
                guna2HtmlLabel1.Text = "Cancelar";               
                guna2TextBox1.Visible = true;
                guna2Button1.Visible = true;
                label3.Visible = true;
                guna2Button2.Visible = true;
                q += 1;
            }
            else
            {

                guna2HtmlLabel1.Location = new Point(308, 311);
                guna2HtmlLabel1.Text = "Mudar Senha";
                guna2TextBox1.Visible = false;
                guna2Button1.Visible = false;
                label3.Visible = false;
                guna2Button2.Visible = false;
                q = 0;
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel1.Location = new Point(308, 311);
            guna2TextBox1.UseSystemPasswordChar = true;
            guna2TextBox11.UseSystemPasswordChar = true;
            guna2DataGridView1.DataSource = BLL.Func.Load();
            DataTable dt = BLL.Func.LoadPerfil(Form5.n_func);
            string admin = BLL.Func.Buscar_admin(Form5.n_func);
            if(admin != "True")
            {
                guna2GroupBox2.Visible = false;
                guna2GroupBox3.Visible = false;
            }
            else
            {


                guna2GroupBox2.Visible = true;
                guna2GroupBox3.Visible = true;
            }
            foreach (DataRow row in dt.Rows)
            {
                guna2TextBox3.Text = (string)row["nome"];
                guna2PictureBox1.Image = byteArrayToImage((Byte[])row["Imagem"]);              

            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (u == 0)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
                guna2Button1.Image = Properties.Resources.show1;
                u += 1;
            }
            else
            {
                guna2TextBox1.UseSystemPasswordChar = true;
                guna2Button1.Image = Properties.Resources.invisible1;
                u = 0;
            }

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }
        string Nome;
        string ativo;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                ativo = guna2DataGridView1.Rows[e.RowIndex].Cells["ativo"].Value.ToString();
                guna2TextBox10.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["n_func"].Value.ToString();
                n_func = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["n_func"].Value);
                guna2PictureBox2.Image = byteArrayToImage((Byte[])guna2DataGridView1.Rows[e.RowIndex].Cells["imagem"].Value);
               Nome= guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                guna2TextBox9.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();
                guna2TextBox4.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["data_nascimento"].Value.ToString();
                guna2TextBox2.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                guna2TextBox5.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["telefone"].Value.ToString();
                guna2TextBox6.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nib"].Value.ToString();
                guna2TextBox7.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["morada"].Value.ToString();
                guna2TextBox8.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                guna2TextBox5.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["nif"].Value.ToString();
                guna2ComboBox8.SelectedItem = guna2DataGridView1.Rows[e.RowIndex].Cells["genero"].Value.ToString();

                if(ativo == "True")
                {
                    guna2ImageButton1.Image = Properties.Resources.flash1;
                    t = 0;
                    Ativo = true;

                }
                else
                {
                    guna2ImageButton1.Image = Properties.Resources.flash_black;
                    t = 1;
                    Ativo = false;
                }
            }
        }

        private void guna2TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text.Length < 3)
            {
                h = 0;
            }
            if (guna2TextBox5.Text.Length == 3 || guna2TextBox5.Text.Length == 7)
            {
                if (h != 1)
                {
                    guna2TextBox5.Text += " ";
                    guna2TextBox5.Select(guna2TextBox5.Text.Length, 0);
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text.Length == 6)
            {

                string mes = guna2TextBox4.Text[3].ToString() + guna2TextBox4.Text[4].ToString();
                if (mes == "01" || mes == "02" || mes == "03" || mes == "04" || mes == "05" || mes == "06" || mes == "07" || mes == "08" || mes == "09" || mes == "10" || mes == "11" || mes == "12")
                {
                    string dia = guna2TextBox4.Text[0].ToString() + guna2TextBox4.Text[1].ToString();
                    if (mes == "01" || mes == "03" || mes == "05" || mes == "07" || mes == "08" || mes == "10" || mes == "12")
                    {
                        if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                        {

                        }
                        else
                        {
                            MessageBox.Show("insira um dia válido");
                            guna2TextBox4.Clear();
                            i = 0;
                        }
                    }
                    if (mes == "04" || mes == "06" || mes == "09" || mes == "11")
                    {

                        if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30")
                        {

                        }
                        else
                        {
                            MessageBox.Show("insira um dia válido");
                            guna2TextBox4.Clear();
                            i = 0;
                        }

                    }
                    if (mes == "02")
                    {
                        if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28")
                        {

                        }
                        else
                        {
                            MessageBox.Show("insira um dia válido");
                            guna2TextBox4.Clear();
                            i = 0;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("insira um mês válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox4.Text.Length == 3)
            {

                string dia = guna2TextBox4.Text[0].ToString() + guna2TextBox4.Text[1].ToString();

                if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                {

                }
                else
                {
                    MessageBox.Show("insira um dia válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox4.Text.Length == 10)
            {
                i = 1;

                DateTime data = DateTime.ParseExact(guna2TextBox4.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                ano = data.Year;
                if (data.Year >= DateTime.Now.Year || data.Year <= 1931)
                {
                    MessageBox.Show("insira um ano válido");
                    guna2TextBox4.Clear();
                    i = 0;
                }



            }

            if (guna2TextBox4.Text.Length < 2)
            {
                i = 0;
            }
            if (guna2TextBox4.Text.Length == 2 || guna2TextBox4.Text.Length == 5)
            {
                if (i != 1)
                {
                    guna2TextBox4.Text += "/";
                    guna2TextBox4.Select(guna2TextBox4.Text.Length, 0);
                }
            }
        }

        private void guna2ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox2.ImageLocation = openFileDialog1.FileName;
            }
        }
        static string Hash(string input)

        {

            using (SHA1Managed sha1 = new SHA1Managed())

            {

                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder(hash.Length * 2);



                foreach (byte b in hash)

                {

                    // can be "x2" if you want lowercase

                    sb.Append(b.ToString("X2"));

                }



                return sb.ToString();

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
        bool Ativo;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if(Form2.flagInsertFunc == true)
            {

                DialogResult dr = MessageBox.Show("Tem a certeza que quer adicionar um novo funcionário ?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int x = BLL.Func.insertFunc(guna2TextBox9.Text, Hash("123"), true, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox5.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.SelectedItem.ToString(), false);
                    guna2DataGridView1.DataSource = BLL.Func.Load();
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar as informções do funcionário " + Nome + "?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int x = BLL.Func.updateFunc(n_func, guna2TextBox9.Text, Ativo, guna2TextBox4.Text, guna2TextBox2.Text, guna2TextBox5.Text, guna2TextBox6.Text, imgToByteArray(guna2PictureBox2.Image), guna2TextBox8.Text, guna2TextBox7.Text, guna2ComboBox8.Text);
                    guna2DataGridView1.DataSource = BLL.Func.Load();
                }

            }


        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar a senha?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int x = BLL.Func.senhaFunc(Hash(guna2TextBox1.Text), Form5.n_func);
                guna2TextBox1.Clear();

            }

           

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.flagInsertFunc = true;
            Form2.flagEditFunc = false;
            guna2Button4.Visible = false;
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.flagInsertFunc = false;
            Form2.flagEditFunc = true;
            guna2Button4.Visible = true;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem a certexa que quer alterar a senha do funcionário " + Nome + "?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                BLL.Func.senhaFunc(Hash(guna2TextBox11.Text), n_func);
                guna2TextBox11.Clear();
                guna2TextBox10.Clear();
                    
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (w == 0)
            {
                guna2TextBox11.UseSystemPasswordChar = false;
                guna2Button5.Image = Properties.Resources.show1;
                w += 1;
            }
            else
            {
                guna2TextBox11.UseSystemPasswordChar = true;
                guna2Button5.Image = Properties.Resources.invisible1;
                w = 0;
            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }
        int t = 0;
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (t == 0)
            {               
                guna2ImageButton1.Image = Properties.Resources.flash_black;
                t += 1;
                Ativo = false;
            }
            else
            {
              
                guna2ImageButton1.Image = Properties.Resources.flash1;
                t = 0;
                Ativo = true;
            }
        }
    }
}
