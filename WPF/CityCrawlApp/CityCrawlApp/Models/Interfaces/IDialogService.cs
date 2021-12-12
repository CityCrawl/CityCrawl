
using CityCrawlApp.ViewModels;

namespace CityCrawlApp.Models.Interfaces
{
    public interface IDialogService
    {
        bool ShowErrorDialog();

        LoginViewModel ShowLoginDialog(ICCHttpClient httpClient);

        bool ShowMinProfilDialog(string loginEmail, string loginPassword,
            ICCHttpClient httpClient, IDialogService dialogService,
                        IAppControlService appControlService);

        OpretBrugerViewModel ShowOpretBrugerDialog(ICCHttpClient httpClient);

        void ShowTilmeldPubcrawlDialog(string loggedInEmail, string loggedInPassword,
            ICCHttpClient httpClient, IDialogService dialogService, IAppControlService appControlService);
    }
}