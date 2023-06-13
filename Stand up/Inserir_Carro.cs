
using BusinessLogicLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BusinessLogicLayer;
using System.IO;
using System.Drawing;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Stand_up
{


    public partial class Inserir_Carro : Form
    {

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

        public Inserir_Carro()
        {
            InitializeComponent();
        }
        int i = 0;
        int j = 0;
        int ano;
        int id_marca;
        int inicio;
        bool editar = false;
        bool matricula_clear = false;
        bool matricula_editada = false;

        ArrayList intArray = new ArrayList();

        int id_carro;
        int index;
        ImageList images = new ImageList();
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form2.flagEditCAR == true && Form2.flagInsertCAR == false)
            {




                if (listView1.SelectedItems.Count > 0)
                {
                    string Matricula = listView1.SelectedItems[0].Text;


                    ativar_caixas();

                    DataTable info = BLL.veiculos.Load_dados(Matricula);

                    foreach (DataRow row in info.Rows)
                    {
                        guna2TextBox3.Text = (string)row["Data"];
                        guna2ComboBox1.SelectedItem = (string)row["Marca"];
                        guna2ComboBox2.SelectedItem = (string)row["Modelo"];
                        guna2TextBox6.Text = (string)row["Matricula"];
                        guna2TextBox5.Text = Convert.ToString((int)row["Quilometros"]);
                        guna2ComboBox3.SelectedItem = (string)row["Combustivel"];
                        guna2TextBox7.Text = (string)row["Descricao"];
                        guna2TextBox1.Text = Convert.ToString((int)row["Valor"]);
                        guna2CirclePictureBox1.Image = byteArrayToImage((Byte[])row["Imagem"]);
                        guna2ComboBox4.SelectedItem = (string)row["Cor"];
                        guna2ComboBox5.SelectedItem = (string)row["Tipo_de_Caixa"];
                        guna2ComboBox6.SelectedItem = Convert.ToString((int)row["N_Portas"]);
                        guna2ComboBox8.SelectedItem = (string)row["Traccao"];
                    }

                }

            }
        }




        void carregar_car_PARA_LISTVIEW()
        {





            DataTable dr = BLL.veiculos.queryLoad_veiculo(false);
            images.Images.Clear();
            listView1.Clear();
            int k = 0;





            foreach (DataRow row in dr.Rows)

            {



                images.ColorDepth = ColorDepth.Depth32Bit;

                listView1.LargeImageList = images;

                listView1.LargeImageList.ImageSize = new System.Drawing.Size(100, 100);



                byte[] imagebyte = (byte[])(row[9]);

                MemoryStream image_stream = new MemoryStream(imagebyte);

                image_stream.Write(imagebyte, 0, imagebyte.Length);

                images.Images.Add(row[9].ToString(), new Bitmap(image_stream));



                image_stream.Close();



                ListViewItem item = new ListViewItem();

                item.ImageIndex = k;

                item.Text = row["Matricula"].ToString();

                k += 1;

                this.listView1.Items.Add(item);











            }





        }
        void limpar_caixas()
        {
            guna2TextBox1.Clear();
            guna2TextBox7.Clear();
            guna2ComboBox3.SelectedIndex = -1;
            guna2TextBox5.Clear();
            guna2TextBox6.Clear();
            guna2ComboBox2.DataSource = null;
            guna2TextBox3.Clear();
            guna2ComboBox1.SelectedIndex = -1;
            guna2CirclePictureBox1.Image = Properties.Resources.car;
            guna2ComboBox2.Enabled = false;
            guna2TextBox6.Enabled = false;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;
            guna2ComboBox8.SelectedIndex = -1;

        }

        void desativar_caixas()
        {

            guna2TextBox1.Enabled = false;
            guna2TextBox7.Enabled = false;
            guna2ComboBox3.Enabled = false;
            guna2TextBox5.Enabled = false;
            guna2TextBox6.Enabled = false;
            guna2TextBox3.Enabled = false;
            guna2ComboBox1.Enabled = false;
            guna2CirclePictureBox1.Enabled = false;
            guna2ComboBox2.Enabled = false;
            guna2ComboBox4.Enabled = false;
            guna2ComboBox5.Enabled = false;
            guna2ComboBox8.Enabled = false;
            guna2ComboBox6.Enabled = false;

        }
        void ativar_caixas()
        {
            guna2TextBox1.Enabled = true;
            guna2TextBox7.Enabled = true;
            guna2ComboBox3.Enabled = true;
            guna2TextBox5.Enabled = true;
            guna2TextBox3.Enabled = true;
            guna2ComboBox1.Enabled = true;
            guna2CirclePictureBox1.Enabled = true;
            guna2ComboBox4.Enabled = true;
            guna2ComboBox5.Enabled = true;
            guna2ComboBox6.Enabled = true;
            guna2ComboBox8.Enabled = true;
            guna2TextBox6.Enabled = true;
            guna2Button1.Enabled = true;


        }
        private void guna2Button32_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {

                if (Form2.flagEditCAR == true)
                {



                    string Matricula = listView1.SelectedItems[0].Text;
                    DataTable info = BLL.veiculos.Load_dados(Matricula);
                    for (int l = 0; l < info.Columns.Count - 1; l++)
                    {
                        switch (l)
                        {
                            case 0:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2TextBox3.Text != (string)row["Data"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }
                                }

                                break;
                            case 1:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox1.SelectedItem != (string)row["Marca"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }



                                }
                                break;
                            case 2:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox2.SelectedItem != (string)row["Modelo"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }



                                }

                                break;
                            case 3:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2TextBox6.Text != (string)row["Matricula"])
                                    {
                                        editar = true;
                                        matricula_editada = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                        matricula_editada = false;
                                    }


                                }
                                break;
                            case 4:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2TextBox5.Text != Convert.ToString((int)row["Quilometros"]))
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }




                                }
                                break;
                            case 5:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox3.SelectedItem != (string)row["Combustivel"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }





                                }
                                break;
                            case 6:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2TextBox7.Text != (string)row["Descricao"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }





                                }
                                break;
                            case 7:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2TextBox1.Text != Convert.ToString((int)row["Valor"]))
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }





                                }
                                break;
                            case 8:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2CirclePictureBox1.Image != byteArrayToImage((Byte[])row["Imagem"]))
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }






                                }
                                break;
                            case 9:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox4.SelectedItem != (string)row["Cor"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }






                                }
                                break;
                            case 10:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox5.SelectedItem != (string)row["Tipo_de_Caixa"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }








                                }
                                break;
                            case 11:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox6.SelectedItem != Convert.ToString((int)row["N_Portas"]))
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }









                                }
                                break;
                            case 12:
                                foreach (DataRow row in info.Rows)
                                {
                                    if (guna2ComboBox8.SelectedItem != (string)row["Traccao"])
                                    {
                                        editar = true;
                                    }
                                    else
                                    {
                                        editar = false;
                                    }









                                }
                                break;
                        }

                    }

                    if (guna2TextBox3.Text.Length != 10)
                    {
                        MessageBox.Show("Insira uma data válida !");
                        guna2TextBox3.Clear();
                    }
                    else
                    {
                        if (guna2ComboBox1.SelectedIndex == -1)
                        {
                            MessageBox.Show("Selecione uma marca !");
                        }
                        else
                        {
                            if (guna2ComboBox2.SelectedIndex == -1)
                            {
                                MessageBox.Show("Selecione um modelo !");
                            }
                            else
                            {
                                if (guna2TextBox6.Text.Length != 8)
                                {
                                    MessageBox.Show("Insira uma matricula válida !");
                                    guna2TextBox6.Clear();
                                }
                                else
                                {
                                    DataTable verificar_matricula = BLL.veiculos.Load_dados1(guna2TextBox6.Text);
                                    if (verificar_matricula.Rows.Count > 1 && matricula_editada != true || verificar_matricula.Rows.Count > 0 && matricula_editada == true)
                                    {
                                        MessageBox.Show("Esta matricula já existe");
                                        guna2TextBox6.Clear();
                                    }
                                    else
                                    {


                                        if (guna2TextBox5.Text == "")
                                        {
                                            MessageBox.Show("Insira uma kilometragem válida !");
                                        }
                                        else
                                        {
                                            if (guna2ComboBox3.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Selecione um tipo de combustivel !");
                                            }
                                            else
                                            {
                                                if (guna2ComboBox4.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Selecione uma cor !");
                                                }
                                                else
                                                {
                                                    if (guna2ComboBox5.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Selecione um tipo de caixa !");
                                                    }
                                                    else
                                                    {
                                                        if (guna2ComboBox6.SelectedIndex == -1)
                                                        {
                                                            MessageBox.Show("Selecione o nº de Portas !");
                                                        }
                                                        else
                                                        {
                                                            if (guna2ComboBox8.SelectedIndex == -1)
                                                            {
                                                                MessageBox.Show("Selecione o tipo de tracção !");
                                                            }
                                                            else
                                                            {
                                                                if (guna2TextBox1.Text == "")
                                                                {
                                                                    MessageBox.Show("Insira o valor do veiculo !");
                                                                }
                                                                else
                                                                {
                                                                    if (guna2CirclePictureBox1.Image == Properties.Resources.car)
                                                                    {
                                                                        MessageBox.Show("Insira uma imagem do veiculo !");
                                                                    }
                                                                    else
                                                                    {


                                                                        if (listView1.SelectedIndices.Count > 0)
                                                                        {
                                                                            index = listView1.SelectedIndices[0];
                                                                        }
                                                                        DateTime data = DateTime.ParseExact(guna2TextBox3.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                                                        string data2 = data.ToString("dd/MM/yyyy");
                                                                        DialogResult dr = MessageBox.Show("Pertende guardar as alterações do veiculo?", "", MessageBoxButtons.YesNo);
                                                                        if (dr == DialogResult.Yes)
                                                                        {
                                                                            int x = BLL.veiculos.updateVeiculo(guna2TextBox6.Text, Convert.ToInt32(guna2TextBox5.Text), data2, guna2ComboBox1.Text, guna2ComboBox2.Text, guna2TextBox7.Text, guna2ComboBox3.Text, imgToByteArray(guna2CirclePictureBox1.Image), Convert.ToInt32(guna2TextBox1.Text), guna2ComboBox4.Text, guna2ComboBox5.Text, Convert.ToInt32(guna2ComboBox6.Text), guna2ComboBox8.Text, listView1.SelectedItems[0].Text);
                                                                            carregar_car_PARA_LISTVIEW();
                                                                            limpar_caixas();
                                                                        }



                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
                else
                {


                    if (guna2TextBox3.Text.Length != 10)
                    {
                        MessageBox.Show("Insira uma data válida !");
                        guna2TextBox3.Clear();
                    }
                    else
                    {
                        if (guna2ComboBox1.SelectedIndex == -1)
                        {
                            MessageBox.Show("Selecione uma marca !");
                        }
                        else
                        {
                            if (guna2ComboBox2.SelectedIndex == -1)
                            {
                                MessageBox.Show("Selecione um modelo !");
                            }
                            else
                            {
                                if (guna2TextBox6.Text.Length != 8)
                                {
                                    MessageBox.Show("Insira uma matricula válida !");
                                }
                                else
                                {
                                    DataTable verificar_matricula = BLL.veiculos.Load_dados1(guna2TextBox6.Text);
                                    if (verificar_matricula.Rows.Count > 0)
                                    {
                                        MessageBox.Show("Esta matricula já existe");
                                    }
                                    else
                                    {


                                        if (guna2TextBox5.Text == "")
                                        {
                                            MessageBox.Show("Insira uma kilometragem válida !");
                                        }
                                        else
                                        {
                                            if (guna2ComboBox3.SelectedIndex == -1)
                                            {
                                                MessageBox.Show("Selecione um tipo de combustivel !");
                                            }
                                            else
                                            {
                                                if (guna2ComboBox4.SelectedIndex == -1)
                                                {
                                                    MessageBox.Show("Selecione uma cor !");
                                                }
                                                else
                                                {
                                                    if (guna2ComboBox5.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("Selecione um tipo de caixa !");
                                                    }
                                                    else
                                                    {
                                                        if (guna2ComboBox6.SelectedIndex == -1)
                                                        {
                                                            MessageBox.Show("Selecione o nº de Portas !");
                                                        }
                                                        else
                                                        {
                                                            if (guna2ComboBox8.SelectedIndex == -1)
                                                            {
                                                                MessageBox.Show("Selecione o tipo de tracção !");
                                                            }
                                                            else
                                                            {
                                                                if (guna2TextBox1.Text == "")
                                                                {
                                                                    MessageBox.Show("Insira o valor do veiculo !");
                                                                }
                                                                else
                                                                {
                                                                    if (guna2CirclePictureBox1.Image == Properties.Resources.car)
                                                                    {
                                                                        MessageBox.Show("Insira uma imagem do veiculo !");
                                                                    }
                                                                    else
                                                                    {

                                                                        bool mota = false;
                                                                        DateTime data = DateTime.ParseExact(guna2TextBox3.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                                                        string data2 = data.ToString("dd/MM/yyyy");
                                                                        //data = Convert.ToDateTime(data2);
                                                                        if(guna2CheckBox2.Checked == true)
                                                                        {
                                                                            mota = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            mota = true;
                                                                        }

                                                                        DialogResult dr = MessageBox.Show("Pertende inserir este veiculo?", "", MessageBoxButtons.YesNo);
                                                                        if (dr == DialogResult.Yes)
                                                                        {
                                                                            int x = BLL.veiculos.insertVeiculo(guna2TextBox6.Text, Convert.ToInt32(guna2TextBox5.Text), data2, guna2ComboBox1.Text, guna2ComboBox2.Text, guna2TextBox7.Text, guna2ComboBox3.Text, imgToByteArray(guna2CirclePictureBox1.Image), Convert.ToInt32(guna2TextBox1.Text), guna2ComboBox4.Text, guna2ComboBox5.Text, Convert.ToInt32(guna2ComboBox6.Text), guna2ComboBox8.Text, false,mota);
                                                                            images.Images.Add(guna2CirclePictureBox1.Image);

                                                                            limpar_caixas();
                                                                            carregar_car_PARA_LISTVIEW();
                                                                        }



                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }


                }
            }
            else
            {
                MessageBox.Show("Selecione um veiculo");
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text.Length == 6)
            {

                string mes = guna2TextBox3.Text[3].ToString() + guna2TextBox3.Text[4].ToString();
                if (mes == "01" || mes == "02" || mes == "03" || mes == "04" || mes == "05" || mes == "06" || mes == "07" || mes == "08" || mes == "09" || mes == "10" || mes == "11" || mes == "12")
                {
                    string dia = guna2TextBox3.Text[0].ToString() + guna2TextBox3.Text[1].ToString();
                    if (mes == "01" || mes == "03" || mes == "05" || mes == "07" || mes == "08" || mes == "10" || mes == "12")
                    {
                        if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                        {

                        }
                        else
                        {
                            MessageBox.Show("insira um dia válido");
                            guna2TextBox3.Clear();
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
                            guna2TextBox3.Clear();
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
                            guna2TextBox3.Clear();
                            i = 0;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("insira um mês válido");
                    guna2TextBox3.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox3.Text.Length == 3)
            {

                string dia = guna2TextBox3.Text[0].ToString() + guna2TextBox3.Text[1].ToString();

                if (dia == "01" || dia == "02" || dia == "03" || dia == "04" || dia == "05" || dia == "06" || dia == "07" || dia == "08" || dia == "09" || dia == "10" || dia == "11" || dia == "12" || dia == "13" || dia == "14" || dia == "15" || dia == "16" || dia == "17" || dia == "18" || dia == "19" || dia == "20" || dia == "21" || dia == "22" || dia == "23" || dia == "24" || dia == "25" || dia == "26" || dia == "27" || dia == "28" || dia == "29" || dia == "30" || dia == "31")
                {

                }
                else
                {
                    MessageBox.Show("insira um dia válido");
                    guna2TextBox3.Clear();
                    i = 0;
                }

            }
            if (guna2TextBox3.Text.Length == 10)
            {
                i = 1;

                DateTime data = DateTime.ParseExact(guna2TextBox3.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                ano = data.Year;
                if (data.Year > DateTime.Now.Year || data.Year <= 1931)
                {
                    MessageBox.Show("insira um ano válido");
                    guna2TextBox3.Clear();
                    i = 0;
                }



            }

            if (guna2TextBox3.Text.Length < 2)
            {
                i = 0;
            }
            if (guna2TextBox3.Text.Length == 2 || guna2TextBox3.Text.Length == 5)
            {
                if (i != 1)
                {
                    guna2TextBox3.Text += "/";
                    guna2TextBox3.Select(guna2TextBox3.Text.Length, 0);
                }
            }


            if (guna2TextBox3.Text.Length != 10)
            {
                guna2TextBox6.Enabled = false;
            }
            else
            {
                guna2TextBox6.Enabled = true;
            }


        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

            if (matricula_clear == false)
            {
                if (guna2TextBox3.Text.Length == 10)
                {


                    if (guna2TextBox6.Text.Length == 8)
                    {
                        j = 1;
                        DateTime data = DateTime.ParseExact(guna2TextBox3.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        if (data.Year >= 1932 && data.Year <= 1992)
                        {
                            if (guna2TextBox6.Text != "")
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    if (guna2TextBox6.Text[l] == '0' || guna2TextBox6.Text[l] == '1' || guna2TextBox6.Text[l] == '2' || guna2TextBox6.Text[l] == '3' || guna2TextBox6.Text[l] == '4' || guna2TextBox6.Text[l] == '5' || guna2TextBox6.Text[l] == '6' || guna2TextBox6.Text[l] == '7' || guna2TextBox6.Text[l] == '8' || guna2TextBox6.Text[l] == '9')
                                    {
                                        MessageBox.Show("Tem de usar o formato AA-00-00, devido à idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;

                                    }
                                    else
                                    {

                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {

                                for (int o = 3; o < 5; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {

                                    }
                                    else
                                    {

                                        MessageBox.Show("Tem de usar o formato AA-00-00, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {
                                for (int o = 7; o < 8; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {

                                    }
                                    else
                                    {

                                        MessageBox.Show("Tem de usar o formato AA-00-00, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }

                                }
                            }
                        }
                        if (data.Year >= 1993 && data.Year <= 2005)
                        {
                            if (guna2TextBox6.Text != "")
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    if (guna2TextBox6.Text[l] == '0' || guna2TextBox6.Text[l] == '1' || guna2TextBox6.Text[l] == '2' || guna2TextBox6.Text[l] == '3' || guna2TextBox6.Text[l] == '4' || guna2TextBox6.Text[l] == '5' || guna2TextBox6.Text[l] == '6' || guna2TextBox6.Text[l] == '7' || guna2TextBox6.Text[l] == '8' || guna2TextBox6.Text[l] == '9')
                                    {


                                    }
                                    else
                                    {
                                        MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {

                                for (int o = 3; o < 5; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {

                                    }
                                    else
                                    {

                                        MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {
                                for (int o = 7; o < 8; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {
                                        MessageBox.Show("Tem de usar o formato 00-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }
                                    else
                                    {


                                    }

                                }
                            }

                        }

                        if (data.Year >= 2006 && data.Year <= 2020)
                        {
                            if (guna2TextBox6.Text != "")
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    if (guna2TextBox6.Text[l] == '0' || guna2TextBox6.Text[l] == '1' || guna2TextBox6.Text[l] == '2' || guna2TextBox6.Text[l] == '3' || guna2TextBox6.Text[l] == '4' || guna2TextBox6.Text[l] == '5' || guna2TextBox6.Text[l] == '6' || guna2TextBox6.Text[l] == '7' || guna2TextBox6.Text[l] == '8' || guna2TextBox6.Text[l] == '9')
                                    {


                                    }
                                    else
                                    {
                                        MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {

                                for (int o = 3; o < 5; o++)
                                {
                                    if (guna2TextBox6.Text[
                                        o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {
                                        MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }
                                    else
                                    {


                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {
                                for (int o = 6; o < 8; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {

                                    }
                                    else
                                    {
                                        MessageBox.Show("Tem de usar o formato 00-AA-00, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;

                                    }

                                }
                            }

                        }
                        if (data.Year >= 2021)
                        {
                            if (guna2TextBox6.Text != "")
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    if (guna2TextBox6.Text[l] == '0' || guna2TextBox6.Text[l] == '1' || guna2TextBox6.Text[l] == '2' || guna2TextBox6.Text[l] == '3' || guna2TextBox6.Text[l] == '4' || guna2TextBox6.Text[l] == '5' || guna2TextBox6.Text[l] == '6' || guna2TextBox6.Text[l] == '7' || guna2TextBox6.Text[l] == '8' || guna2TextBox6.Text[l] == '9')
                                    {
                                        MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;

                                    }
                                    else
                                    {

                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {

                                for (int o = 3; o < 5; o++)
                                {
                                    if (guna2TextBox6.Text[
                                        o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {

                                    }
                                    else
                                    {
                                        MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;

                                    }

                                }
                            }
                            if (guna2TextBox6.Text != "")
                            {
                                for (int o = 7; o < 8; o++)
                                {
                                    if (guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '0' || guna2TextBox6.Text[o] == '1' || guna2TextBox6.Text[o] == '2' || guna2TextBox6.Text[o] == '3' || guna2TextBox6.Text[o] == '4' || guna2TextBox6.Text[o] == '5' || guna2TextBox6.Text[o] == '6' || guna2TextBox6.Text[o] == '7' || guna2TextBox6.Text[o] == '8' || guna2TextBox6.Text[o] == '9')
                                    {
                                        MessageBox.Show("Tem de usar o formato AA-00-AA, devido á idade do seu carro ");
                                        guna2TextBox6.Clear();
                                        break;
                                    }
                                    else
                                    {


                                    }

                                }
                            }

                        }







                    }

                    if (guna2TextBox6.Text.Length < 2 || guna2TextBox6.Text.Length > 3 && guna2TextBox6.Text.Length < 5 || guna2TextBox6.Text.Length > 6 && guna2TextBox6.Text.Length < 8)
                    {
                        j = 0;
                    }
                    if (guna2TextBox6.Text.Length == 2 || guna2TextBox6.Text.Length == 5)
                    {
                        if (j != 1)
                        {
                            guna2TextBox6.Text += "-";
                            guna2TextBox6.Select(guna2TextBox6.Text.Length, 0);
                        }

                    }
                    if (guna2TextBox6.Text.Length == 0)
                    {
                        j = 0;
                    }

                }
                else
                {

                    guna2TextBox6.Clear();
                    guna2TextBox3.Clear();
                    MessageBox.Show("Data mal preenchida");
                }
                if (guna2TextBox6.Text.Length == 8)
                {
                    guna2TextBox5.Enabled = true;
                    guna2TextBox6.Text = guna2TextBox6.Text.ToUpper();
                }
                else
                {
                    guna2TextBox5.Enabled = false;
                }
            }


        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            matricula_clear = true;
            j = 0;
            guna2TextBox6.Text = "";
            matricula_clear = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Clear();
            i = 0;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        void carregar_marca()
        {
            DataTable dt = BLL.veiculos.queryMarca_veiculo();
            int j = 0;

            foreach (DataRow row in dt.Rows)
            {

                guna2ComboBox1.Items.Add(row[0].ToString());
            }
        }
        private void Inserir_Carro_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            if (Form1.flagEditCAR == true)
            {
                desativar_caixas();
                guna2Button32.Text = "Guardar";
                guna2Button33.Visible = true;
            }
            else
            {
                guna2Button33.Visible = false;
                guna2Button32.Text = "Adicionar";
            }
            guna2CheckBox2.Checked = true;

            carregar_car_PARA_LISTVIEW();
            carregar_marca();




        }

        private void guna2ComboBox2_Load(object sender, EventArgs e)
        {




        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "PNG files (*.png)|*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text.Length == 10)
            {
                guna2ComboBox2.Items.Clear();
                int id_marca = (int)BLL.veiculos.queryBuscar_id_marca(guna2ComboBox1.Text);
                DataTable modelos = BLL.veiculos.queryModelos_veiculo(id_marca);
                DataTable table = BLL.veiculos.queryModelos_veiculo1234(id_marca, ano);

                foreach (DataRow row in table.Rows)
                {
                    guna2ComboBox2.Items.Add(row["Modelo"]);
                }
                guna2ComboBox2.Enabled = true;
            }
            else
            {


                if (guna2ComboBox1.SelectedIndex == -1)
                {

                }
                else
                {
                    MessageBox.Show("preencha a data antes de selecionar a Marca");
                    guna2ComboBox1.SelectedIndex = -1;
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text != "")
            {



                for (int j = 0; j < guna2TextBox5.Text.Length; j++)
                {

                    if (guna2TextBox5.Text[j] == '0' || guna2TextBox5.Text[j] == '1' || guna2TextBox5.Text[j] == '2' || guna2TextBox5.Text[j] == '3' || guna2TextBox5.Text[j] == '4' || guna2TextBox5.Text[j] == '5' || guna2TextBox5.Text[j] == '6' || guna2TextBox5.Text[j] == '7' || guna2TextBox5.Text[j] == '8' || guna2TextBox5.Text[j] == '9')
                    {

                    }
                    else
                    {

                        guna2TextBox5.Clear();
                        MessageBox.Show("Insira uma kilometragem válida");
                    }

                }




            }

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {



                for (int j = 0; j < guna2TextBox1.Text.Length; j++)
                {

                    if (guna2TextBox1.Text[j] == '0' || guna2TextBox1.Text[j] == '1' || guna2TextBox1.Text[j] == '2' || guna2TextBox1.Text[j] == '3' || guna2TextBox1.Text[j] == '4' || guna2TextBox1.Text[j] == '5' || guna2TextBox1.Text[j] == '6' || guna2TextBox1.Text[j] == '7' || guna2TextBox1.Text[j] == '8' || guna2TextBox1.Text[j] == '9')
                    {

                    }
                    else
                    {

                        guna2TextBox1.Clear();
                        MessageBox.Show("Insira um valor válido ");
                    }

                }


            }
            else
            {

            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void inserirVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1.flagEditCAR = false;
            Form1.flagInsertCAR = true;
            Form2.flagEditCAR = false;
            Form2.flagInsertCAR = true;
        }

        private void editarVeiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1.flagEditCAR = true;
            Form1.flagInsertCAR = false;
            Form2.flagEditCAR = true;
            Form2.flagInsertCAR = false;
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                if (Form2.flagEditCAR == true)
                {
                    string Matricula = listView1.SelectedItems[0].Text;
                    DataTable info = BLL.veiculos.Load_dados(Matricula);
                    DialogResult dr = MessageBox.Show("Pertende remover o veiculo com a matricula ("+Matricula+")?", "", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        BLL.veiculos.deleteveiculo(Matricula);
                        limpar_caixas();
                        carregar_car_PARA_LISTVIEW();
                    }

                }
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked == true)
            {
                guna2CheckBox1.Checked = false;
                label11.Visible = true;
                guna2ComboBox6.Visible = true;
            }
            else
            {
                guna2CheckBox1.Checked = true;
                label11.Visible = false;
                guna2ComboBox6.Visible = false;
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2CheckBox1.Checked == true)
            {
                guna2CheckBox2.Checked = false;
                label11.Visible = false;
                guna2ComboBox6.Visible = false;
            }
            else
            {
                guna2CheckBox2.Checked = true;
                label11.Visible = true;
                guna2ComboBox6.Visible = true;
            }
        }
    }
}

