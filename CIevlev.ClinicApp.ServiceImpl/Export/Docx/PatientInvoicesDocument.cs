using System;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace CIevlev.ClinicApp.ServiceImpl.Export.Docx
{
    public class PatientInvoicesDocument
    {
        public string PathToFile { get; private set; }

        public PatientInvoicesDocument()
        {
            CreateFile();
        }

        private void CreateFile()
        {
            var wordApp = new Application();
            var document = wordApp.Documents.Add();
            
            var paragraph = document.Paragraphs.Add();
            var range = paragraph.Range;
            range.Text = "Hello, World!";
            range.InsertParagraphAfter();
            
            PathToFile = Path.GetTempPath() + Guid.NewGuid() + ".docx";
            document.SaveAs(PathToFile);
            document.Close();
        }

        ~PatientInvoicesDocument()
        {
            File.Delete(PathToFile);
        }
    }
}