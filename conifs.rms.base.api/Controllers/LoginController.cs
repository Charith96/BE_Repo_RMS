using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.dto.Admin;
using conifs.rms.data.entities;
using conifs.rms.data;
using conifs.rms.dto.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(ApplicationDbContext context, IConfiguration configuration)
        {

            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);

                if (admin == null)
                {
                    var user = await _context.User.FirstOrDefaultAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
                    if (user == null)
                    {
                        return NotFound("User not found");
                    }

                    // Generate token for the normal user
                    var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email", user.Email.ToString())
            };

                    var userRoles = await _context.UserRole
                        .Where(x => x.Userid == user.Userid)
                        .Select(x => x.RoleId)
                        .ToListAsync();

                    if (!userRoles.Any())
                    {
                        return NotFound("User roles not found");
                    }

                    var roleCodes = userRoles.ToHashSet(); // Using HashSet for quick lookup

                    var rolePrivileges = await _context.RolePrivileges
                        .Where(x => roleCodes.Contains(x.RoleCode))
                        .Select(x => x.PrivilegeCode)
                        .ToListAsync();

                    if (!rolePrivileges.Any())
                    {
                        return NotFound("Role privileges not found");
                    }

                    var privilegeNames = await _context.Privileges
                        .Where(x => rolePrivileges.Contains(x.PrivilegeCode))
                        .Select(x => x.PrivilegeName)
                        .ToListAsync();

                    if (!privilegeNames.Any())
                    {
                        return NotFound("Privileges not found");
                    }

                    if (privilegeNames.Any())
                    {
                        var privilegesString = string.Join(",", privilegeNames);
                        claims.Add(new Claim("Privileges", privilegesString)); // Custom claim for privileges
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                     _configuration["Jwt:Audience"],
                                                     claims,
                                                     expires: DateTime.UtcNow.AddMinutes(60),
                                                     signingCredentials: creds);

                    var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { Token = tokenValue, User = new { user.FirstName, user.LastName, user.Email }, priv = privilegeNames });
                }

                // Generate token for the admin user
                var claimsAdmin = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Role", "Admin"),
            new Claim("Email", admin.Email.ToString())
        };

                var keyAdmin = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credsAdmin = new SigningCredentials(keyAdmin, SecurityAlgorithms.HmacSha256);
                var tokenAdmin = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                 _configuration["Jwt:Audience"],
                                                 claimsAdmin,
                                                 expires: DateTime.UtcNow.AddMinutes(60),
                                                 signingCredentials: credsAdmin);

                var tokenValueAdmin = new JwtSecurityTokenHandler().WriteToken(tokenAdmin);

                return Ok(new { Token = tokenValueAdmin, User = new { admin.FirstName, admin.LastName, admin.Email } });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
    }
