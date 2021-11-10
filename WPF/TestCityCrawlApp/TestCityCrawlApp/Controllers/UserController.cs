using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityCrawlApp.Models;

namespace TestCityCrawlApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public User Get(string email, string password)
        {
            if (email == "test@" && password == "test")
                return new User()
                {
                    Email = "test@",
                    Password = "test",
                    FirstName = "First Name"
                };

            throw new Exception("Bad user or password");
        }
    }
}
