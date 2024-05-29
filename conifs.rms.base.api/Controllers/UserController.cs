
using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using conifs.rms.dto;
using conifs.rms.dto.Users;
namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "An error occurred while retrieving all users.",
                    Details = ex.StackTrace
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{Userid}")]
        public IActionResult GetUserById(string Userid)
        {
            try
            {
                var user = _userService.GetUserById(Userid);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
             
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserTable newUser)
        {
            try
            {
                _userService.AddUser(newUser);

                return CreatedAtAction(nameof(GetUserById), new { Userid = newUser.Userid }, newUser);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        [HttpPut("{Userid}")]
        public IActionResult UpdateUser(string Userid, PutUserDto user)
        {
            try
            {
               
                _userService.UpdateUser(user, Userid);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        [HttpDelete("{Userid}")]
        public IActionResult DeleteUser(string Userid)
        {
            try
            {
                _userService.DeleteUser(Userid);
                return NoContent();
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("user-companies/{Userid}")]
        public IActionResult GetUserCompanies(string Userid)
        {
            try
            {
                var userCompanies = _userService.GetUserCompanies(Userid);
                return Ok(userCompanies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user-roles/{Userid}")]
        public IActionResult GetUserRoles(string Userid)
        {
            try
            {
                var userRoles = _userService.GetUserRoles(Userid);
                return Ok(userRoles);
            }
            catch (Exception ex)
            {
            
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser(CreateUserDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _userService.CreateUser(userCreateDto);

                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        [HttpPost("create-UserCompany")]
        public IActionResult CreateUserCompany(CreateUserCompanyDto userCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _userService.CreateUserCompany(userCompany);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        [HttpPost("create-UserRole")]
        public IActionResult CreateUserRole(CreateUserRoleDto userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _userService.CreateUserRole(userRole);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

    }
}
