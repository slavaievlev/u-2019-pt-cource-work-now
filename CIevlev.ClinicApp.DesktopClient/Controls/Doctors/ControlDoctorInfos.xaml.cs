using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Doctors
{
    public partial class ControlDoctorInfos : UserControl
    {
        private readonly IWindowContainer _hostWindow;
        private readonly DoctorViewModel _doctorViewModel;
        
        public ControlDoctorInfos(IWindowContainer hostWindow, DoctorViewModel doctorViewModel)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
            _doctorViewModel = doctorViewModel;

            TextBlockDoctorFio.Text = doctorViewModel.FirstName + " " + doctorViewModel.LastName;
            TextBlockDoctorDescription.Text = doctorViewModel.Description;
            TextBlockDoctorPrice.Text = doctorViewModel.Price.ToString();
        }

        private void ButtonDoctorUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ChangeContent(new ControlDoctorUpdate(_hostWindow, _doctorViewModel));
        }

        private void ButtonDoctorDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var doctorId = _doctorViewModel.Id;
            ApiClient.DelRequest<ResponseModel>("/api/doctor/deleteDoctor/" + doctorId);
            
            // TODO использовать event
            ((ControlDoctorService) _hostWindow).UpdateDoctorsList();
            _hostWindow.ClearContent();
        }
    }
}