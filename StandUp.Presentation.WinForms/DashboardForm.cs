namespace StandUp.Presentation.WinForms;

public partial class DashboardForm : Form
{
    private readonly IDashboardApiClient _api;

    public DashboardForm(IDashboardApiClient api)
    {
        _api = api;
        InitializeComponent();
    }

    private async void btnLoadKpis_Click(object sender, EventArgs e)
    {
        var dto = await _api.GetKpisAsync(dtFrom.Value.ToUniversalTime(), dtTo.Value.ToUniversalTime(), CancellationToken.None);
        if (dto is null)
        {
            lblKpis.Text = "Sem dados.";
            return;
        }

        lblKpis.Text = $"Marcacoes: {dto.TotalAppointments} | Vendas: {dto.TotalSales} | Conversao: {dto.ConversionRate}% | Dias medio ate venda: {dto.AvgDaysToSale}";
        gridTopVehicles.DataSource = dto.TopVehicles.ToList();
    }
}
