using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using CityCrawlApp.Views;

namespace CityCrawlApp.ViewModels
{
    public class OpretBrugerViewModel : BindableBase
    {
        private DelegateCommand visProfil;
        public DelegateCommand VisProfil =>
            visProfil ?? (visProfil = new DelegateCommand(ExecuteVisProfil));

        void ExecuteVisProfil()
        {
            var vmMinProfil = new MinProfilViewModel();
            var dialog = new MinProfil(vmMinProfil);

            dialog.ShowDialog();
        }
    }
}
