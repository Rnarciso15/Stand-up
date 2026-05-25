using StandUp.Application.Sales;

namespace StandUp.Presentation.WinForms;

public partial class SalesForm : Form
{
    private readonly ISalesApiClient _api;

    public SalesForm(ISalesApiClient api)
    {
        _api = api;
        InitializeComponent();
    }

    private async void SalesForm_Load(object sender, EventArgs e) => await LoadGridAsync();

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

    private async void btnRefresh_Click(object sender, EventArgs e) => await LoadGridAsync();
    private async void btnSearch_Click(object sender, EventArgs e) => await LoadGridAsync(txtSearchPlate.Text);

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtValue.Text, out var value))
        {
            MessageBox.Show("Valor inválido.");
            return;
        }

        var request = new CreateSaleTransactionRequest(
            txtNif.Text,
            txtPlate.Text,
            dtTransactionDate.Value,
            value,
            txtClientName.Text);

        await _api.CreateAsync(request, CancellationToken.None);
        await LoadGridAsync();
    }

    private async void btnGenerateProposal_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtSaleId.Text, out var saleId))
        {
            MessageBox.Show("ID de venda invalido.");
            return;
        }

        await _api.GenerateProposalAsync(saleId, DateTime.UtcNow.AddDays(7), CancellationToken.None);
        MessageBox.Show("Proposta gerada com sucesso.");
    }
}
