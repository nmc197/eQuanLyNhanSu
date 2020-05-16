using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQuanLyNhanSu.Application.Catalog.Employee;
using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EQuanLyNhanSu.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IManagedEmployeeService _manageEmployeeService;
        public EmployeeController(IManagedEmployeeService manageEmployeeService)
        {
            _manageEmployeeService = manageEmployeeService;
        }
        //get all nhanvien
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nhanvien = await _manageEmployeeService.GetAll();
            return Ok(nhanvien);
        }
    
        // get all nhan vien by ma phong ban
        [HttpGet("idPb")]
        public async Task<IActionResult> GetAllEByMaPb([FromQuery]int idPb)
        {
            var phongban = await _manageEmployeeService.GetAllEByMaPb(idPb);
            return Ok(phongban);
        }
        //get by MaNV
        [HttpGet("id")]
        public async Task<IActionResult> GetAllByNhanVienId([FromQuery]int id)
        {
            var nhanvien = await _manageEmployeeService.GetAllByNhanVienId(id);
            return Ok(nhanvien);
        }
        //getbyid
        [HttpGet("{MaNV}")]
        public async Task<IActionResult> GetById(int MaNV)
        {
            var nhanvien = await _manageEmployeeService.GetById(MaNV);
            if (nhanvien == null)
                return BadRequest("can not find nhan vien");
            return Ok(nhanvien);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]EmployeeCreateRequest request)
        {
            var MaNV = await _manageEmployeeService.Create(request);
            if (MaNV == 0)
                return BadRequest();
            var nhanvien = await _manageEmployeeService.GetById(MaNV);
            return CreatedAtAction(nameof(GetById), new { id = MaNV } ,nhanvien);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]EmployeeUpdateRequest request)
        {
            var affected = await _manageEmployeeService.Update(request);
            if (affected == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int MaNV)
        {
            var delete = await _manageEmployeeService.Delete(MaNV);
            if (delete == 0)
                return BadRequest();
            return Ok();
        }
    }
}