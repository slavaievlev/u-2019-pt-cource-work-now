﻿using System.Collections.ObjectModel;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Helpers;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Patients
{
    public partial class ControlPatientService : UserControl, IWindowContainer
    {
        private readonly IWindowContainer _hostWindow;
        
        public ControlPatientService(IWindowContainer hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;

            UpdatePatientList();
        }

        private void ListViewPatients_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var doctorViewModel = (PatientViewModel) ListViewPatients.SelectedItem;
            
            // TODO почему бывает null?
            if (doctorViewModel != null)
            {
                // ChangeContent(new ControlDoctorInfos(this, doctorViewModel));
            }
        }
        
        public void ChangeContent(UserControl newContent)
        {
            ContentPatientInfos.Content = newContent;
        }
        
        public void ClearContent()
        {
            ContentPatientInfos.Content = null;
        }

        private void UpdatePatientList()
        {
            var response = ApiClient.GetRequest<ResponseModel>("/api/Patient/GetPatients/");

            var doctorsList = ResponseModelHelper.GetResultAsList<PatientViewModel>(response);
            var doctorsObservableCollection = new ObservableCollection<PatientViewModel>(doctorsList);
            ListViewPatients.ItemsSource = doctorsObservableCollection;
        }
    }
}