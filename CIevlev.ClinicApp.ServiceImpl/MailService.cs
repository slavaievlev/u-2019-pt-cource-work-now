using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using SIevlev.ClinicApp.Interfaces.Export;
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

        public void SendFilesToPatient(int patientId, string title, string message, List<ExportedFile> files)
        {
            var patient = _patientRepository.GetPatient(patientId);
            
            var from = new MailAddress(ServiceEmail, "Admin");
            var to = new MailAddress(patient.Email);

            var mailMessage = new MailMessage(from, to)
            {
                Subject = title,
                Body = message
            };
            foreach (var file in files)
            {
                var attachment = new Attachment(file.FileStream, new ContentType(MediaTypeNames.Text.Plain));
                attachment.ContentDisposition.FileName = file.FileName;
                mailMessage.Attachments.Add(attachment);
            }

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