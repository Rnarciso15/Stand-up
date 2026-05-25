namespace StandUp.Presentation.WinForms;

partial class ImagesForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtClientId;
    private TextBox txtVehiclePlate;
    private TextBox txtFilePath;
    private Button btnLoadClient;
    private Button btnUploadClient;
    private Button btnLoadVehicle;
    private Button btnUploadVehicle;
    private DataGridView gridImages;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtClientId = new TextBox();
        txtVehiclePlate = new TextBox();
        txtFilePath = new TextBox();
        btnLoadClient = new Button();
        btnUploadClient = new Button();
        btnLoadVehicle = new Button();
        btnUploadVehicle = new Button();
        gridImages = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)gridImages).BeginInit();
        SuspendLayout();
        txtClientId.Location = new Point(12, 15); txtClientId.Size = new Size(90, 23); txtClientId.PlaceholderText = "Client ID";
        btnLoadClient.Location = new Point(108, 15); btnLoadClient.Size = new Size(90, 23); btnLoadClient.Text = "Load Client"; btnLoadClient.Click += btnLoadClient_Click;
        btnUploadClient.Location = new Point(204, 15); btnUploadClient.Size = new Size(100, 23); btnUploadClient.Text = "Upload Client"; btnUploadClient.Click += btnUploadClient_Click;
        txtVehiclePlate.Location = new Point(320, 15); txtVehiclePlate.Size = new Size(100, 23); txtVehiclePlate.PlaceholderText = "Matrícula";
        btnLoadVehicle.Location = new Point(426, 15); btnLoadVehicle.Size = new Size(95, 23); btnLoadVehicle.Text = "Load Vehicle"; btnLoadVehicle.Click += btnLoadVehicle_Click;
        btnUploadVehicle.Location = new Point(527, 15); btnUploadVehicle.Size = new Size(110, 23); btnUploadVehicle.Text = "Upload Vehicle"; btnUploadVehicle.Click += btnUploadVehicle_Click;
        txtFilePath.Location = new Point(12, 50); txtFilePath.Size = new Size(625, 23); txtFilePath.PlaceholderText = "Caminho imagem";
        gridImages.Location = new Point(12, 85); gridImages.Size = new Size(625, 250);
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(650, 350);
        Controls.AddRange([txtClientId, btnLoadClient, btnUploadClient, txtVehiclePlate, btnLoadVehicle, btnUploadVehicle, txtFilePath, gridImages]);
        Text = "Gestão de Imagens";
        ((System.ComponentModel.ISupportInitialize)gridImages).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
