using StandUp.Application.Clients;

namespace StandUp.Presentation.WinForms;

public partial class ClientsForm : Form
{
    private readonly IClientApiClient _clientApiClient;

    public ClientsForm(IClientApiClient clientApiClient)
    {
        _clientApiClient = clientApiClient;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        var header = ThemeManager.CreateHeader("Gestão de Clientes", ClientSize.Width);
        Controls.Add(header);
        header.BringToFront();
    }

    private async void ClientsForm_Load(object sender, EventArgs e)
    {
        await LoadGridAsync();
    }

    private async Task LoadGridAsync(string? name = null)
    {
        var clients = string.IsNullOrWhiteSpace(name)
            ? await _clientApiClient.GetAllAsync(CancellationToken.None)
            : await _clientApiClient.SearchAsync(name, CancellationToken.None);

        gridClients.DataSource = clients
            .Select(x => new { x.Id, x.Name, x.Email, x.Phone, x.Nif, x.IsActive })
            .ToList();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadGridAsync();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await LoadGridAsync(txtSearch.Text);
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            var request = new CreateClientRequest(
                txtName.Text,
                null,
                null,
                txtEmail.Text,
                txtPhone.Text,
                null,
                txtNif.Text,
                txtAddress.Text);

            await _clientApiClient.CreateAsync(request, CancellationToken.None);
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtNif.Clear();
            txtAddress.Clear();
            await LoadGridAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnToggleActive_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtClientId.Text, out var id))
        {
            MessageBox.Show("ID inválido.");
            return;
        }

        await _clientApiClient.SetActiveAsync(id, chkIsActive.Checked, CancellationToken.None);
        await LoadGridAsync();
    }
}
