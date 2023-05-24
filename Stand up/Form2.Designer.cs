
namespace Stand_up
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inserirCarroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirVeiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarVeiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especificaçõesDoVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserirEspecificaçõesDoVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediitarEspecificaçõesDoVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirCarroToolStripMenuItem,
            this.especificaçõesDoVeículoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1683, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // inserirCarroToolStripMenuItem
            // 
            this.inserirCarroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirVeiculoToolStripMenuItem,
            this.editarVeiculoToolStripMenuItem});
            this.inserirCarroToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.inserirCarroToolStripMenuItem.Name = "inserirCarroToolStripMenuItem";
            this.inserirCarroToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.inserirCarroToolStripMenuItem.Text = "Frota";
            this.inserirCarroToolStripMenuItem.Click += new System.EventHandler(this.inserirCarroToolStripMenuItem_Click);
            // 
            // inserirVeiculoToolStripMenuItem
            // 
            this.inserirVeiculoToolStripMenuItem.Name = "inserirVeiculoToolStripMenuItem";
            this.inserirVeiculoToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.inserirVeiculoToolStripMenuItem.Text = "Inserir Veiculo";
            this.inserirVeiculoToolStripMenuItem.Click += new System.EventHandler(this.inserirVeiculoToolStripMenuItem_Click);
            // 
            // editarVeiculoToolStripMenuItem
            // 
            this.editarVeiculoToolStripMenuItem.Name = "editarVeiculoToolStripMenuItem";
            this.editarVeiculoToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.editarVeiculoToolStripMenuItem.Text = "Editar Veiculo";
            this.editarVeiculoToolStripMenuItem.Click += new System.EventHandler(this.editarVeiculoToolStripMenuItem_Click);
            // 
            // especificaçõesDoVeículoToolStripMenuItem
            // 
            this.especificaçõesDoVeículoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirEspecificaçõesDoVeículoToolStripMenuItem,
            this.ediitarEspecificaçõesDoVeículoToolStripMenuItem});
            this.especificaçõesDoVeículoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.especificaçõesDoVeículoToolStripMenuItem.Name = "especificaçõesDoVeículoToolStripMenuItem";
            this.especificaçõesDoVeículoToolStripMenuItem.Size = new System.Drawing.Size(172, 23);
            this.especificaçõesDoVeículoToolStripMenuItem.Text = "Especificações do Veículo";
            this.especificaçõesDoVeículoToolStripMenuItem.Click += new System.EventHandler(this.especificaçõesDoVeículoToolStripMenuItem_Click);
            // 
            // inserirEspecificaçõesDoVeículoToolStripMenuItem
            // 
            this.inserirEspecificaçõesDoVeículoToolStripMenuItem.Name = "inserirEspecificaçõesDoVeículoToolStripMenuItem";
            this.inserirEspecificaçõesDoVeículoToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.inserirEspecificaçõesDoVeículoToolStripMenuItem.Text = "Inserir Especificações do Veículo";
            // 
            // ediitarEspecificaçõesDoVeículoToolStripMenuItem
            // 
            this.ediitarEspecificaçõesDoVeículoToolStripMenuItem.Name = "ediitarEspecificaçõesDoVeículoToolStripMenuItem";
            this.ediitarEspecificaçõesDoVeículoToolStripMenuItem.Size = new System.Drawing.Size(271, 24);
            this.ediitarEspecificaçõesDoVeículoToolStripMenuItem.Text = "Editar Especificações do Veículo";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1659, 883);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1683, 925);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inserirCarroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirVeiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarVeiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especificaçõesDoVeículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserirEspecificaçõesDoVeículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediitarEspecificaçõesDoVeículoToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
    }
}