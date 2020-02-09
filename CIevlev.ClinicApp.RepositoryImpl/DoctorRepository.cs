using System;
using System.Linq;
using SIevlev.ClinicApp.Interfaces.Exceptions;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.RepositoryImpl
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicAppContext _clinicAppContext;

        public DoctorRepository(ClinicAppContext clinicAppContext)
        {
            _clinicAppContext = clinicAppContext;
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            return _clinicAppContext.Doctors.Add(doctor);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var model = _clinicAppContext.Doctors.FirstOrDefault(d => d.Id == doctor.Id);
            if (model != null)
            {
                model.Description = doctor.Description;
                model.Price = doctor.Price;
                model.FirstName = doctor.FirstName;
                model.LastName = doctor.LastName;

                _clinicAppContext.SaveChanges();
            }
            
            throw new DoctorNotFoundException("Не найден доктор с id = " + doctor.Id);
        }

        public Doctor GetDoctor(int doctorId)
        {
            var model = _clinicAppContext.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (model != null)
            {
                return model;
            }
            
            throw new DoctorNotFoundException("Не найден доктор с id = " + doctorId);
        }

        public void DeleteDoctor(int doctorId)
        {
            var model = _clinicAppContext.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (model != null)
            {
                model.IsActive = false;
                model.DeleteAt = DateTime.Now;
            }
            
            throw new DoctorNotFoundException("Не найден доктор с id = " + doctorId);
        }
    }
}