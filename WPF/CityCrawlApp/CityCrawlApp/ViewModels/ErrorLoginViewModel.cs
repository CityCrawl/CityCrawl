using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using CityCrawlApp.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace CityCrawlApp.ViewModels
{
    public class ErrorLoginViewModel: BindableBase
    {

        private DelegateCommand closeBtn;
        public DelegateCommand CloseBtn =>
            closeBtn ?? (closeBtn = new DelegateCommand(ExecuteCloseBtn));

        public Action<bool> CloseDialog { get; set; }

        void ExecuteCloseBtn()
        {
            // Nobody uses this value, so leave it false
            CloseDialog(false);
        }
    }
}
