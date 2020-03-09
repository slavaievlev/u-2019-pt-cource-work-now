using System.Windows.Controls;

namespace CIevlev.ClinicApp.DesktopClient
{
    public interface IHostWindow
    {
        void ChangeContent(UserControl userControl);

        void ClearContent();
    }
}