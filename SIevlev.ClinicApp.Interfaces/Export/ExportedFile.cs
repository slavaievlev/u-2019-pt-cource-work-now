using System.IO;

namespace SIevlev.ClinicApp.Interfaces.Export
{
    public interface ExportedFile
    {
        string FileName { get; set; }
        MemoryStream FileStream { get; }
    }
}