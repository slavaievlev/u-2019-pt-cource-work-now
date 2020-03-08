namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IMailService
    {
        void SendFileToPatient(int patientId, string title, string message, string pathToFile);
    }
}