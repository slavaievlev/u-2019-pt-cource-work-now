using System;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlDoctorCreate : UserControl
    {
        private readonly ControlDoctorService _hostWindow;    // TODO интерфейс для контейнеров.
        
        public ControlDoctorCreate(ControlDoctorService hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
        }

        private void ButtonCreateDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            var firstName = TextBoxFirstName.Text;
            var secondName = TextBoxSecondName.Text;
            var description = TextBoxDescription.Text;
            var priceAsString = TextBoxPrice.Text;
            
            // TODO проверка данных.

            var price = Convert.ToInt32(priceAsString);
            
            var newDoctorModel = new DoctorBindingModel(
                0,
                firstName,
                secondName,
                description,
                price);

            var response = ApiClient.PostRequest<ResponseModel, DoctorBindingModel>("/api/doctor/createDoctor/", newDoctorModel);

            // TODO обработать ответ в popup :)
            
            _hostWindow.ListViewDoctorsLoad();

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