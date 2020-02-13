using System.Collections.ObjectModel;
using System.Windows;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.DesktopClient
{
    public partial class WindowDoctorService : Window
    {
        public WindowDoctorService()
        {
            InitializeComponent();

            var doctors = new ObservableCollection<DoctorViewModel>
            {
                new DoctorViewModel(1, "Роза Фрейд", "", "Вполне ничего!!", 2000),
                new DoctorViewModel(2, "Зигмунд Савельев", "", "Отличный доктор!", 1999)
            };
            ListViewDoctors.ItemsSource = doctors;
        }
    }
}