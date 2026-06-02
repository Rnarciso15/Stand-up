using StandUp.Application.Vehicles;

namespace StandUp.Presentation.WinForms;

public partial class VehiclesForm : Form
{
    private readonly IVehicleApiClient _vehicleApiClient;

    public VehiclesForm(IVehicleApiClient vehicleApiClient)
    {
        _vehicleApiClient = vehicleApiClient;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        var header = ThemeManager.CreateHeader("Gestão de Veículos", ClientSize.Width);
        Controls.Add(header);
        header.BringToFront();
    }

    private async void VehiclesForm_Load(object sender, EventArgs e)
    {
        await LoadBrandsAsync();
        await LoadGridAsync();
    }

    private async Task LoadBrandsAsync()
    {
        try
        {
            var brands = await _vehicleApiClient.GetBrandsAsync(CancellationToken.None);
            cbBrand.DataSource = brands.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar marcas: {ex.Message}");
        }
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
        var plate = txtSearchPlate.Text;
        var model = txtSearchModel.Text;

        IReadOnlyList<VehicleDto> items;

        if (!string.IsNullOrWhiteSpace(plate))
            items = await _vehicleApiClient.SearchAsync(plate, sold, CancellationToken.None);
        else if (!string.IsNullOrWhiteSpace(model))
            items = await _vehicleApiClient.SearchByBrandAndModelAsync(null, model, sold, CancellationToken.None);
        else
            items = await _vehicleApiClient.GetAllAsync(sold, CancellationToken.None);

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

        var selectedBrand = cbBrand.SelectedItem?.ToString() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(selectedBrand))
        {
            MessageBox.Show("Selecione uma marca.");
            return;
        }

        var req = new CreateVehicleRequest(
            txtPlate.Text,
            kms,
            null,
            selectedBrand,
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
