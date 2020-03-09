using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using SIevlev.ClinicApp.Interfaces.ViewModel;

namespace CIevlev.ClinicApp.ServiceImpl.Export
{
    public class PatientInvoicesWorkbook
    {
        private static readonly IList<string> Header = new ReadOnlyCollection<string>(new List<string>
        {
            "ФИО врачей",
            "Дата заказа",
            "Сумма",
            "Оплачено",
            "К оплате"
        });
        
        public string PathToFile { get; private set; }

        public PatientInvoicesWorkbook(List<PatientInvoicesViewModel> patientInvoicesViewModels)
        {
            CreateFile(patientInvoicesViewModels);
        }

        private void CreateFile(List<PatientInvoicesViewModel> patientInvoicesViewModels)
        {
            Application excelApp = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            Sheets pages = null;
            Worksheet page = null;
            try
            {
                excelApp = new Application();
                workbooks = excelApp.Workbooks;
                workbook = workbooks.Add();
                pages = workbook.Sheets;
                pages.Add();
                page = (Worksheet) pages.Item[1];

                InsertHeader(page);

                var i = 2;
                foreach (var invoices in patientInvoicesViewModels)
                {
                    String doctorFios = String.Join(", ", invoices.DoctorFios);

                    page.Cells[i, 1] = doctorFios;
                    page.Cells[i, 2] = invoices.CreateDate;
                    page.Cells[i, 3] = invoices.Price;
                    page.Cells[i, 4] = invoices.Paid;
                    page.Cells[i, 5] = invoices.Price - invoices.Paid;

                    i++;
                }

                PathToFile = Path.GetTempPath() + Guid.NewGuid() + ".xlsx";
                workbook.SaveAs(PathToFile);
            }
            finally
            {
                Marshal.ReleaseComObject(page);
                Marshal.ReleaseComObject(pages);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(workbooks);
                
                Marshal.ReleaseComObject(excelApp);
            }
        }

        private void InsertHeader(Worksheet page)
        {
            page.Cells[1, 1] = Header[0];
            page.Cells[1, 2] = Header[1];
            page.Cells[1, 3] = Header[2];
            page.Cells[1, 4] = Header[3];
            page.Cells[1, 5] = Header[4];
        }
        
        public void ClearResources()
        {
            File.Delete(PathToFile);
            PathToFile = null;
        }

        ~PatientInvoicesWorkbook()
        {
            File.Delete(PathToFile);
        }
    }
}