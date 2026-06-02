using StandUp.Application.Appointments;

namespace StandUp.Presentation.WinForms;

public partial class AppointmentsForm : Form
{
    private readonly IAppointmentApiClient _api;

    public AppointmentsForm(IAppointmentApiClient api)
    {
        _api = api;
        InitializeComponent();
        ThemeManager.ApplyToForm(this);
        var header = ThemeManager.CreateHeader("Gestão de Marcações", ClientSize.Width);
        Controls.Add(header);
        header.BringToFront();
    }

    private async void AppointmentsForm_Load(object sender, EventArgs e) => await LoadGridAsync();

    private async Task LoadGridAsync()
    {
        var items = await _api.GetByDateAsync(dtDate.Value.Date, CancellationToken.None);
        gridAppointments.DataSource = items.Select(x => new
        {
            x.Id,
            x.DateTimeSlot,
            x.EmployeeNumber,
            x.EmployeeName,
            x.ClientId,
            x.ClientName,
            x.VehicleLicensePlate
        }).ToList();
    }

    private async void btnLoad_Click(object sender, EventArgs e) => await LoadGridAsync();

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtEmployeeNumber.Text, out var employeeNumber) || !int.TryParse(txtClientId.Text, out var clientId))
        {
            MessageBox.Show("ID de funcionário/cliente inválido.");
            return;
        }

        var dt = dtDate.Value.Date.AddHours((double)numHour.Value).AddMinutes((double)numMinute.Value);
        var request = new CreateAppointmentRequest(
            dt,
            employeeNumber,
            txtEmployeeName.Text,
            clientId,
            txtClientName.Text,
            txtClientPhone.Text,
            chkSmsConsent.Checked,
            txtVehicleBrand.Text,
            txtVehicleModel.Text,
            txtVehiclePlate.Text);

        try
        {
            await _api.CreateAsync(request, CancellationToken.None);
            await LoadGridAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro");
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtAppointmentId.Text, out var id))
        {
            MessageBox.Show("ID inválido.");
            return;
        }
        await _api.DeleteAsync(id, CancellationToken.None);
        await LoadGridAsync();
    }

    private async void btnSendConfirmation_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtAppointmentId.Text, out var id)) return;
        await _api.SendConfirmationAsync(id, CancellationToken.None);
        MessageBox.Show("Confirmacao enviada.");
    }

    private async void btnSendReminder_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtAppointmentId.Text, out var id)) return;
        await _api.SendReminderAsync(id, 24, CancellationToken.None);
        MessageBox.Show("Lembrete enviado.");
    }
}
