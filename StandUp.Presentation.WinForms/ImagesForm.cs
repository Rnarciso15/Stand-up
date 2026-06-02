using StandUp.Presentation.WinForms.Helpers;

namespace StandUp.Presentation.WinForms;

public partial class ImagesForm : Form
{
    private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB
    private static readonly string ImageFilter =
        "Imagens|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.webp";

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
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtClientId.Text, "ID Cliente", out var clientId)))
            return;

        await FormHelpers.RunAsync(btnLoadClient, async () =>
        {
            var list = await _api.GetClientImagesAsync(clientId, CancellationToken.None);
            gridImages.DataSource = list;
        });
    }

    private async void btnUploadClient_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtClientId.Text, "ID Cliente", out var clientId)))
            return;

        var path = PickImageFile();
        if (path is null) return;

        await FormHelpers.RunAsync(btnUploadClient, async () =>
        {
            var bytes = await File.ReadAllBytesAsync(path);
            await _api.AddClientImageAsync(clientId, bytes, CancellationToken.None);
            var list = await _api.GetClientImagesAsync(clientId, CancellationToken.None);
            gridImages.DataSource = list;
        });
    }

    private async void btnLoadVehicle_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtVehiclePlate.Text, "Matrícula")))
            return;

        await FormHelpers.RunAsync(btnLoadVehicle, async () =>
        {
            var list = await _api.GetVehicleImagesAsync(txtVehiclePlate.Text, CancellationToken.None);
            gridImages.DataSource = list;
        });
    }

    private async void btnUploadVehicle_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtVehiclePlate.Text, "Matrícula")))
            return;

        var path = PickImageFile();
        if (path is null) return;

        await FormHelpers.RunAsync(btnUploadVehicle, async () =>
        {
            var bytes = await File.ReadAllBytesAsync(path);
            await _api.AddVehicleImageAsync(txtVehiclePlate.Text, bytes, CancellationToken.None);
            var list = await _api.GetVehicleImagesAsync(txtVehiclePlate.Text, CancellationToken.None);
            gridImages.DataSource = list;
        });
    }

    /// <summary>
    /// Abre file dialog e valida extensão e tamanho. Retorna caminho ou null se cancelado/inválido.
    /// </summary>
    private static string? PickImageFile()
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Selecionar Imagem",
            Filter = ImageFilter,
            CheckFileExists = true
        };

        if (dlg.ShowDialog() != DialogResult.OK) return null;

        var info = new FileInfo(dlg.FileName);
        if (info.Length > MaxFileSizeBytes)
        {
            MessageBox.Show("Ficheiro demasiado grande (máximo 5 MB).",
                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }

        return dlg.FileName;
    }
}
