using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using CityCrawlApp.Models;

namespace TestCityCrawlApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        // får fat i User via string, denne som skal skiftes ud med databasen
        private static Dictionary<string, User> users = new Dictionary<string, User>();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public User GetUser(string email, string password)
        {
            if (!users.ContainsKey(email))
            {
                throw new Exception("The user does not exist in CC-database");
            }

            var user = users[email];

            if (user.Password != password)
            {
                throw new Exception("Incorrect user password");
            }

            return user;
        }

        [HttpPost("CreateUser")]
        public ActionResult CreateUser(User user)
        {
            if (user == null)
            {
                throw new Exception("User is null, can not be created!");
            }

            if (users.ContainsKey(user.Email))
            {
                throw new Exception("User already exist");
            }

            // tjek om de restede felter er tomme
            if (user.PubCrawls == null)
            {
                user.PubCrawls = new List<string>();
            }

            users.Add(user.Email, user);

            return Ok();
        }

        [HttpPost("AddPubCrawl")]
        public ActionResult AddPubCrawl(NewPubcrawlRequest request)
        {
         
            if (!users.ContainsKey(request.Email))
            {
                throw new Exception("The user does not exist in CC-database");
            }

            users[request.Email].PubCrawls.Add(request.Pubcrawl);
            
            return Ok();
        }

    }
}
