using StandUp.Presentation.WinForms.Helpers;

namespace StandUp.Presentation.WinForms;

public partial class ImagesForm : Form
{
    private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB
    private const int  MaxImagesToLoad  = 20;
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
        SetStatus("Introduza um ID de cliente ou matrícula para carregar imagens.");
    }

    // ── Client handlers ───────────────────────────────────────────

    private async void btnLoadClient_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtClientId.Text, "ID Cliente", out var clientId)))
            return;

        await FormHelpers.RunAsync(btnLoadClient, () => LoadClientImagesAsync(clientId));
    }

    private async void btnUploadClient_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtClientId.Text, "ID Cliente", out var clientId)))
            return;

        var paths = PickImageFiles();
        if (paths.Length == 0) return;

        await FormHelpers.RunAsync(btnUploadClient, async () =>
        {
            int uploaded = 0;
            foreach (var path in paths)
            {
                var info = new FileInfo(path);
                if (info.Length > MaxFileSizeBytes) continue;
                var bytes = await File.ReadAllBytesAsync(path);
                await _api.AddClientImageAsync(clientId, bytes, CancellationToken.None);
                uploaded++;
                SetStatus($"A carregar... {uploaded}/{paths.Length}");
            }
            await LoadClientImagesAsync(clientId);
        });
    }

    // ── Vehicle handlers ──────────────────────────────────────────

    private async void btnLoadVehicle_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtVehiclePlate.Text, "Matrícula")))
            return;

        var plate = txtVehiclePlate.Text.Trim();
        await FormHelpers.RunAsync(btnLoadVehicle, () => LoadVehicleImagesAsync(plate));
    }

    private async void btnUploadVehicle_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.Required(txtVehiclePlate.Text, "Matrícula")))
            return;

        var paths = PickImageFiles();
        if (paths.Length == 0) return;

        var plate = txtVehiclePlate.Text.Trim();
        await FormHelpers.RunAsync(btnUploadVehicle, async () =>
        {
            int uploaded = 0;
            foreach (var path in paths)
            {
                var info = new FileInfo(path);
                if (info.Length > MaxFileSizeBytes) continue;
                var bytes = await File.ReadAllBytesAsync(path);
                await _api.AddVehicleImageAsync(plate, bytes, CancellationToken.None);
                uploaded++;
                SetStatus($"A carregar... {uploaded}/{paths.Length}");
            }
            await LoadVehicleImagesAsync(plate);
        });
    }

    // ── Image loading ─────────────────────────────────────────────

    private async Task LoadClientImagesAsync(int clientId)
    {
        ClearThumbnails();
        SetStatus("A carregar imagens...");

        int count = 0;
        for (int i = 0; i < MaxImagesToLoad; i++)
        {
            var bytes = await _api.GetClientImageByIndexAsync(clientId, i, CancellationToken.None);
            if (bytes is null) break;
            AddThumbnail(bytes, i + 1);
            count++;
        }

        SetStatus(count == 0
            ? "Sem imagens para este cliente."
            : $"{count} imagem(ns) carregada(s). Clique numa miniatura para ampliar.");
    }

    private async Task LoadVehicleImagesAsync(string plate)
    {
        ClearThumbnails();
        SetStatus("A carregar imagens...");

        int count = 0;
        for (int i = 0; i < MaxImagesToLoad; i++)
        {
            var bytes = await _api.GetVehicleImageByIndexAsync(plate, i, CancellationToken.None);
            if (bytes is null) break;
            AddThumbnail(bytes, i + 1);
            count++;
        }

        SetStatus(count == 0
            ? "Sem imagens para esta viatura."
            : $"{count} imagem(ns) carregada(s). Clique numa miniatura para ampliar.");
    }

    // ── Thumbnail display ─────────────────────────────────────────

    private void ClearThumbnails()
    {
        foreach (Control c in flpImages.Controls)
        {
            if (c is PictureBox pb) pb.Image?.Dispose();
        }
        flpImages.Controls.Clear();
    }

    private void AddThumbnail(byte[] bytes, int number)
    {
        try
        {
            Image thumbnail;
            using (var ms = new MemoryStream(bytes))
            using (var source = Image.FromStream(ms))
            {
                thumbnail = new Bitmap(source); // independent of stream
            }

            var pb = new PictureBox
            {
                Size     = new Size(145, 97),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image    = thumbnail,
                Margin   = new Padding(3),
                Cursor   = Cursors.Hand,
                BackColor = ThemeManager.Surface
            };

            pb.Paint += (sender, e) =>
            {
                // Draw subtle border
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0x1E, 0x1E, 0x26), 1), 0, 0, pb.Width - 1, pb.Height - 1);
                // Draw number badge
                using var font = new Font("Segoe UI", 7f);
                using var brush = new SolidBrush(Color.FromArgb(140, 255, 255, 255));
                e.Graphics.DrawString(number.ToString("00"), font, brush, 4, 4);
            };

            pb.Click += (_, _) => ShowFullImage(bytes, number);
            flpImages.Controls.Add(pb);
        }
        catch
        {
            // Skip invalid images silently
        }
    }

    private static void ShowFullImage(byte[] bytes, int number)
    {
        Image img;
        using (var ms = new MemoryStream(bytes))
        using (var source = Image.FromStream(ms))
        {
            img = new Bitmap(source);
        }

        var form = new Form
        {
            Text            = $"Imagem {number:00}",
            ClientSize      = new Size(960, 640),
            StartPosition   = FormStartPosition.CenterScreen,
            BackColor       = Color.FromArgb(8, 8, 9),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox     = false
        };
        var pb = new PictureBox
        {
            Dock      = DockStyle.Fill,
            Image     = img,
            SizeMode  = PictureBoxSizeMode.Zoom,
            BackColor = Color.FromArgb(8, 8, 9)
        };
        form.FormClosed += (_, _) => img.Dispose();
        form.Controls.Add(pb);
        form.Show();
    }

    // ── Helpers ───────────────────────────────────────────────────

    private void SetStatus(string message) => lblStatus.Text = message;

    private static string[] PickImageFiles()
    {
        using var dlg = new OpenFileDialog
        {
            Title           = "Selecionar Imagens",
            Filter          = ImageFilter,
            CheckFileExists = true,
            Multiselect     = true
        };

        if (dlg.ShowDialog() != DialogResult.OK) return [];

        var oversized = dlg.FileNames
            .Where(f => new FileInfo(f).Length > MaxFileSizeBytes)
            .ToArray();

        if (oversized.Length > 0)
            MessageBox.Show(
                $"{oversized.Length} ficheiro(s) ignorado(s) por excederem 5 MB.",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        return dlg.FileNames
            .Where(f => new FileInfo(f).Length <= MaxFileSizeBytes)
            .ToArray();
    }
}
