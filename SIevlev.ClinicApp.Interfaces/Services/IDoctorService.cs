using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IDoctorService
    {
        DoctorViewModel CreateDoctor(DoctorBindingModel doctorBindingModel);

        DoctorViewModel UpdateDoctor(DoctorBindingModel doctorBindingModel);

        DoctorViewModel GetDoctor(int doctorId);

        void DeleteDoctor(int doctorId);
    }
}