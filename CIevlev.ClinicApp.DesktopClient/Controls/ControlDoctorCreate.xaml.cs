using System;
using System.Windows;
using System.Windows.Controls;
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

            ResponseModel response = ApiClient.PostRequest<ResponseModel, DoctorBindingModel>("/api/doctor/createDoctor/", newDoctorModel);

            _hostWindow.ListViewDoctorsLoad();
            
            _hostWindow.ContentDoctorInfos.Content = null;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _hostWindow.ContentDoctorInfos.Content = null;
        }
    }
}