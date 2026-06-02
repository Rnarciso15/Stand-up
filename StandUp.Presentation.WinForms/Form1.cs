using Microsoft.Extensions.DependencyInjection;

namespace StandUp.Presentation.WinForms;

public partial class Form1 : Form
{
    private readonly IAuthApiClient _authApiClient;
    private readonly IServiceProvider _serviceProvider;

    public Form1(IAuthApiClient authApiClient, IServiceProvider serviceProvider)
    {
        _authApiClient = authApiClient;
        _serviceProvider = serviceProvider;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        // O painel de login precisa de fundo Surface explícito após tema
        foreach (Control c in Controls)
            if (c is TextBox tb) ThemeManager.StyleTextBox(tb);
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;

        if (!int.TryParse(txtEmployeeNumber.Text, out var employeeNumber))
        {
            lblStatus.Text = "Número de funcionário inválido.";
            return;
        }

        btnLogin.Enabled = false;
        try
        {
            var result = await _authApiClient.LoginAsync(employeeNumber, txtPassword.Text, CancellationToken.None);
            if (result.IsAuthenticated)
            {
                lblStatus.Text = $"Bem-vindo, {result.Name}. Admin: {result.IsAdmin}";
                UserSession.Role = result.Role ?? (result.IsAdmin ? "Admin" : "Vendedor");
                btnClients.Enabled = true;
                btnVehicles.Enabled = true;
                btnAppointments.Enabled = true;
                btnSales.Enabled = true;
                btnImages.Enabled = true;
                btnDashboard.Enabled = true;
            }
            else
            {
                lblStatus.Text = result.Message;
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Erro ao autenticar: {ex.Message}";
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }

    private void btnClients_Click(object sender, EventArgs e)
    {
        using var clientsForm = _serviceProvider.GetRequiredService<ClientsForm>();
        clientsForm.ShowDialog(this);
    }

    private void btnVehicles_Click(object sender, EventArgs e)
    {
        using var vehiclesForm = _serviceProvider.GetRequiredService<VehiclesForm>();
        vehiclesForm.ShowDialog(this);
    }

    private void btnAppointments_Click(object sender, EventArgs e)
    {
        using var form = _serviceProvider.GetRequiredService<AppointmentsForm>();
        form.ShowDialog(this);
    }

    private void btnSales_Click(object sender, EventArgs e)
    {
        using var form = _serviceProvider.GetRequiredService<SalesForm>();
        form.ShowDialog(this);
    }

    private void btnImages_Click(object sender, EventArgs e)
    {
        using var form = _serviceProvider.GetRequiredService<ImagesForm>();
        form.ShowDialog(this);
    }

    private void btnDashboard_Click(object sender, EventArgs e)
    {
        using var form = _serviceProvider.GetRequiredService<DashboardForm>();
        form.ShowDialog(this);
    }
}
