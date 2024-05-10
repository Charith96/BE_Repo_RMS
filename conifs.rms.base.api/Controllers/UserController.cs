using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
           
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            try
            {
                var user = _userService.GetUserById(id);
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

                return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserCode }, newUser);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, UserTable user)
        {
            try
            {
                if (id != user.UserCode.ToString())
                {
                    return BadRequest();
                }

                _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
         
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("user-companies/{userCode}")]
        public IActionResult GetUserCompanies(string userCode)
        {
            try
            {
                var userCompanies = _userService.GetUserCompanies(userCode);
                return Ok(userCompanies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user-roles/{userCode}")]
        public IActionResult GetUserRoles(string userCode)
        {
            try
            {
                var userRoles = _userService.GetUserRoles(userCode);
                return Ok(userRoles);
            }
            catch (Exception ex)
            {
            
                return StatusCode(500, "Internal Server Error");
            }
        }
       

    }
}
