using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.System;
using EQuanLyNhanSu.Data.EF;
using EQuanLyNhanSu.ViewModel.Catalog.System;
using EQuanLyNhanSu.ViewModel.Catalog.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EQuanLyNhanSu.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly EQuanLyNhanSuDbContext _context;
        public UserController(IUserService userService, EQuanLyNhanSuDbContext context)
        {
            _userService = userService;
            _context = context;
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
                return BadRequest(resultToken);
            }
            return Ok(resultToken);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
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
        [HttpGet]
        public async Task<IActionResult> GetUserPagingRequest()
        {
            var user = await _userService.GetUserRequest();
            return Ok(user);
        }
    }
}