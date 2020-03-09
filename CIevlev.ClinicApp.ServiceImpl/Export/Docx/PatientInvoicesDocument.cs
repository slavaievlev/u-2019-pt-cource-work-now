using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.ServiceImpl.Export.Docx
{
    public class PatientInvoicesDocument
    {
        public string PathToFile { get; private set; }

        public PatientInvoicesDocument(List<PatientInvoicesViewModel> invoices)
        {
            CreateFile(invoices);
        }

        private void CreateFile(List<PatientInvoicesViewModel> invoices)
        {
            var wordApp = new Application();
            var document = wordApp.Documents.Add();

            foreach (var invoice in invoices)
            {
                var doctorsFio = string.Join(", ", invoice.DoctorFios);
                var amountPayable = invoice.Price - invoice.Paid;
                
                var text =
                    $"ФИО врачей: {doctorsFio} " + Environment.NewLine +
                    $"Дата заказа: {invoice.CreateDate} " + Environment.NewLine +
                    $"Сумма: {invoice.Price} " + Environment.NewLine +
                    $"Оплачено: {invoice.Paid} " + Environment.NewLine +
                    $"К оплате: {amountPayable} " + Environment.NewLine;
                
                var paragraph = document.Paragraphs.Add();
                var range = paragraph.Range;
                range.Text = text;
                range.InsertParagraphAfter();
            }
            
            PathToFile = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            document.SaveAs(PathToFile);
            document.Close();
            wordApp.Quit();
        }

        ~PatientInvoicesDocument()
        {
            File.Delete(PathToFile);
        }
    }
}