using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCrawlApp.Models.Interfaces
{
    public interface IhttpClient
    {
        User HttpClientGetUserFromServer(string email, string password);
        public void HttpClientCreateUser(User user);
        public void HttpClientAddPubCrawls(NewPubcrawlRequest pubcrawl);
    }
}
