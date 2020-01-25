namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IPatientService
    {
        void ChangeBonus(int patientId, int newBonusQuantity);

        void BlockPatient(int patientId);
    }
}