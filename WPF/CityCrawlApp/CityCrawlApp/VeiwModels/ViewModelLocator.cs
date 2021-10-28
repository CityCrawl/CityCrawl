using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCrawlApp.VeiwModels
{
    public class ViewModelLocator
    {

        public LoginViewModel ViewModel
        {
            get { return new LoginViewModel(); }
        }
    }
}
