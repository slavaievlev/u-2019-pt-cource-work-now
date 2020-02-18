using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Helpers;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlDoctorService : UserControl
    {
        private readonly WindowContainer _windowContainer;
        
        public ControlDoctorService(WindowContainer windowContainer)
        {
            InitializeComponent();

            _windowContainer = windowContainer;

            ListViewDoctorsLoad();
        }

        public void ListViewDoctorsLoad()
        {
            var response = ApiClient.GetRequest<ResponseModel>("/api/Doctor/GetDoctors/");
            
            var doctorsObservableCollection = new ObservableCollection<DoctorViewModel>(ResponseModelHelper.GetResultAsList<DoctorViewModel>(response));
            ListViewDoctors.ItemsSource = doctorsObservableCollection;
        }

        private void ButtonDoctorCreate_OnClick(object sender, RoutedEventArgs e)
        {
            ContentDoctorInfos.Content = new ControlDoctorCreate(this);

            ListViewDoctorsLoad();
        }

        private void ListViewDoctors_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctorViewModel = (DoctorViewModel) ListViewDoctors.SelectedItem;
            
            // TODO почему бывает null?
            if (doctorViewModel != null)
            {
                ContentDoctorInfos.Content = new ControlDoctorInfos(doctorViewModel);
            }
        }
    }
}