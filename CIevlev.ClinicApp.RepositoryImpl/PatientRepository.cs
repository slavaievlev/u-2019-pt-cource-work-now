using System.Collections.Generic;
using System.Linq;
using SIevlev.ClinicApp.Interfaces.Exceptions;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.RepositoryImpl
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicAppContext _clinicAppContext;

        public PatientRepository(ClinicAppContext clinicAppContext)
        {
            _clinicAppContext = clinicAppContext;
        }

        public Patient CreatePatient(Patient patient)
        {
            _clinicAppContext.Patients.Add(patient);
            _clinicAppContext.SaveChanges();
            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            var model = _clinicAppContext.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (model != null)
            {
                model.FirstName = patient.FirstName;
                model.LastName = patient.LastName;
                model.Bonus = patient.Bonus;
                model.Phone = patient.Phone;
                model.PatientStatus = patient.PatientStatus;
                model.Password = patient.Password;

                _clinicAppContext.SaveChanges();

                return model;
            }
            
            throw new PatientNotFoundException("Не найден пациент с id = " + patient.Id);
        }

        public Patient GetPatient(int patientId)
        {
            var model = _clinicAppContext.Patients.FirstOrDefault(p => p.Id == patientId);
            if (model != null)
            {
                return model;
            }
            
            throw new PatientNotFoundException("Не найден пациент с id = " + patientId);
        }

        public List<Patient> GetPatients()
        {
            return _clinicAppContext.Patients.ToList();
        }
    }
}