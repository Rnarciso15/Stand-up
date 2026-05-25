namespace StandUp.Presentation.WinForms;

partial class DashboardForm
{
    private System.ComponentModel.IContainer components = null;
    private DateTimePicker dtFrom;
    private DateTimePicker dtTo;
    private Button btnLoadKpis;
    private Label lblKpis;
    private DataGridView gridTopVehicles;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dtFrom = new DateTimePicker();
        dtTo = new DateTimePicker();
        btnLoadKpis = new Button();
        lblKpis = new Label();
        gridTopVehicles = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)gridTopVehicles).BeginInit();
        SuspendLayout();
        dtFrom.Location = new Point(12, 12); dtFrom.Size = new Size(220, 23);
        dtTo.Location = new Point(238, 12); dtTo.Size = new Size(220, 23);
        btnLoadKpis.Location = new Point(464, 12); btnLoadKpis.Size = new Size(90, 23); btnLoadKpis.Text = "Carregar"; btnLoadKpis.Click += btnLoadKpis_Click;
        lblKpis.Location = new Point(12, 45); lblKpis.Size = new Size(760, 40);
        gridTopVehicles.Location = new Point(12, 90); gridTopVehicles.Size = new Size(760, 250);
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(784, 352);
        Controls.AddRange([dtFrom, dtTo, btnLoadKpis, lblKpis, gridTopVehicles]);
        Text = "Dashboard Comercial";
        ((System.ComponentModel.ISupportInitialize)gridTopVehicles).EndInit();
        ResumeLayout(false);
    }
}
