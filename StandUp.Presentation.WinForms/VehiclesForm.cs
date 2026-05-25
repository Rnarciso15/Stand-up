using StandUp.Application.Vehicles;

namespace StandUp.Presentation.WinForms;

public partial class VehiclesForm : Form
{
    private readonly IVehicleApiClient _vehicleApiClient;

    public VehiclesForm(IVehicleApiClient vehicleApiClient)
    {
        _vehicleApiClient = vehicleApiClient;
        InitializeComponent();
    }

    private async void VehiclesForm_Load(object sender, EventArgs e)
    {
        await LoadGridAsync();
    }

    private async Task LoadGridAsync(string? plate = null)
    {
        var sold = chkSoldFilter.Checked;
        var items = string.IsNullOrWhiteSpace(plate)
            ? await _vehicleApiClient.GetAllAsync(sold, CancellationToken.None)
            : await _vehicleApiClient.SearchAsync(plate, sold, CancellationToken.None);

        gridVehicles.DataSource = items.Select(x => new
        {
            x.LicensePlate,
            x.Brand,
            x.Model,
            x.Kilometers,
            x.Price,
            x.IsSold
        }).ToList();
    }

    private async void btnRefresh_Click(object sender, EventArgs e) => await LoadGridAsync();
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        var sold = chkSoldFilter.Checked;
        var items = await _vehicleApiClient.SearchAdvancedAsync(txtSearchPlate.Text, sold, CancellationToken.None);
        gridVehicles.DataSource = items.Select(x => new
        {
            x.LicensePlate,
            x.Brand,
            x.Model,
            x.Kilometers,
            x.Price,
            x.IsSold
        }).ToList();
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtKilometers.Text, out var kms) || !int.TryParse(txtPrice.Text, out var price))
        {
            MessageBox.Show("Quilómetros e preço inválidos.");
            return;
        }

        var req = new CreateVehicleRequest(
            txtPlate.Text,
            kms,
            null,
            txtBrand.Text,
            txtModel.Text,
            txtFuel.Text,
            price,
            chkMotorcycle.Checked);

        await _vehicleApiClient.CreateAsync(req, CancellationToken.None);
        await LoadGridAsync();
    }

    private async void btnSetSold_Click(object sender, EventArgs e)
    {
        await _vehicleApiClient.SetSoldAsync(txtPlateStatus.Text, chkSetSold.Checked, CancellationToken.None);
        await LoadGridAsync();
    }
}
