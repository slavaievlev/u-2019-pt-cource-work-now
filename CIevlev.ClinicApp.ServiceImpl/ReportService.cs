using System;
using System.IO;
using Microsoft.Office.Interop.Word;
using SIevlev.ClinicApp.Interfaces.BindingModel;
using SIevlev.ClinicApp.Interfaces.Services;

namespace CIevlev.ClinicApp.ServiceImpl
{
    public class ReportService : IReportService
    {
        public byte[] GetPatientInvoicesAsByteArray(PatientInvoicesBindingModel patientInvoicesBindingModel)
        {
            string pathToFile = GetPatientInvoicesAsPhysicalPath(patientInvoicesBindingModel);
            return File.ReadAllBytes(pathToFile);
        }

        public string GetPatientInvoicesAsPhysicalPath(PatientInvoicesBindingModel patientInvoicesBindingModel)
        {
            var wordApp = new Application();
            var document = wordApp.Documents.Add();
            
            var paragraph = document.Paragraphs.Add();
            var range = paragraph.Range;
            range.Text = "Hello, World!";
            range.InsertParagraphAfter();
            
            var pathToFile = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            document.SaveAs(pathToFile);
            document.Close();

            return pathToFile;
        }

        public byte[] GetPaymentReport(PaymentReportBindingModel paymentReport)
        {
            throw new NotImplementedException();
        }
    }
}