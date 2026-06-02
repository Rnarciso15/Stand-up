using StandUp.Application.Appointments;
using StandUp.Presentation.WinForms.Helpers;

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

    private async void AppointmentsForm_Load(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnLoad, LoadGridAsync);
    }

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

    private async void btnLoad_Click(object sender, EventArgs e)
    {
        await FormHelpers.RunAsync(btnLoad, LoadGridAsync);
    }

    private async void btnCreate_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtEmployeeNumber.Text, "Nº Funcionário", out var employeeNumber),
                FormValidator.PositiveInt(txtClientId.Text, "ID Cliente", out var clientId),
                FormValidator.Required(txtEmployeeName.Text, "Nome do Funcionário"),
                FormValidator.Required(txtClientName.Text, "Nome do Cliente"),
                FormValidator.Required(txtVehiclePlate.Text, "Matrícula do Veículo")))
            return;

        await FormHelpers.RunAsync(btnCreate, async () =>
        {
            var dt = dtDate.Value.Date
                .AddHours((double)numHour.Value)
                .AddMinutes((double)numMinute.Value);

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

            await _api.CreateAsync(request, CancellationToken.None);
            await LoadGridAsync();
        });
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtAppointmentId.Text, "ID", out var id)))
            return;

        await FormHelpers.RunAsync(btnDelete, async () =>
        {
            await _api.DeleteAsync(id, CancellationToken.None);
            await LoadGridAsync();
        });
    }

    private async void btnSendConfirmation_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtAppointmentId.Text, "ID", out var id)))
            return;

        await FormHelpers.RunAsync(btnSendConfirmation, async () =>
        {
            await _api.SendConfirmationAsync(id, CancellationToken.None);
            MessageBox.Show("Confirmação enviada.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }

    private async void btnSendReminder_Click(object sender, EventArgs e)
    {
        if (!FormValidator.ShowErrors(
                FormValidator.PositiveInt(txtAppointmentId.Text, "ID", out var id)))
            return;

        await FormHelpers.RunAsync(btnSendReminder, async () =>
        {
            await _api.SendReminderAsync(id, 24, CancellationToken.None);
            MessageBox.Show("Lembrete enviado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        });
    }
}
