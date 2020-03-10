using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CIevlev.ClinicApp.DesktopClient.Helpers;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.Dtos;
using SIevlev.ClinicApp.Interfaces.Enums;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Patients
{
    public partial class ControlPatientInfos : UserControl
    {
        private const string BtnTextBlock = "Заблокировать!";
        private const string BtnTextUnblock = "Разаблокировать!";

        private readonly IHostWindow _hostWindow;
        private readonly PatientViewModel _model;

        public ControlPatientInfos(IHostWindow hostWindow, PatientViewModel model)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
            _model = model;

            UpdatePatientInfos();

            var response = ApiClient.GetRequest<ResponseModel>("/api/Patient/GetAllInvoices/" + _model.Id);
            var invoices = ResponseModelHelper.GetResultAsList<PatientInvoicesViewModel>(response);
            ListViewPatients.ItemsSource = new ObservableCollection<PatientInvoicesViewModel>(invoices);

            SetButtonBlockContent();
        }

        private void ButtonCreateReport_OnClick(object sender, RoutedEventArgs e)
        {
            var isFail = false;
            try
            {
                ApiClient.PostRequest<ResponseModel, PatientInvoicesReportDto>("/api/Patient/sendPatientInvoicesToEmail/",
                    new PatientInvoicesReportDto
                    {
                        DocumentType = DocumentType.Docx,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        PatientId = _model.Id
                    });
            }
            catch (Exception ex)
            {
                isFail = true;
            }

            if (isFail)
            {
                ButtonCreateReport.Content = "Ошибка при отправке счета! Повторить?";
                ButtonCreateReport.Background = Brushes.Red;
            }
            else
            {
                ButtonCreateReport.Content = "Счет отправлен!";
                ButtonCreateReport.Background = Brushes.LightGreen;
            }
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
            TextBlockPatientBonusPercent.Text = _model.BonusPercent.ToString();
            TextBlockPatientStatis.Text = _model.PatientStatus;
        }

        private void ButtonChangeBonus_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ChangeContent(new ControlPatientBonuses(_hostWindow, _model));
        }
    }
}