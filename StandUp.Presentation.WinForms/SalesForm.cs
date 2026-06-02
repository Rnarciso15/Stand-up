using StandUp.Application.Sales;
using StandUp.Presentation.WinForms.Helpers;

namespace StandUp.Presentation.WinForms;

public partial class SalesForm : Form
{
    private const int ProposalValidityDays = 7;

    private readonly ISalesApiClient _api;

    public SalesForm(ISalesApiClient api)
    {
        _api = api;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        var header = ThemeManager.CreateHeader("Gestão de Vendas", ClientSize.Width);
        Controls.Add(header);
        header.BringToFront();
    }

    private async void SalesForm_Load(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnRefresh, () => LoadGridAsync());
    }

    private async Task LoadGridAsync(string? plate = null)
    {
        var list = string.IsNullOrWhiteSpace(plate)
            ? await _api.GetAllAsync(CancellationToken.None)
            : await _api.SearchByPlateAsync(plate, CancellationToken.None);

        gridSales.DataSource = list.Select(x => new
        {
            x.Id,
            x.ClientName,
            x.ClientNif,
            x.VehicleLicensePlate,
            x.Value,
            x.TransactionDate
        }).ToList();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnRefresh, () => LoadGridAsync());
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnSearch, () => LoadGridAsync(txtSearchPlate.Text));
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtNif.Text, "NIF"),
                FormValidator.Nif(txtNif.Text),
                FormValidator.Required(txtPlate.Text, "Matrícula"),
                FormValidator.Required(txtClientName.Text, "Nome do Cliente"),
                FormValidator.PositiveInt(txtValue.Text, "Valor", out var value)))
            return;

        await FormHelpers.RunAsync(btnCreate, async () =>
        {
            var request = new CreateSaleTransactionRequest(
                txtNif.Text,
                txtPlate.Text,
                dtTransactionDate.Value,
                value,
                txtClientName.Text);

            await _api.CreateAsync(request, CancellationToken.None);
            await LoadGridAsync();
        });
    }

    private async void btnGenerateProposal_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtSaleId.Text, "ID de Venda", out var saleId)))
            return;

        await FormHelpers.RunAsync(btnGenerateProposal, async () =>
        {
            var expiry = DateTime.UtcNow.AddDays(ProposalValidityDays);
            await _api.GenerateProposalAsync(saleId, expiry, CancellationToken.None);
            MessageBox.Show("Proposta gerada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }
}
