using StandUp.Application.Vehicles;
using StandUp.Presentation.WinForms.Helpers;

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
        await FormHelpers.RunAsync(btnRefresh, async () =>
        {
            try { await LoadBrandsAsync(); }
            catch { /* brands load is non-critical — grid still loads */ }
            await LoadGridAsync();
        });
    }

    private async Task LoadBrandsAsync()
    {
        var brands = await _vehicleApiClient.GetBrandsAsync(CancellationToken.None);
        cbBrand.DataSource = brands.ToList();
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

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnRefresh, () => LoadGridAsync());
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnSearch, async () =>
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
                x.LicensePlate, x.Brand, x.Model, x.Kilometers, x.Price, x.IsSold
            }).ToList();
        });
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtPlate.Text, "Matrícula"),
                FormValidator.Required(txtModel.Text, "Modelo"),
                FormValidator.PositiveInt(txtKilometers.Text, "Quilómetros", out var kms),
                FormValidator.PositiveInt(txtPrice.Text, "Preço", out var price),
                cbBrand.SelectedItem == null ? "Selecione uma marca." : null))
            return;

        await FormHelpers.RunAsync(btnCreate, async () =>
        {
            var req = new CreateVehicleRequest(
                txtPlate.Text,
                kms,
                null,
                cbBrand.SelectedItem!.ToString()!,
                txtModel.Text,
                txtFuel.Text,
                price,
                chkMotorcycle.Checked);

            await _vehicleApiClient.CreateAsync(req, CancellationToken.None);
            await LoadGridAsync();
        });
    }

    private async void btnSetSold_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtPlateStatus.Text, "Matrícula")))
            return;

        await FormHelpers.RunAsync(btnSetSold, async () =>
        {
            await _vehicleApiClient.SetSoldAsync(txtPlateStatus.Text, chkSetSold.Checked, CancellationToken.None);
            await LoadGridAsync();
        });
    }
}
