namespace StandUp.Presentation.WinForms;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtEmployeeNumber;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label lblStatus;
    private Button btnClients;
    private Button btnVehicles;
    private Button btnAppointments;
    private Button btnSales;
    private Button btnImages;
    private Button btnDashboard;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtEmployeeNumber = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lblStatus = new Label();
        btnClients = new Button();
        btnVehicles = new Button();
        btnAppointments = new Button();
        btnSales = new Button();
        btnImages = new Button();
        btnDashboard = new Button();

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 380);
        Name = "Form1";
        Text = "StandUp Login (.NET 10)";

        txtEmployeeNumber.Location = new Point(40, 30);
        txtEmployeeNumber.PlaceholderText = "Numero de funcionario";
        txtEmployeeNumber.Size = new Size(320, 23);

        txtPassword.Location = new Point(40, 70);
        txtPassword.PlaceholderText = "Password";
        txtPassword.Size = new Size(320, 23);
        txtPassword.UseSystemPasswordChar = true;

        btnLogin.Location = new Point(40, 110);
        btnLogin.Size = new Size(320, 30);
        btnLogin.Text = "Entrar";
        btnLogin.Click += btnLogin_Click;

        lblStatus.Location = new Point(40, 145);
        lblStatus.Size = new Size(320, 40);

        btnClients.Location = new Point(40, 185); btnClients.Size = new Size(320, 23); btnClients.Text = "Abrir Gestao de Clientes"; btnClients.Enabled = false; btnClients.Click += btnClients_Click;
        btnVehicles.Location = new Point(40, 210); btnVehicles.Size = new Size(320, 23); btnVehicles.Text = "Abrir Gestao de Veiculos"; btnVehicles.Enabled = false; btnVehicles.Click += btnVehicles_Click;
        btnAppointments.Location = new Point(40, 235); btnAppointments.Size = new Size(320, 23); btnAppointments.Text = "Abrir Gestao de Marcacoes"; btnAppointments.Enabled = false; btnAppointments.Click += btnAppointments_Click;
        btnSales.Location = new Point(40, 260); btnSales.Size = new Size(320, 23); btnSales.Text = "Abrir Gestao de Vendas"; btnSales.Enabled = false; btnSales.Click += btnSales_Click;
        btnImages.Location = new Point(40, 285); btnImages.Size = new Size(320, 23); btnImages.Text = "Abrir Gestao de Imagens"; btnImages.Enabled = false; btnImages.Click += btnImages_Click;
        btnDashboard.Location = new Point(40, 310); btnDashboard.Size = new Size(320, 23); btnDashboard.Text = "Abrir Dashboard"; btnDashboard.Enabled = false; btnDashboard.Click += btnDashboard_Click;

        Controls.AddRange([txtEmployeeNumber, txtPassword, btnLogin, lblStatus, btnClients, btnVehicles, btnAppointments, btnSales, btnImages, btnDashboard]);
    }
}
