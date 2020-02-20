using System.Windows;
using CIevlev.ClinicApp.DesktopClient.Web;

namespace CIevlev.ClinicApp.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ApiClient.Connect();
        }
    }
}