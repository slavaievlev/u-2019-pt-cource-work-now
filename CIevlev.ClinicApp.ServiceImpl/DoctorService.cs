using System.Collections.Generic;
using System.Linq;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.ServiceImpl
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public DoctorViewModel CreateDoctor(DoctorBindingModel doctorBindingModel)
        {
            var doctor =_doctorRepository.CreateDoctor(new Doctor
            {
                FirstName = doctorBindingModel.FirstName,
                LastName = doctorBindingModel.LastName,
                Description = doctorBindingModel.Description,
                Price = doctorBindingModel.Price,
                IsActive = true
            });
            
            return new DoctorViewModel
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Description = doctor.Description,
                Price = doctor.Price
            };
        }

        public DoctorViewModel UpdateDoctor(DoctorBindingModel doctorBindingModel)
        {
            var doctor = _doctorRepository.UpdateDoctor(new Doctor
            {
                Id = doctorBindingModel.Id,
                FirstName = doctorBindingModel.FirstName,
                LastName = doctorBindingModel.LastName,
                Description = doctorBindingModel.Description,
                Price = doctorBindingModel.Price
            });
            
            return new DoctorViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Description = doctor.Description,
                Price = doctor.Price
            };
        }

        public DoctorViewModel GetDoctor(int doctorId)
        {
            var doctor = _doctorRepository.GetDoctor(doctorId);
            
            return new DoctorViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Description = doctor.Description,
                Price = doctor.Price
            };
        }

        public List<DoctorViewModel> GetDoctors()
        {
            var doctors = _doctorRepository.GetDoctors();

            return doctors.Select(doctor => new DoctorViewModel(
                    doctor.Id, 
                    doctor.FirstName, 
                    doctor.LastName, 
                    doctor.Description, 
                    doctor.Price,
                    doctor.IsActive.Value)
            ).ToList();
        }

        public void DeleteDoctor(int doctorId)
        {
            _doctorRepository.DeleteDoctor(doctorId);
        }
    }
}