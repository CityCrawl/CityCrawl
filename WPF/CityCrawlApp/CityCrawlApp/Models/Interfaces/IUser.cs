using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCrawlApp.Models.Interfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Birthday { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
