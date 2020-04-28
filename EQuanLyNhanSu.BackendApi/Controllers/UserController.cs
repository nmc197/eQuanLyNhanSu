﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.System;
using EQuanLyNhanSu.ViewModel.Catalog.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authencate([FromForm]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultToken =await _userService.Authencate(request);
            if(string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Cannot find user");
            }
            return Ok(new { token = resultToken });
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
    }
}