using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stand_up
{
    public partial class Form9 : Form                                                                                                                                                                    
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = BLL.transacoes.loadTrans();
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            Form1.flagCancTransacao = true;
        }
    }
}
