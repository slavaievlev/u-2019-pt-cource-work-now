using System;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Doctors
{
    public partial class ControlDoctorUpdate : UserControl
    {
        private readonly IWindowContainer _hostWindow;    // TODO интерфейс для контейнеров.

        private readonly DoctorViewModel _doctorViewModel;

        public ControlDoctorUpdate(IWindowContainer hostWindow, DoctorViewModel doctorViewModel)
        {
            InitializeComponent();

            _hostWindow = hostWindow;

            _doctorViewModel = doctorViewModel;
            
            TextBoxFirstName.Text = doctorViewModel.FirstName;
            TextBoxSecondName.Text = doctorViewModel.LastName;
            TextBoxDescription.Text = doctorViewModel.Description;
            TextBoxPrice.Text = doctorViewModel.Price.ToString();
        }

        private void ButtonUpdateDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            var firstName = TextBoxFirstName.Text;
            var secondName = TextBoxSecondName.Text;
            var description = TextBoxDescription.Text;
            var priceAsString = TextBoxPrice.Text;
            
            // TODO проверка данных.

            var price = Convert.ToInt32(priceAsString);
            
            var updatedDoctorModel = new DoctorBindingModel(
                _doctorViewModel.Id,
                firstName,
                secondName,
                description,
                price);

            var response = ApiClient.PutRequest<ResponseModel, DoctorBindingModel>("/api/doctor/updateDoctor/", updatedDoctorModel);

            // TODO обработать ответ в popup :)
            
            ((ControlDoctorService)_hostWindow).UpdateDoctorsList();

            Close();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            _hostWindow.ClearContent();
        }
    }
}