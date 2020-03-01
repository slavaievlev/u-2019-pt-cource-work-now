using System.Collections.Generic;
using System.Linq;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Interfaces.Services;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using SIevlev.ClinicApp.Models;

namespace CIevlev.ClinicApp.ServiceImpl
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public PatientViewModel CreatePatient(PatientBindingModel patientBindingModel)
        {
            var model = new Patient
            {
                FirstName = patientBindingModel.FirstName,
                LastName = patientBindingModel.LastName,
                Login = patientBindingModel.Login,
                Bonus = 0,
                Password = patientBindingModel.Password,    // TODO шифровать!!!!!!!!!!!!!!!!
                PatientStatus = PatientStatus.Active,
                Phone = patientBindingModel.Phone
            };

            _patientRepository.CreatePatient(model);

            return new PatientViewModel
            {
                Id = model.Id,
                Login = model.Login,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Bonus = model.Bonus,
                PatientStatus = model.PatientStatus.ToString(),
                Phone = model.Phone
            };
        }

        public PatientViewModel GetPatient(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            return new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Bonus = patient.Bonus,
                Login = patient.Login,
                PatientStatus = patient.PatientStatus.ToString(),
                Phone = patient.Phone
            };
        }

        public List<PatientViewModel> GetPatients()
        {
            var patients = _patientRepository.GetPatients();

            return patients.Select(patient => new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Bonus = patient.Bonus,
                Login = patient.Login,
                PatientStatus = patient.PatientStatus.ToString(),
                Phone = patient.Phone
            }).ToList();
        }

        public void ChangeBonus(int patientId, int newBonusQuantity)
        {
            var patient = _patientRepository.GetPatient(patientId);

            patient.Bonus = newBonusQuantity < 0 ? 0 : newBonusQuantity;
            
            _patientRepository.UpdatePatient(patient);
        }

        public void BlockPatient(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            patient.PatientStatus = PatientStatus.Blocked;

            _patientRepository.UpdatePatient(patient);
        }
    }
}