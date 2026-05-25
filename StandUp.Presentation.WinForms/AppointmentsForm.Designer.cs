namespace StandUp.Presentation.WinForms;

partial class AppointmentsForm
{
    private System.ComponentModel.IContainer components = null;
    private DateTimePicker dtDate;
    private NumericUpDown numHour;
    private NumericUpDown numMinute;
    private DataGridView gridAppointments;
    private Button btnLoad;
    private TextBox txtEmployeeNumber;
    private TextBox txtEmployeeName;
    private TextBox txtClientId;
    private TextBox txtClientName;
    private TextBox txtClientPhone;
    private CheckBox chkSmsConsent;
    private TextBox txtVehicleBrand;
    private TextBox txtVehicleModel;
    private TextBox txtVehiclePlate;
    private Button btnCreate;
    private TextBox txtAppointmentId;
    private Button btnDelete;
    private Button btnSendConfirmation;
    private Button btnSendReminder;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dtDate = new DateTimePicker();
        numHour = new NumericUpDown();
        numMinute = new NumericUpDown();
        gridAppointments = new DataGridView();
        btnLoad = new Button();
        txtEmployeeNumber = new TextBox();
        txtEmployeeName = new TextBox();
        txtClientId = new TextBox();
        txtClientName = new TextBox();
        txtClientPhone = new TextBox();
        chkSmsConsent = new CheckBox();
        txtVehicleBrand = new TextBox();
        txtVehicleModel = new TextBox();
        txtVehiclePlate = new TextBox();
        btnCreate = new Button();
        txtAppointmentId = new TextBox();
        btnDelete = new Button();
        btnSendConfirmation = new Button();
        btnSendReminder = new Button();
        ((System.ComponentModel.ISupportInitialize)numHour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numMinute).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridAppointments).BeginInit();
        SuspendLayout();
        dtDate.Location = new Point(12, 12); dtDate.Size = new Size(180, 23);
        numHour.Location = new Point(198, 12); numHour.Maximum = 23; numHour.Size = new Size(50, 23);
        numMinute.Location = new Point(254, 12); numMinute.Maximum = 59; numMinute.Increment = 15; numMinute.Size = new Size(50, 23);
        btnLoad.Location = new Point(310, 12); btnLoad.Size = new Size(75, 23); btnLoad.Text = "Carregar"; btnLoad.Click += btnLoad_Click;
        gridAppointments.Location = new Point(12, 45); gridAppointments.Size = new Size(820, 220);
        txtEmployeeNumber.Location = new Point(12, 280); txtEmployeeNumber.Size = new Size(80, 23); txtEmployeeNumber.PlaceholderText = "Func";
        txtEmployeeName.Location = new Point(98, 280); txtEmployeeName.Size = new Size(120, 23); txtEmployeeName.PlaceholderText = "Nome Func";
        txtClientId.Location = new Point(224, 280); txtClientId.Size = new Size(80, 23); txtClientId.PlaceholderText = "Cliente";
        txtClientName.Location = new Point(310, 280); txtClientName.Size = new Size(120, 23); txtClientName.PlaceholderText = "Nome Cliente";
        txtClientPhone.Location = new Point(436, 280); txtClientPhone.Size = new Size(95, 23); txtClientPhone.PlaceholderText = "Telefone";
        chkSmsConsent.Location = new Point(536, 280); chkSmsConsent.Size = new Size(60, 23); chkSmsConsent.Text = "SMS";
        txtVehicleBrand.Location = new Point(602, 280); txtVehicleBrand.Size = new Size(70, 23); txtVehicleBrand.PlaceholderText = "Marca";
        txtVehicleModel.Location = new Point(678, 280); txtVehicleModel.Size = new Size(60, 23); txtVehicleModel.PlaceholderText = "Modelo";
        txtVehiclePlate.Location = new Point(744, 280); txtVehiclePlate.Size = new Size(88, 23); txtVehiclePlate.PlaceholderText = "Matr";
        btnCreate.Location = new Point(12, 316); btnCreate.Size = new Size(60, 23); btnCreate.Text = "Criar"; btnCreate.Click += btnCreate_Click;
        txtAppointmentId.Location = new Point(78, 316); txtAppointmentId.Size = new Size(90, 23); txtAppointmentId.PlaceholderText = "ID";
        btnDelete.Location = new Point(174, 316); btnDelete.Size = new Size(75, 23); btnDelete.Text = "Eliminar"; btnDelete.Click += btnDelete_Click;
        btnSendConfirmation.Location = new Point(255, 316); btnSendConfirmation.Size = new Size(120, 23); btnSendConfirmation.Text = "Enviar Conf."; btnSendConfirmation.Click += btnSendConfirmation_Click;
        btnSendReminder.Location = new Point(381, 316); btnSendReminder.Size = new Size(120, 23); btnSendReminder.Text = "Enviar 24h"; btnSendReminder.Click += btnSendReminder_Click;
        AutoScaleMode = AutoScaleMode.Font; ClientSize = new Size(844, 351);
        Controls.AddRange([dtDate, numHour, numMinute, btnLoad, gridAppointments, txtEmployeeNumber, txtEmployeeName, txtClientId, txtClientName, txtClientPhone, chkSmsConsent, txtVehicleBrand, txtVehicleModel, txtVehiclePlate, btnCreate, txtAppointmentId, btnDelete, btnSendConfirmation, btnSendReminder]);
        Text = "Gestao de Marcacoes";
        Load += AppointmentsForm_Load;
        ((System.ComponentModel.ISupportInitialize)numHour).EndInit();
        ((System.ComponentModel.ISupportInitialize)numMinute).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridAppointments).EndInit();
        ResumeLayout(false); PerformLayout();
    }
}
