namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IMailService
    {
        void SendMessageToPatient(int patientId, string message, string attachment);
    }
}