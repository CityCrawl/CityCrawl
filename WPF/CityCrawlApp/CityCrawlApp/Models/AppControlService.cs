using CityCrawlApp.Models.Interfaces;
using System.Windows;

namespace CityCrawlApp.Models
{
    public class AppControlService : IAppControlService
    {
        public void SetVindowVisibilityToHidden()
        {
            App.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}