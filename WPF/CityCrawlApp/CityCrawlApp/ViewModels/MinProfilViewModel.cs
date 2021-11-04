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
    public class MinProfilViewModel : BindableBase
    {
        private DelegateCommand tilmeldPubcrawl;
        public DelegateCommand TilmeldPubcrawl =>
            tilmeldPubcrawl ?? (tilmeldPubcrawl = new DelegateCommand(ExecuteTilmeldPubcrawl));

        void ExecuteTilmeldPubcrawl()
        {
            var vmTilmeld = new TilmeldPubcrawlViewModel();
            var dialog = new TilmeldPubcrawl(vmTilmeld);

            dialog.ShowDialog();
        }
    }
}
