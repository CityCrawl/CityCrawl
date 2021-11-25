using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCrawlApp.Models;
using CityCrawlApp.ViewModels;

namespace CityCrawlApp.ViewModels
{
    public class ViewModelLocator
    {

        public MainWindowViewModel ViewModel
        {
            get { return new MainWindowViewModel(new httpClient(), new DialogService(), new AppControlService()); }
        }
    }
}
