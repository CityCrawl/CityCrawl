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

// burde hellere kun gemme informationer her, evt. først til properties i User klassen: efterfølgende i databasen
// Så hvis det går godt returnere true (dialog.ShowDialog() == true) til MainWindowViewModel:
// så kan det åbne MinProfil vinduet og lukke Opret bruger vinduet
// gentage dette princip for alle vinduerne så alle kaldes fra MainWindowViewModel