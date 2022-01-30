using loadgistix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace loadgistix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly loadgistixContext _context;

        public TokenController(IConfiguration config, loadgistixContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _userData)
        {

            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUserByEmail(_userData.Email);

                try
                {
                    if (user == null) return BadRequest("Invalid credentials");

                    bool verified = BCrypt.Net.BCrypt.Verify(_userData.Password, user.Password);

                    if (verified == false) return BadRequest("Invalid credentials");

                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var tokenNew = new JwtSecurityTokenHandler().WriteToken(token);
                    user.AccessToken = tokenNew;
                    _context.SaveChanges();
                    //_context.Entry(user).Collection(s => s.UserPermission).Load();

                    VwUser userView = await _context.VwUser.FirstOrDefaultAsync(u => u.Id == user.Id);

                    return CreatedAtAction("Login", new { id = user.Id }, new LoginResult { result = true, accessToken = tokenNew, user = userView });
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                catch (Exception e)
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest request)
        {

            if (request.Email != null && request.AccessToken != null)
            {
                var user = await GetUserByAccessToken(request.Email, request.AccessToken);

                try
                {
                    if (user == null) return BadRequest("Invalid credentials");

                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var tokenNew = new JwtSecurityTokenHandler().WriteToken(token);
                    user.AccessToken = tokenNew;
                    _context.SaveChanges();

                    VwUser userView = await _context.VwUser.FirstOrDefaultAsync(u => u.Id == user.Id);

                    return CreatedAtAction("Login", new { id = user.Id }, new LoginResult { result = true, accessToken = tokenNew, user = userView });
                    //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                catch (Exception e)
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await GetUserByEmail(email);

            try
            {
                if (user == null) return BadRequest("Invalid credentials");

                Guid guid = Guid.NewGuid();
                SendEmail(user, guid, "Loadgistix Forgot Password", "Click <a href='https://www.loadgistix.co.za/#/reset-password?id=" + guid + "'>here</a> to reset your password.");

                return CreatedAtAction("Login", new { id = user.Id }, new ProcedureResult { Result = true, Message = "Check email for reset link" });
            }
            catch (Exception e)
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var user = await GetUserByResetLink(request.Reset);

            try
            {
                if (user == null) return BadRequest("Invalid credentials");

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                _context.SaveChanges();

                return CreatedAtAction("ResetPassword", new { id = user.Id }, new ProcedureResult { Result = true, Message = "Password Updated Successfully" });
            }
            catch (Exception e)
            {
                return BadRequest("Invalid credentials");
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        private async Task<User> GetUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email);
            //return await _context.User.Include(x => x.UserPermission).ThenInclude(y => y.Permission).FirstOrDefaultAsync(u => u.Email == email);
        }

        private async Task<User> GetUserByResetLink(Guid? reset)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Reset == reset);
            //return await _context.User.Include(x => x.UserPermission).ThenInclude(y => y.Permission).FirstOrDefaultAsync(u => u.Email == email);
        }

        private async Task<User> GetUserByAccessToken(string email, string accessToken)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.AccessToken == accessToken);
            //return await _context.User.Include(x => x.UserPermission).ThenInclude(y => y.Permission).FirstOrDefaultAsync(u => u.Email == email && u.AccessToken == accessToken);
        }

        private string SendEmail(User user, Guid? guid, string subject, string body)
        {
            if (user == null)
            {
                return "";
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient smtpClient = new SmtpClient();
                    mail.From = new MailAddress("info@madservices.co.za", "Loadgistix");
                    mail.To.Add(user.Email);
                    mail.Bcc.Add("info@madservices.co.za");
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                    smtpClient.Port = 587;
                    smtpClient.Host = "mail.madservices.co.za";
                    //smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("info@madservices.co.za", "P@szw0rd");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(mail);

                    if (user != null)
                    {
                        user.Reset = guid;
                        _context.SaveChanges();
                    }

                    return "OK";
                }
                catch (Exception ex)
                {
                    return "ERROR: " + ex.Message;
                }
            }
        }
    }
}
