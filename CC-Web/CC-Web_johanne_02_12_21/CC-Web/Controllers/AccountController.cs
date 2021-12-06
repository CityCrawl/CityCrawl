using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Authorization;
using CC_Web.Models.Data;
using CC_Web.Data;
using CC_Web.Utilities;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CC_Web.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        const int BcryptWorkfactor = 10;

        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public AccountController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<BrugerDto>> Register(BrugerDto regUser)
        {
            regUser.Email = regUser.Email.ToLower();
            var emailExist = await _context.brugere.Where(u =>
            u.Email == regUser.Email).FirstOrDefaultAsync();
            if (emailExist != null)
                return BadRequest(new { errorMessage = "Email already in use" });
            Bruger user = new Bruger()
            {
                Email = regUser.Email,
                Fornavn = regUser.Fornavn,
                Efternavn = regUser.Efternavn,
                Foedselsdag = regUser.Foedselsdag
            };
            user.PwHash = HashPassword(regUser.Password, BcryptWorkfactor);
            _context.brugere.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = user.BrugerID }, GenerateToken(user));
        }

        [HttpPost("Pubcrawl")]
        public async Task<ActionResult<Bruger>> CreatePubcrawl(Pubcrawl pubcrawl)
        {
            User.Claims.Where(c => c.Type == "BrugerId")
                .Select(c => c.Value).FirstOrDefault();

            if (pubcrawl.PakkeNavn == "Pakke 1")
            {

                var bubbles = await _context.virksomheder
                .FirstOrDefaultAsync(m => m.Virksomhedsnavn == "Bubbles");

                bubbles.Pubcrawls.Add(pubcrawl);



            }
            else if (pubcrawl.PakkeNavn == "Pakke 2")
            {

            }

            _context.pubcrawls.Add(pubcrawl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPubcrawl", new { id = pubcrawl.PubcrawlId }, pubcrawl);



        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<BrugerDto>> Get(int id)
        {
            var user = await _context.brugere.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new BrugerDto();
            userDto.Email = user.Email;
            userDto.Fornavn = user.Fornavn;
            userDto.Efternavn = user.Efternavn;
            return userDto;
        }

        [HttpGet("Bruger"), AllowAnonymous]
        public async Task<ActionResult<Bruger>> Bruger(string email, string password)
        {
            //Validere om email og password findes i databasen for Bruger
            var bruger = await _context.brugere
                .FirstOrDefaultAsync(m => m.Email == email);
            if (bruger.Email != email)
            {
                throw new Exception("The user does not exist in CC-database");
            }
            var validPwd = Verify(password, bruger.PwHash);
            if (!validPwd)
            {
                throw new Exception("Incorrect user password");
            }

            return bruger;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<TokenDto>> Login(BrugerDto login)
        {
            login.Email = login.Email.ToLower();
            var user = await _context.brugere.Where(u => u.Email == login.Email)
            .FirstOrDefaultAsync();
            if (user != null)
            {
                var validPwd = Verify(login.Password, user.PwHash);
                if (validPwd)
                {
                    var token = new TokenDto();
                    token.JWT = GenerateToken(user);
                    return token;
                }
            }
            ModelState.AddModelError(string.Empty, "Forkert brugernavn eller password");
            return BadRequest(ModelState);
        }
        private string GenerateToken(Bruger user)
        {
            var claims = new Claim[]
            {
                new Claim("Email", user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Fornavn),
                new Claim("BrugerId", user.BrugerID.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var token = new JwtSecurityToken(
            new JwtHeader(new SigningCredentials(
            new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)),
            new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

