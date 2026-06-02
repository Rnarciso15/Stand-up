namespace StandUp.Presentation.WinForms.Helpers;

public static class FormHelpers
{
    /// <summary>
    /// Desativa o botão e mostra cursor de espera enquanto a acção async corre.
    /// Captura excepções e mostra MessageBox de erro.
    /// </summary>
    public static async Task RunAsync(Button button, Func<Task> action)
    {
        button.Enabled = false;
        var prevCursor = Cursor.Current;
        Cursor.Current = Cursors.WaitCursor;
        try
        {
            await action();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Erro de comunicação com a API: {ex.Message}",
                "Erro de Ligação", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (TaskCanceledException)
        {
            MessageBox.Show("Operação excedeu o tempo limite.",
                "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!button.IsDisposed)
                button.Enabled = true;
            Cursor.Current = prevCursor;
        }
    }
}
