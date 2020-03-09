using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using OfficeOpenXml;
using SIevlev.ClinicApp.Interfaces.Export;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.ServiceImpl.Export
{
    public class PatientInvoicesWorkbook : ExportedFile
    {
        public string FileName { get; set; }
        public MemoryStream FileStream { get; }
        
        private static readonly IList<string> Header = new ReadOnlyCollection<string>(new List<string>
        {
            "ФИО врачей",
            "Дата заказа",
            "Сумма",
            "Оплачено",
            "К оплате"
        });

        public PatientInvoicesWorkbook(string fileName, List<PatientInvoicesViewModel> patientInvoicesViewModels)
        {
            FileName = fileName;
            FileStream = new MemoryStream();
            
            CreateFile(patientInvoicesViewModels);
        }

        private void CreateFile(List<PatientInvoicesViewModel> invoices)
        {
            using (var excelPackage = new ExcelPackage(FileStream))
            {
                var page = excelPackage.Workbook.Worksheets.Add("First sheet");

                // Insert header
                int j = 1;
                foreach (var columnName in Header)
                {
                    page.Cells[1, j].Value = columnName;
                    j++;
                }
                
                // Insert data
                int i = 2;
                foreach (var invoice in invoices)
                {
                    var doctorFios = string.Join(", ", invoice.DoctorFios);

                    page.Cells[i, 1].Value = doctorFios;
                    page.Cells[i, 2].Value = invoice.CreateDate;
                    page.Cells[i, 3].Value = invoice.Price;
                    page.Cells[i, 4].Value = invoice.Paid;
                    page.Cells[i, 5].Value = invoice.Price - invoice.Paid;
                }
                
                excelPackage.Save();
                
                // Для того чтобы при работе со стримом читали записанные данные, а не то что после записанных данных.
                // (https://stackoverflow.com/questions/50033523/xceed-docx-returns-blank-document)
                FileStream.Seek(0, SeekOrigin.Begin);
            }
        }
    }
}