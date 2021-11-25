
using CityCrawlApp.Models.Interfaces;
using CityCrawlApp.ViewModels;
using CityCrawlApp.Views;


namespace CityCrawlApp.Models
{
    public class DialogService: IDialogService
    {
        public bool ShowErrorDialog()
        {
            var vmErrorLogin = new ErrorLoginViewModel();
            var dialogErrorLogin = new LoginError(vmErrorLogin);
            return dialogErrorLogin.ShowDialog() == true;
        }

        public LoginViewModel ShowLoginDialog(IhttpClient httpClient)
        {
            var vmLogin = new LoginViewModel(httpClient, this);
            var dialog = new Login(vmLogin);
            if (dialog.ShowDialog() == true)
                return vmLogin;
            else
            {
                return null;
            }
        }

        public bool ShowMinProfilDialog(string loginEmail, string loginPassword,
                                    IhttpClient httpClient, IDialogService dialogService,
                                    IAppControlService appControlService)
        {
            var vmMinProfil = new MinProfilViewModel(loginEmail, loginPassword, httpClient, dialogService, appControlService);
            var dialogMinProfil = new MinProfil(vmMinProfil);

            return dialogMinProfil.ShowDialog() == true;
        }

        public OpretBrugerViewModel ShowOpretBrugerDialog(IhttpClient httpClient)
        {
            var vmOpretBruger = new OpretBrugerViewModel(httpClient);
            var dialog = new OpretBruger(vmOpretBruger);
            if (dialog.ShowDialog() == true)
                return vmOpretBruger;
            else
            {
                return null;
            }
        }

        public void ShowTilmeldPubcrawlDialog(string loggedInEmail, string loggedInPassword,
                                        IhttpClient httpClient, IDialogService dialogService, IAppControlService appControlService)
        {
            var vmTilmeld = new TilmeldPubcrawlViewModel(loggedInEmail, loggedInPassword, httpClient, dialogService, appControlService);
            var dialog = new TilmeldPubcrawl(vmTilmeld);

            dialog.ShowDialog();
        }
    }
}