namespace StandUp.Presentation.WinForms;

partial class SalesForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView gridSales;
    private TextBox txtSearchPlate;
    private Button btnSearch;
    private Button btnRefresh;
    private TextBox txtNif;
    private TextBox txtPlate;
    private TextBox txtValue;
    private TextBox txtClientName;
    private DateTimePicker dtTransactionDate;
    private Button btnCreate;
    private TextBox txtSaleId;
    private Button btnGenerateProposal;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gridSales = new DataGridView();
        txtSearchPlate = new TextBox();
        btnSearch = new Button();
        btnRefresh = new Button();
        txtNif = new TextBox();
        txtPlate = new TextBox();
        txtValue = new TextBox();
        txtClientName = new TextBox();
        dtTransactionDate = new DateTimePicker();
        btnCreate = new Button();
        txtSaleId = new TextBox();
        btnGenerateProposal = new Button();
        ((System.ComponentModel.ISupportInitialize)gridSales).BeginInit();
        SuspendLayout();
        gridSales.Location = new Point(12, 48); gridSales.Size = new Size(760, 240);
        txtSearchPlate.Location = new Point(12, 15); txtSearchPlate.Size = new Size(140, 23); txtSearchPlate.PlaceholderText = "Matricula";
        btnSearch.Location = new Point(158, 14); btnSearch.Size = new Size(75, 23); btnSearch.Text = "Pesquisar"; btnSearch.Click += btnSearch_Click;
        btnRefresh.Location = new Point(239, 14); btnRefresh.Size = new Size(75, 23); btnRefresh.Text = "Atualizar"; btnRefresh.Click += btnRefresh_Click;
        txtNif.Location = new Point(12, 300); txtNif.Size = new Size(120, 23); txtNif.PlaceholderText = "NIF";
        txtPlate.Location = new Point(138, 300); txtPlate.Size = new Size(110, 23); txtPlate.PlaceholderText = "Matricula";
        txtValue.Location = new Point(254, 300); txtValue.Size = new Size(90, 23); txtValue.PlaceholderText = "Valor";
        txtClientName.Location = new Point(350, 300); txtClientName.Size = new Size(150, 23); txtClientName.PlaceholderText = "Nome Cliente";
        dtTransactionDate.Location = new Point(506, 300); dtTransactionDate.Size = new Size(180, 23);
        btnCreate.Location = new Point(692, 300); btnCreate.Size = new Size(80, 23); btnCreate.Text = "Registar"; btnCreate.Click += btnCreate_Click;
        txtSaleId.Location = new Point(12, 330); txtSaleId.Size = new Size(80, 23); txtSaleId.PlaceholderText = "ID venda";
        btnGenerateProposal.Location = new Point(98, 330); btnGenerateProposal.Size = new Size(140, 23); btnGenerateProposal.Text = "Gerar Proposta PDF"; btnGenerateProposal.Click += btnGenerateProposal_Click;
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(784, 365);
        Controls.AddRange([gridSales, txtSearchPlate, btnSearch, btnRefresh, txtNif, txtPlate, txtValue, txtClientName, dtTransactionDate, btnCreate, txtSaleId, btnGenerateProposal]);
        Text = "Gestao de Vendas";
        Load += SalesForm_Load;
        ((System.ComponentModel.ISupportInitialize)gridSales).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
