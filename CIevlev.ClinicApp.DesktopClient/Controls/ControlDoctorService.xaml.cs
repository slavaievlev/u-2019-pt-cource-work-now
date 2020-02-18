using System.Collections.ObjectModel;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Helpers;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlDoctorService : UserControl
    {
        public ControlDoctorService()
        {
            InitializeComponent();

            var response = ApiClient.GetRequest<ResponseModel>("/api/Doctor/GetDoctors/");
            
            var doctorsObservableCollection = new ObservableCollection<DoctorViewModel>(ResponseModelHelper.GetResultAsList<DoctorViewModel>(response));
            ListViewDoctors.ItemsSource = doctorsObservableCollection;
        }
    }
}