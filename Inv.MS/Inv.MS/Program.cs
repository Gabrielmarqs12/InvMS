using Cellar_Managment_System;
using Cellar_Managment_System.Apresentacao;
using System;
using System.Windows.Forms;

namespace Inv.MS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DotNetEnv.Env.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin formLogin = new frmLogin();

            Application.Run(formLogin);
            if (formLogin.LoginComplete)
            {
                Application.Run(new frmMenuPrincipal(formLogin.firstName));
            }
        }
    }
}
