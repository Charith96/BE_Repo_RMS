
using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.dto;
using conifs.rms.business.validations;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet("UserByID/{id}")]
        public async Task<ActionResult<GetUserDto>> GetUserByIdFull(string id)
        {
            var user = await _userService.GetUserByIdFull(id);



            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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

  

  

        [HttpPut("{Userid}")]
        public IActionResult UpdateUser(string Userid, PutUserDto user)
        {
            try
            {
                var validator = new DateRangeValidator();
                var result = validator.Validate(user);
                if (result.IsValid)
                {
                    _userService.UpdateUser(user, Userid);
                    return Ok(new { message = "Saved successfully" });
                }
                else
                {
                    var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
                    return BadRequest(new { errors });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userService.DeleteUser(id);
                _userService.DeleteUserCompany(id);
                _userService.DeleteUserRole(id);
                return Ok(new { message = "Deleted successfully" });
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
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
                var validator = new DateRangeValidator();
                var result = validator.Validate(userCreateDto);
                if (result.IsValid)
                {
                    _userService.CreateUser(userCreateDto);
                     return Ok(new { message = "Saved successfully" });
                }
                else
                {
                    var errors = result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
                    return BadRequest(new { errors });
                }
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
                return Ok(new { message = "added successfully" });
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

                return Ok(new { message = "added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        [HttpDelete("userCompanies/{id}")]
        public IActionResult DeleteUserCompany(string id)
        {
            try
            {
                _userService.DeleteUserCompany(id);
                return Ok(new { message = "Deleted User Companies successfully" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete("userRoles/{id}")]
        public IActionResult DeleteUserRoles(string id)
        {
            try
            {
                _userService.DeleteUserRole(id);
                return Ok(new { message = "Deleted User Companies successfully" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

    }
}
