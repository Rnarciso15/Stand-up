using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Stand_up
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Bootstrap account for local access (idempotent: ignored if already exists).
            try
            {
                ApiClient.RegisterUser(2001, "Utilizador Teste", "teste", false, "Vendedor");
            }
            catch
            {
                // Ignore bootstrap failures (API offline / already exists).
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form5());
        }
    }
}
