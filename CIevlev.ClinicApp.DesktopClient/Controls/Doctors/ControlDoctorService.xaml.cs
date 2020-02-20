using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Helpers;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Doctors
{
    public partial class ControlDoctorService : UserControl, IWindowContainer
    {
        private readonly IWindowContainer _hostWindow;
        
        public ControlDoctorService(IWindowContainer hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;

            UpdateDoctorsList();
        }

        public void UpdateDoctorsList()
        {
            var response = ApiClient.GetRequest<ResponseModel>("/api/Doctor/GetDoctors/");

            var doctorsList = ResponseModelHelper.GetResultAsList<DoctorViewModel>(response)
                .Where(doctor => doctor.IsActive).ToList();
            var doctorsObservableCollection = new ObservableCollection<DoctorViewModel>(doctorsList);
            ListViewDoctors.ItemsSource = doctorsObservableCollection;
        }

        private void ButtonDoctorCreate_OnClick(object sender, RoutedEventArgs e)
        {
            ChangeContent(new ControlDoctorCreate(this));

            UpdateDoctorsList();
        }

        private void ListViewDoctors_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctorViewModel = (DoctorViewModel) ListViewDoctors.SelectedItem;
            
            // TODO почему бывает null?
            if (doctorViewModel != null)
            {
                ChangeContent(new ControlDoctorInfos(this, doctorViewModel));
            }
        }

        public void ChangeContent(UserControl newContent)
        {
            ContentDoctorInfos.Content = newContent;
        }

        public void ClearContent()
        {
            ContentDoctorInfos.Content = null;
        }
    }
}