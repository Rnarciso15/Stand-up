namespace StandUp.Presentation.WinForms;

partial class VehiclesForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView gridVehicles;
    private TextBox txtSearchPlate;
    private CheckBox chkSoldFilter;
    private Button btnSearch;
    private Button btnRefresh;
    private TextBox txtPlate;
    private TextBox txtBrand;
    private TextBox txtModel;
    private TextBox txtFuel;
    private TextBox txtKilometers;
    private TextBox txtPrice;
    private CheckBox chkMotorcycle;
    private Button btnCreate;
    private TextBox txtPlateStatus;
    private CheckBox chkSetSold;
    private Button btnSetSold;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gridVehicles = new DataGridView();
        txtSearchPlate = new TextBox();
        chkSoldFilter = new CheckBox();
        btnSearch = new Button();
        btnRefresh = new Button();
        txtPlate = new TextBox();
        txtBrand = new TextBox();
        txtModel = new TextBox();
        txtFuel = new TextBox();
        txtKilometers = new TextBox();
        txtPrice = new TextBox();
        chkMotorcycle = new CheckBox();
        btnCreate = new Button();
        txtPlateStatus = new TextBox();
        chkSetSold = new CheckBox();
        btnSetSold = new Button();
        ((System.ComponentModel.ISupportInitialize)gridVehicles).BeginInit();
        SuspendLayout();
        gridVehicles.Location = new Point(12, 48); gridVehicles.Size = new Size(760, 240);
        txtSearchPlate.Location = new Point(12, 14); txtSearchPlate.Size = new Size(140, 23); txtSearchPlate.PlaceholderText = "Matrícula";
        chkSoldFilter.Location = new Point(158, 14); chkSoldFilter.Size = new Size(90, 23); chkSoldFilter.Text = "Vendidos";
        btnSearch.Location = new Point(254, 13); btnSearch.Size = new Size(75, 23); btnSearch.Text = "Pesquisar"; btnSearch.Click += btnSearch_Click;
        btnRefresh.Location = new Point(335, 13); btnRefresh.Size = new Size(75, 23); btnRefresh.Text = "Atualizar"; btnRefresh.Click += btnRefresh_Click;
        txtPlate.Location = new Point(12, 305); txtPlate.Size = new Size(100, 23); txtPlate.PlaceholderText = "Matrícula";
        txtBrand.Location = new Point(118, 305); txtBrand.Size = new Size(110, 23); txtBrand.PlaceholderText = "Marca";
        txtModel.Location = new Point(234, 305); txtModel.Size = new Size(110, 23); txtModel.PlaceholderText = "Modelo";
        txtFuel.Location = new Point(350, 305); txtFuel.Size = new Size(90, 23); txtFuel.PlaceholderText = "Comb.";
        txtKilometers.Location = new Point(446, 305); txtKilometers.Size = new Size(90, 23); txtKilometers.PlaceholderText = "Km";
        txtPrice.Location = new Point(542, 305); txtPrice.Size = new Size(90, 23); txtPrice.PlaceholderText = "Preço";
        chkMotorcycle.Location = new Point(638, 305); chkMotorcycle.Size = new Size(60, 23); chkMotorcycle.Text = "Mota";
        btnCreate.Location = new Point(704, 305); btnCreate.Size = new Size(68, 23); btnCreate.Text = "Criar"; btnCreate.Click += btnCreate_Click;
        txtPlateStatus.Location = new Point(12, 344); txtPlateStatus.Size = new Size(100, 23); txtPlateStatus.PlaceholderText = "Matrícula";
        chkSetSold.Location = new Point(118, 344); chkSetSold.Size = new Size(80, 23); chkSetSold.Text = "Vendido";
        btnSetSold.Location = new Point(204, 344); btnSetSold.Size = new Size(110, 23); btnSetSold.Text = "Atualizar estado"; btnSetSold.Click += btnSetSold_Click;
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(784, 381);
        Controls.AddRange([gridVehicles, txtSearchPlate, chkSoldFilter, btnSearch, btnRefresh, txtPlate, txtBrand, txtModel, txtFuel, txtKilometers, txtPrice, chkMotorcycle, btnCreate, txtPlateStatus, chkSetSold, btnSetSold]);
        Text = "Gestão de Veículos";
        Load += VehiclesForm_Load;
        ((System.ComponentModel.ISupportInitialize)gridVehicles).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
