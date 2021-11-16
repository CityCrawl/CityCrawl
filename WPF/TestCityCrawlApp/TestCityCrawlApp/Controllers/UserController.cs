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
            //database: _context.User til validering om email findes
            if (!users.ContainsKey(email))
            {
                throw new Exception("The user does not exist in CC-database");
            }

            // her skal user variablen sættes til den user i DB med denne email
            var user = users[email];

            // dette skal ikke rettes ift. DB
            if (user.Password != password)
            {
                throw new Exception("Incorrect user password");
            }

            return user;
        }

        [HttpPost("User")]
        public ActionResult CreateUser(User user)
        {
            // dette skal ikke rettes ift. DB
            if (user == null)
            {
                throw new Exception("User is null, can not be created!");
            }

            // tjek om denne email findes i DB via _context.User
            if (users.ContainsKey(user.Email))
            {
                throw new Exception("User already exist");
            }

           
            // dette skal ikke rettes ift. DB
            if (user.PubCrawls == null)
            {
                user.PubCrawls = new List<string>();
            }

            // DB: _context.Users.Add(user.Email, user), hvor Users er listen af Users
            users.Add(user.Email, user);

            return Ok();
        }

        [HttpPost("PubCrawl")]
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
