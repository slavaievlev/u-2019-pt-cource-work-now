using System.Windows;
using System.Windows.Controls;
using CIevlev.ClinicApp.DesktopClient.Controls;

namespace CIevlev.ClinicApp.DesktopClient
{
    public partial class WindowContainer : Window
    {
        private UserControl _previousContent = null;
        
        public WindowContainer()
        {
            InitializeComponent();
            
            ContentContainer.Content = new ControlMainMenu(this);
        }

        public void ChangeContent(UserControl newContent)
        {
            _previousContent = (UserControl) ContentContainer.Content;
            ContentContainer.Content = newContent;
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_previousContent != null)
            {
                ContentContainer.Content = _previousContent;
            }
        }
    }
}