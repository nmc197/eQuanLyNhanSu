using System.Collections.Generic;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.System;
using EQuanLyNhanSu.ViewModel.Catalog.System;
using EQuanLyNhanSu.ViewModel.Catalog.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EQuanLyNhanSu.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState); // validator
            var resultToken = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(resultToken);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("cannot success");
            }
            return Ok();
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetUserPagingRequest([FromQuery]GetUserRequest request)
        {
            var user = await _userService.GetUserRequest(request);
            return Ok(user);
        }
    }
}