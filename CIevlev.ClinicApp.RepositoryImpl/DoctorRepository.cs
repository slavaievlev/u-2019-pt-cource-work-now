using System;
using System.Collections.Generic;
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
            var model = _clinicAppContext.Doctors.Add(doctor);
            _clinicAppContext.SaveChanges();
            return model;
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

                return model;
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

        public List<Doctor> GetDoctors()
        {
            return _clinicAppContext.Doctors.ToList();
        }

        public void DeleteDoctor(int doctorId)
        {
            var model = _clinicAppContext.Doctors.FirstOrDefault(d => d.Id == doctorId);
            if (model != null)
            {
                model.IsActive = false;
                model.DeleteAt = DateTime.Now;

                _clinicAppContext.SaveChanges();

                return;
            }
            
            throw new DoctorNotFoundException("Не найден доктор с id = " + doctorId);
        }
    }
}