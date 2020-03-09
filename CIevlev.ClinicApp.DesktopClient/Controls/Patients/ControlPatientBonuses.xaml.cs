using System;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.Dtos;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Patients
{
    public partial class ControlPatientBonuses : UserControl
    {
        private readonly IHostWindow _hostWindow;
        private readonly PatientViewModel _patientViewModel;
        
        public ControlPatientBonuses(IHostWindow hostWindow, PatientViewModel patientViewModel)
        {
            InitializeComponent();
            
            _hostWindow = hostWindow;
            _patientViewModel = patientViewModel;

            TextBoxBonusQuantity.Text = _patientViewModel.Bonus.ToString();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var newBonus = Convert.ToInt32(TextBoxBonusQuantity.Text);
            ApiClient.PutRequest<ResponseModel, ChangeBonusDto>("/api/Patient/ChangeBonus/" + _patientViewModel.Id, new ChangeBonusDto(newBonus));
            
            _hostWindow.ClearContent();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ClearContent();
        }
    }
}