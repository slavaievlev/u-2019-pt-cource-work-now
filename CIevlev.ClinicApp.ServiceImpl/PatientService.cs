using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Interfaces.Services;
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

        public void ChangeBonus(int patientId, int newBonusQuantity)
        {
            var patient = _patientRepository.GetPatient(patientId);

            if (newBonusQuantity < 0)
            {
                patient.Bonus = 0;
            }
            else
            {
                patient.Bonus = newBonusQuantity;
            }
            
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