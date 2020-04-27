using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EQuanLyNhanSu.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IPublicEmployeeService _publicEmployeeService;
        public EmployeeController(IPublicEmployeeService publicEmployeeService)
        {
            _publicEmployeeService = publicEmployeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nhanvien = await _publicEmployeeService.GetAll();
            return Ok(nhanvien);
        }
    }
}