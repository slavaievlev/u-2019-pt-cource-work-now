using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Patients
{
    public partial class ControlPatientInfos : UserControl
    {
        private const string BtnTextBlock = "Заблокировать!";
        private const string BtnTextUnblock = "Разаблокировать!";

        private readonly IWindowContainer _hostWindow;
        private readonly PatientViewModel _model;

        public ControlPatientInfos(IWindowContainer hostWindow, PatientViewModel model)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
            _model = model;

            UpdatePatientInfos();

            var testList = new List<PatientInvoicesViewModel>
            {
                new PatientInvoicesViewModel(
                    -1,
                    new DateTime(),
                    null,
                    567,
                    100,
                    "Createddd")
            };

            ListViewPatients.ItemsSource = new ObservableCollection<PatientInvoicesViewModel>(testList);

            SetButtonBlockContent();
        }

        private void ButtonCreateReport_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonBlock_OnClick(object sender, RoutedEventArgs e)
        {
            if (_model.PatientStatus.Equals(PatientStatus.Active.ToString()))
            {
                ApiClient.PutRequest<PatientViewModel, int>("/api/patient/blockPatient/" + _model.Id, 0);
                _model.PatientStatus = PatientStatus.Blocked.ToString();
            }
            else
            {
                ApiClient.PutRequest<PatientViewModel, int>("/api/patient/unblockPatient/" + _model.Id, 0);
                _model.PatientStatus = PatientStatus.Active.ToString();
            }

            SetButtonBlockContent();
            UpdatePatientInfos();
        }

        private void SetButtonBlockContent()
        {
            ButtonBlock.Content = _model.PatientStatus.Equals(PatientStatus.Active.ToString()) ? BtnTextBlock : BtnTextUnblock;
        }

        private void UpdatePatientInfos()
        {
            TextBlockPatientFio.Text = _model.FirstName + " " + _model.LastName;
            TextBlockPatientDescription.Text = _model.Login;
            TextBlockPatientBonus.Text = _model.Bonus.ToString();
            TextBlockPatientStatis.Text = _model.PatientStatus;
        }
    }
}