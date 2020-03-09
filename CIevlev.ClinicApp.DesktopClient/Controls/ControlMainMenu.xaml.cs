using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Controls.Doctors;
using CIevlev.ClinicApp.DesktopClient.Controls.Patients;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlMainMenu : UserControl
    {
        private readonly IHostWindow _hostWindow;
        
        public ControlMainMenu(IHostWindow hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
        }

        private void ButtonDoctorService_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ChangeContent(new ControlDoctorService(_hostWindow));
        }

        private void ButtonPatientService_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ChangeContent(new ControlPatientService(_hostWindow));
        }
    }
}