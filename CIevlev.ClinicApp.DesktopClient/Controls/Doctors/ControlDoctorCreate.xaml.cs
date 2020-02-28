using System;
using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Web;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Exceptions;
using SIevlev.ClinicApp.Interfaces.WebModels;

namespace CIevlev.ClinicApp.DesktopClient.Controls.Doctors
{
    public partial class ControlDoctorCreate : UserControl
    {
        private readonly IWindowContainer _hostWindow;
        
        public ControlDoctorCreate(IWindowContainer hostWindow)
        {
            InitializeComponent();

            _hostWindow = hostWindow;
        }

        private void ButtonCreateDoctor_OnClick(object sender, RoutedEventArgs e)
        {
            ValidateTextBoxes();
            
            var firstName = TextBoxFirstName.Text;
            var secondName = TextBoxSecondName.Text;
            var description = TextBoxDescription.Text;
            var priceAsString = TextBoxPrice.Text;

            var price = Convert.ToInt32(priceAsString);
            
            var newDoctorModel = new DoctorBindingModel(
                0,
                firstName,
                secondName,
                description,
                price);

            var response = ApiClient.PostRequest<ResponseModel, DoctorBindingModel>("/api/doctor/createDoctor/", newDoctorModel);

            // TODO обработать ответ в popup :)
            
            ((ControlDoctorService) _hostWindow).UpdateDoctorsList();

            Close();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ValidateTextBoxes()
        {
            var priceAsString = TextBoxPrice.Text;
            if (!int.TryParse(priceAsString, out _))
            {
                throw new ValidationException(TextBlockPrice.Name + ": должно быть число"); 
                // todo подсвечивать поле красненьким :) Когда-нибудь...
            }
        }

        private void Close()
        {
            _hostWindow.ClearContent();
        }
    }
}