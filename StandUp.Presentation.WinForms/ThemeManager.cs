namespace StandUp.Presentation.WinForms;

public static class ThemeManager
{
    // Paleta dark automóvel
    public static readonly Color Background  = Color.FromArgb(0x1A, 0x1A, 0x2E);
    public static readonly Color Surface     = Color.FromArgb(0x16, 0x21, 0x3E);
    public static readonly Color Card        = Color.FromArgb(0x0F, 0x34, 0x60);
    public static readonly Color Accent      = Color.FromArgb(0xE9, 0x45, 0x60);
    public static readonly Color AccentAlt   = Color.FromArgb(0xFF, 0x6B, 0x35);
    public static readonly Color TextPrimary = Color.FromArgb(0xE8, 0xE8, 0xE8);
    public static readonly Color TextMuted   = Color.FromArgb(0xA0, 0xA0, 0xB0);
    public static readonly Color Success     = Color.FromArgb(0x4C, 0xAF, 0x50);
    public static readonly Color Danger      = Color.FromArgb(0xF4, 0x43, 0x36);
    public static readonly Color InputBack   = Color.FromArgb(0x0D, 0x1B, 0x38);
    public static readonly Color GridAlt     = Color.FromArgb(0x12, 0x1D, 0x3A);

    private static readonly Font DefaultFont  = new("Segoe UI", 9f);
    private static readonly Font HeaderFont   = new("Segoe UI", 10f, FontStyle.Bold);
    private static readonly Font TitleFont    = new("Segoe UI", 22f, FontStyle.Bold);

    public static void ApplyToForm(Form form)
    {
        form.BackColor = Background;
        form.ForeColor = TextPrimary;
        form.Font = DefaultFont;

        ApplyToControls(form.Controls);
    }

    private static void ApplyToControls(Control.ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            switch (c)
            {
                case Button btn:
                    StyleButton(btn);
                    break;
                case TextBox tb:
                    StyleTextBox(tb);
                    break;
                case Label lbl:
                    StyleLabel(lbl);
                    break;
                case DataGridView dgv:
                    StyleDataGrid(dgv);
                    break;
                case Panel panel:
                    panel.BackColor = Surface;
                    panel.ForeColor = TextPrimary;
                    ApplyToControls(panel.Controls);
                    break;
                case GroupBox gb:
                    gb.BackColor = Surface;
                    gb.ForeColor = AccentAlt;
                    gb.Font = HeaderFont;
                    ApplyToControls(gb.Controls);
                    break;
                case CheckBox chk:
                    chk.BackColor = Color.Transparent;
                    chk.ForeColor = TextPrimary;
                    break;
                case DateTimePicker dtp:
                    dtp.BackColor = InputBack;
                    dtp.ForeColor = TextPrimary;
                    dtp.CalendarForeColor = TextPrimary;
                    dtp.CalendarMonthBackground = Surface;
                    dtp.CalendarTitleBackColor = Card;
                    dtp.CalendarTitleForeColor = Accent;
                    break;
                case NumericUpDown nud:
                    nud.BackColor = InputBack;
                    nud.ForeColor = TextPrimary;
                    break;
                case ComboBox cbo:
                    cbo.BackColor = InputBack;
                    cbo.ForeColor = TextPrimary;
                    break;
                default:
                    c.BackColor = Background;
                    c.ForeColor = TextPrimary;
                    break;
            }

            if (c.HasChildren)
                ApplyToControls(c.Controls);
        }
    }

    public static void StyleButton(Button btn)
    {
        var text = btn.Text.ToLowerInvariant();
        bool isDanger  = text.Contains("elimin") || text.Contains("apagar") || text.Contains("remov");
        bool isSuccess = text.Contains("criar") || text.Contains("registar") || text.Contains("gerar");

        Color back = isDanger ? Danger : isSuccess ? Accent : Card;

        btn.BackColor = back;
        btn.ForeColor = TextPrimary;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderColor = isDanger ? Danger : Accent;
        btn.FlatAppearance.BorderSize = 1;
        btn.FlatAppearance.MouseOverBackColor = LightenColor(back, 20);
        btn.FlatAppearance.MouseDownBackColor = DarkenColor(back, 20);
        btn.Cursor = Cursors.Hand;
        btn.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
    }

    public static void StyleTextBox(TextBox tb)
    {
        tb.BackColor = InputBack;
        tb.ForeColor = TextPrimary;
        tb.BorderStyle = BorderStyle.FixedSingle;
    }

    public static void StyleLabel(Label lbl)
    {
        lbl.BackColor = Color.Transparent;
        lbl.ForeColor = TextPrimary;
    }

    public static void StyleDataGrid(DataGridView dgv)
    {
        dgv.BackgroundColor = Surface;
        dgv.GridColor = Card;
        dgv.BorderStyle = BorderStyle.None;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.ReadOnly = true;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;

        dgv.DefaultCellStyle.BackColor = Surface;
        dgv.DefaultCellStyle.ForeColor = TextPrimary;
        dgv.DefaultCellStyle.SelectionBackColor = Accent;
        dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
        dgv.DefaultCellStyle.Font = DefaultFont;

        dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlt;
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimary;
        dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Accent;

        dgv.ColumnHeadersDefaultCellStyle.BackColor = Card;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = AccentAlt;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Card;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.EnableHeadersVisualStyles = false;

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    // Cria um Panel de cabeçalho com título para uma form
    public static Panel CreateHeader(string title, int formWidth)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 52,
            BackColor = Surface,
            Padding = new Padding(16, 0, 0, 0)
        };

        var lbl = new Label
        {
            Text = title,
            Font = new Font("Segoe UI", 14f, FontStyle.Bold),
            ForeColor = Accent,
            AutoSize = true,
            Location = new Point(16, 12)
        };

        var accent = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 2,
            BackColor = Accent
        };

        panel.Controls.Add(lbl);
        panel.Controls.Add(accent);
        return panel;
    }

    // Helpers de cor
    private static Color LightenColor(Color c, int amount) =>
        Color.FromArgb(
            Math.Min(255, c.R + amount),
            Math.Min(255, c.G + amount),
            Math.Min(255, c.B + amount));

    private static Color DarkenColor(Color c, int amount) =>
        Color.FromArgb(
            Math.Max(0, c.R - amount),
            Math.Max(0, c.G - amount),
            Math.Max(0, c.B - amount));
}
