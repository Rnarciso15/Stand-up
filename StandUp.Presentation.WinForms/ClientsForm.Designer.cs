namespace StandUp.Presentation.WinForms;

partial class ClientsForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView gridClients;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnRefresh;
    private TextBox txtName;
    private TextBox txtEmail;
    private TextBox txtPhone;
    private TextBox txtNif;
    private TextBox txtAddress;
    private Button btnCreate;
    private TextBox txtClientId;
    private CheckBox chkIsActive;
    private Button btnToggleActive;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gridClients = new DataGridView();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnRefresh = new Button();
        txtName = new TextBox();
        txtEmail = new TextBox();
        txtPhone = new TextBox();
        txtNif = new TextBox();
        txtAddress = new TextBox();
        btnCreate = new Button();
        txtClientId = new TextBox();
        chkIsActive = new CheckBox();
        btnToggleActive = new Button();
        ((System.ComponentModel.ISupportInitialize)gridClients).BeginInit();
        SuspendLayout();
        gridClients.Location = new Point(12, 54);
        gridClients.Size = new Size(760, 250);
        txtSearch.Location = new Point(12, 16);
        txtSearch.Size = new Size(180, 23);
        btnSearch.Location = new Point(198, 15);
        btnSearch.Size = new Size(75, 23);
        btnSearch.Text = "Pesquisar";
        btnSearch.Click += btnSearch_Click;
        btnRefresh.Location = new Point(279, 15);
        btnRefresh.Size = new Size(75, 23);
        btnRefresh.Text = "Atualizar";
        btnRefresh.Click += btnRefresh_Click;
        txtName.Location = new Point(12, 322);
        txtName.PlaceholderText = "Nome";
        txtName.Size = new Size(140, 23);
        txtEmail.Location = new Point(158, 322);
        txtEmail.PlaceholderText = "Email";
        txtEmail.Size = new Size(140, 23);
        txtPhone.Location = new Point(304, 322);
        txtPhone.PlaceholderText = "Telefone";
        txtPhone.Size = new Size(110, 23);
        txtNif.Location = new Point(420, 322);
        txtNif.PlaceholderText = "NIF";
        txtNif.Size = new Size(110, 23);
        txtAddress.Location = new Point(536, 322);
        txtAddress.PlaceholderText = "Morada";
        txtAddress.Size = new Size(140, 23);
        btnCreate.Location = new Point(682, 322);
        btnCreate.Size = new Size(90, 23);
        btnCreate.Text = "Criar";
        btnCreate.Click += btnCreate_Click;
        txtClientId.Location = new Point(12, 361);
        txtClientId.PlaceholderText = "ID Cliente";
        txtClientId.Size = new Size(100, 23);
        chkIsActive.Location = new Point(118, 361);
        chkIsActive.Text = "Ativo";
        chkIsActive.Size = new Size(60, 23);
        btnToggleActive.Location = new Point(184, 361);
        btnToggleActive.Size = new Size(120, 23);
        btnToggleActive.Text = "Atualizar Ativo";
        btnToggleActive.Click += btnToggleActive_Click;
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 401);
        Controls.Add(btnToggleActive);
        Controls.Add(chkIsActive);
        Controls.Add(txtClientId);
        Controls.Add(btnCreate);
        Controls.Add(txtAddress);
        Controls.Add(txtNif);
        Controls.Add(txtPhone);
        Controls.Add(txtEmail);
        Controls.Add(txtName);
        Controls.Add(btnRefresh);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(gridClients);
        Text = "Gestão de Clientes";
        Load += ClientsForm_Load;
        ((System.ComponentModel.ISupportInitialize)gridClients).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
