
using CityCrawlApp.Models.Interfaces;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Views;


namespace CityCrawlApp.Models
{
    public class DialogService: IDialogService
    {
        public void ShowErrorDialog()
        {
            var vmErrorLogin = new ErrorLoginViewModel();
            var dialogErrorLogin = new LoginError(vmErrorLogin);
            dialogErrorLogin.ShowDialog();
        }
    }
}