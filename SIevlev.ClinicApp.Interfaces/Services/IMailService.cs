using System.Collections.Generic;
using SIevlev.ClinicApp.Interfaces.Export;

namespace SIevlev.ClinicApp.Interfaces.Services
{
    public interface IMailService
    {
        void SendFilesToPatient(int patientId, string title, string message, List<ExportedFile> files);
    }
}