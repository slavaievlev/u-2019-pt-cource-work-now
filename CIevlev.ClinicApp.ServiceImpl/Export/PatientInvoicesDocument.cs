using System;
using System.Collections.Generic;
using System.IO;
using SIevlev.ClinicApp.Interfaces.Export;
using SIevlev.ClinicApp.Interfaces.ViewModel;
using Xceed.Words.NET;

namespace CIevlev.ClinicApp.ServiceImpl.Export
{
    public class PatientInvoicesDocument : ExportedFile
    {
        public string FileName { get; set; }
        public MemoryStream FileStream { get; }
        
        public PatientInvoicesDocument(string fileName, List<PatientInvoicesViewModel> invoices)
        {
            FileName = fileName;
            FileStream = new MemoryStream();
            
            CreateFile(invoices);
        }

        private void CreateFile(List<PatientInvoicesViewModel> invoices)
        {
            var docx = DocX.Create(FileStream);

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

                var paragraph = docx.InsertParagraph();
                paragraph.Append(text)
                    .Font("Tames New Roman")
                    .FontSize(14);
            }

            docx.Save();

            // Для того чтобы при работе со стримом читали записанные данные, а не то что после записанных данных.
            // (https://stackoverflow.com/questions/50033523/xceed-docx-returns-blank-document)
            FileStream.Seek(0, SeekOrigin.Begin);
        }
    }
}