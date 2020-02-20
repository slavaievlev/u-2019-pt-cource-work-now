using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Controls.Doctors;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlMainMenu : UserControl
    {
        private readonly IWindowContainer _hostWindow;
        
        public ControlMainMenu(IWindowContainer hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
        }

        private void ButtonDoctorService_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ChangeContent(new ControlDoctorService(_hostWindow));
        }
    }
}