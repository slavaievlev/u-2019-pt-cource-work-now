using System.Windows.Controls;

namespace CIevlev.ClinicApp.DesktopClient
{
    public interface IWindowContainer
    {
        void ChangeContent(UserControl userControl);

        void ClearContent();
    }
}