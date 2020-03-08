using System.Net;
using System.Net.Mail;
using SIevlev.ClinicApp.Interfaces.Repositories;
using SIevlev.ClinicApp.Interfaces.Services;

namespace CIevlev.ClinicApp.ServiceImpl
{
    public class MailService : IMailService
    {
        private const string ServiceEmail = "slavaievlev10@gmail.com";
        
        private readonly IPatientRepository _patientRepository;

        public MailService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void SendFileToPatient(int patientId, string title, string message, string pathToFile)
        {
            var patient = _patientRepository.GetPatient(patientId);
            
            var from = new MailAddress(ServiceEmail, "Admin");
            var to = new MailAddress(patient.Password);    // TODO wtf?

            var mailMessage = new MailMessage(from, to)
            {
                Subject = title,
                Body = message,
                Attachments =
                {
                    new Attachment(pathToFile)
                }
            };

            // TODO вынести в конфиг.
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                // TODO вынести в конфиг.
                Credentials = new NetworkCredential("slavaievlev10@gmail.com", "d2q8I92-#1!"),
                EnableSsl = true
            };
            smtpClient.Send(mailMessage);
        }
    }
}