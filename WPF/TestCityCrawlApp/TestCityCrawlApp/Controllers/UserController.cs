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

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday,
                Email = user.Email,
                Password = user.Password
            };

            return newUser;
        }

    }
}
