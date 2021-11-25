
using CityCrawlApp.ViewModels;

namespace CityCrawlApp.Models.Interfaces
{
    public interface IDialogService
    {
        bool ShowErrorDialog();

        LoginViewModel ShowLoginDialog(IhttpClient httpClient);

        bool ShowMinProfilDialog(string loginEmail, string loginPassword,
                        IhttpClient httpClient, IDialogService dialogService,
                        IAppControlService appControlService);

        OpretBrugerViewModel ShowOpretBrugerDialog(IhttpClient httpClient);

        void ShowTilmeldPubcrawlDialog(string loggedInEmail, string loggedInPassword,
            IhttpClient httpClient, IDialogService dialogService, IAppControlService appControlService);
    }
}