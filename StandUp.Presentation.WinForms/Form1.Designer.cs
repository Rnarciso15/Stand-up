namespace StandUp.Presentation.WinForms;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Label lblAppTitle;
    private Label lblSubtitle;
    private Panel pnlLogin;
    private TextBox txtEmployeeNumber;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label lblStatus;
    private Panel pnlDivider;
    private Label lblModulesTitle;
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
        lblAppTitle = new Label();
        lblSubtitle = new Label();
        pnlLogin = new Panel();
        txtEmployeeNumber = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lblStatus = new Label();
        pnlDivider = new Panel();
        lblModulesTitle = new Label();
        btnClients = new Button();
        btnVehicles = new Button();
        btnAppointments = new Button();
        btnSales = new Button();
        btnImages = new Button();
        btnDashboard = new Button();

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 520);
        Name = "Form1";
        Text = "Stand Up — Gestão de Stand";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // Título principal
        lblAppTitle.Text = "STAND UP";
        lblAppTitle.Font = new Font("Segoe UI", 28f, FontStyle.Bold);
        lblAppTitle.ForeColor = ThemeManager.Accent;
        lblAppTitle.AutoSize = true;
        lblAppTitle.Location = new Point(120, 22);

        lblSubtitle.Text = "Gestão de Stand Automóvel";
        lblSubtitle.Font = new Font("Segoe UI", 10f);
        lblSubtitle.ForeColor = ThemeManager.TextMuted;
        lblSubtitle.AutoSize = true;
        lblSubtitle.Location = new Point(140, 68);

        // Painel de login
        pnlLogin.Location = new Point(60, 95);
        pnlLogin.Size = new Size(360, 160);
        pnlLogin.BackColor = ThemeManager.Surface;
        pnlLogin.Padding = new Padding(20);

        txtEmployeeNumber.Location = new Point(80, 108);
        txtEmployeeNumber.PlaceholderText = "Nº de Funcionário";
        txtEmployeeNumber.Size = new Size(320, 26);

        txtPassword.Location = new Point(80, 142);
        txtPassword.PlaceholderText = "Password";
        txtPassword.Size = new Size(320, 26);
        txtPassword.UseSystemPasswordChar = true;

        btnLogin.Location = new Point(80, 178);
        btnLogin.Size = new Size(320, 34);
        btnLogin.Text = "Entrar";
        btnLogin.Click += btnLogin_Click;

        lblStatus.Location = new Point(60, 222);
        lblStatus.Size = new Size(360, 36);
        lblStatus.TextAlign = ContentAlignment.MiddleCenter;

        // Divisor
        pnlDivider.Location = new Point(60, 265);
        pnlDivider.Size = new Size(360, 1);
        pnlDivider.BackColor = ThemeManager.Card;

        lblModulesTitle.Text = "MÓDULOS";
        lblModulesTitle.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
        lblModulesTitle.ForeColor = ThemeManager.TextMuted;
        lblModulesTitle.AutoSize = true;
        lblModulesTitle.Location = new Point(60, 278);

        // Botões de módulo (2 colunas de 3)
        int col1X = 60, col2X = 244, btnW = 168, btnH = 32, rowY = 300;

        btnClients.Location     = new Point(col1X, rowY);      btnClients.Size     = new Size(btnW, btnH); btnClients.Text     = "Clientes";     btnClients.Enabled = false; btnClients.Click     += btnClients_Click;
        btnVehicles.Location    = new Point(col2X, rowY);       btnVehicles.Size    = new Size(btnW, btnH); btnVehicles.Text    = "Veículos";     btnVehicles.Enabled = false; btnVehicles.Click    += btnVehicles_Click;
        btnAppointments.Location= new Point(col1X, rowY + 40);  btnAppointments.Size= new Size(btnW, btnH); btnAppointments.Text= "Marcações";    btnAppointments.Enabled = false; btnAppointments.Click+= btnAppointments_Click;
        btnSales.Location       = new Point(col2X, rowY + 40);  btnSales.Size       = new Size(btnW, btnH); btnSales.Text       = "Vendas";       btnSales.Enabled = false; btnSales.Click       += btnSales_Click;
        btnImages.Location      = new Point(col1X, rowY + 80);  btnImages.Size      = new Size(btnW, btnH); btnImages.Text      = "Imagens";      btnImages.Enabled = false; btnImages.Click      += btnImages_Click;
        btnDashboard.Location   = new Point(col2X, rowY + 80);  btnDashboard.Size   = new Size(btnW, btnH); btnDashboard.Text   = "Dashboard";    btnDashboard.Enabled = false; btnDashboard.Click   += btnDashboard_Click;

        Controls.AddRange([
            lblAppTitle, lblSubtitle,
            txtEmployeeNumber, txtPassword, btnLogin, lblStatus,
            pnlDivider, lblModulesTitle,
            btnClients, btnVehicles, btnAppointments,
            btnSales, btnImages, btnDashboard
        ]);
    }
}
