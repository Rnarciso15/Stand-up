namespace StandUp.Presentation.WinForms;

partial class ImagesForm
{
    private System.ComponentModel.IContainer components = null;

    private TextBox        txtClientId;
    private TextBox        txtVehiclePlate;
    private Button         btnLoadClient;
    private Button         btnUploadClient;
    private Button         btnLoadVehicle;
    private Button         btnUploadVehicle;
    private FlowLayoutPanel flpImages;
    private Label          lblStatus;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtClientId      = new TextBox();
        txtVehiclePlate  = new TextBox();
        btnLoadClient    = new Button();
        btnUploadClient  = new Button();
        btnLoadVehicle   = new Button();
        btnUploadVehicle = new Button();
        flpImages        = new FlowLayoutPanel();
        lblStatus        = new Label();
        SuspendLayout();

        // ── Row 1: Client controls ────────────────────────────────
        txtClientId.Location      = new Point(12, 15);
        txtClientId.Size          = new Size(88, 23);
        txtClientId.PlaceholderText = "ID Cliente";

        btnLoadClient.Location    = new Point(106, 15);
        btnLoadClient.Size        = new Size(120, 23);
        btnLoadClient.Text        = "Carregar Cliente";
        btnLoadClient.Click      += btnLoadClient_Click;

        btnUploadClient.Location  = new Point(232, 15);
        btnUploadClient.Size      = new Size(120, 23);
        btnUploadClient.Text      = "Upload Cliente";
        btnUploadClient.Click    += btnUploadClient_Click;

        // ── Row 2: Vehicle controls ───────────────────────────────
        txtVehiclePlate.Location      = new Point(12, 46);
        txtVehiclePlate.Size          = new Size(100, 23);
        txtVehiclePlate.PlaceholderText = "Matrícula";

        btnLoadVehicle.Location    = new Point(118, 46);
        btnLoadVehicle.Size        = new Size(120, 23);
        btnLoadVehicle.Text        = "Carregar Viatura";
        btnLoadVehicle.Click      += btnLoadVehicle_Click;

        btnUploadVehicle.Location  = new Point(244, 46);
        btnUploadVehicle.Size      = new Size(120, 23);
        btnUploadVehicle.Text      = "Upload Viatura";
        btnUploadVehicle.Click    += btnUploadVehicle_Click;

        // ── Image thumbnail panel ─────────────────────────────────
        flpImages.Location    = new Point(12, 82);
        flpImages.Size        = new Size(776, 360);
        flpImages.AutoScroll  = true;
        flpImages.BorderStyle = BorderStyle.None;
        flpImages.WrapContents = true;

        // ── Status label ──────────────────────────────────────────
        lblStatus.Location  = new Point(12, 452);
        lblStatus.Size      = new Size(776, 18);
        lblStatus.AutoSize  = false;
        lblStatus.Text      = "";

        // ── Form ──────────────────────────────────────────────────
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize    = new Size(800, 480);
        Controls.AddRange([
            txtClientId, btnLoadClient, btnUploadClient,
            txtVehiclePlate, btnLoadVehicle, btnUploadVehicle,
            flpImages, lblStatus
        ]);
        Text = "Gestão de Imagens";
        ResumeLayout(false);
        PerformLayout();
    }
}
