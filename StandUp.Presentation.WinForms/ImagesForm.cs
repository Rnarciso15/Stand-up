namespace StandUp.Presentation.WinForms;

public partial class ImagesForm : Form
{
    private readonly IImagesApiClient _api;

    public ImagesForm(IImagesApiClient api)
    {
        _api = api;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        var header = ThemeManager.CreateHeader("Gestão de Imagens", ClientSize.Width);
        Controls.Add(header);
        header.BringToFront();
    }

    private async void btnLoadClient_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtClientId.Text, out var clientId)) return;
        var list = await _api.GetClientImagesAsync(clientId, CancellationToken.None);
        gridImages.DataSource = list;
    }

    private async void btnUploadClient_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtClientId.Text, out var clientId)) return;
        var bytes = await File.ReadAllBytesAsync(txtFilePath.Text);
        await _api.AddClientImageAsync(clientId, bytes, CancellationToken.None);
        btnLoadClient_Click(sender, e);
    }

    private async void btnLoadVehicle_Click(object sender, EventArgs e)
    {
        var list = await _api.GetVehicleImagesAsync(txtVehiclePlate.Text, CancellationToken.None);
        gridImages.DataSource = list;
    }

    private async void btnUploadVehicle_Click(object sender, EventArgs e)
    {
        var bytes = await File.ReadAllBytesAsync(txtFilePath.Text);
        await _api.AddVehicleImageAsync(txtVehiclePlate.Text, bytes, CancellationToken.None);
        btnLoadVehicle_Click(sender, e);
    }
}
