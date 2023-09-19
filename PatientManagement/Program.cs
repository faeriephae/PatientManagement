using PatientManagement.BusinessLayer;
using PatientManagement.Data;
using System.Runtime.CompilerServices;

namespace PatientManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Set applicationDbContext in each AccessLayer
            ApplicationDbContext context = new ApplicationDbContext();
            LoginAccessLayer.SetContext(context);

            if (new LoginForm().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            else
            {
                //Free allocated db-associated memory.
                context.Dispose();
                Application.Exit();
            }
        }
    }
}