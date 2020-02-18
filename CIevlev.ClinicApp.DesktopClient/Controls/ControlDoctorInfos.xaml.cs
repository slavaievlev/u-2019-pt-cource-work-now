using System.Windows.Controls;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.DesktopClient.Controls
{
    public partial class ControlDoctorInfos : UserControl
    {
        public ControlDoctorInfos(DoctorViewModel doctorViewModel)
        {
            InitializeComponent();

            TextBlockDoctorFio.Text = doctorViewModel.FirstName + " " + doctorViewModel.LastName;
            TextBlockDoctorDescription.Text = doctorViewModel.Description;
            TextBlockDoctorPrice.Text = doctorViewModel.Price.ToString();
        }
    }
}