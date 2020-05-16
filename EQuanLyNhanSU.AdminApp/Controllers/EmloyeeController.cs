using System.Net.Http;
using System.Threading.Tasks;
using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using EQuanLyNhanSU.AdminApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EQuanLyNhanSU.AdminApp.Controllers
{
    public class EmloyeeController : Controller
    {
        private readonly IEmployeeApiClient _employeeApiClient;
        public EmloyeeController(IEmployeeApiClient employeeApiClient)
        {
            _employeeApiClient = employeeApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var nhanvien = await _employeeApiClient.GetAll();
            return View(nhanvien);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _employeeApiClient.Create(request);
            if (result)
                return RedirectToAction("Index", "Home");
            return View(request);
        }
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _employeeApiClient.Update(request.MaNV, request);
            if (result)
                return RedirectToAction("Index", "Home");
            return View(request);
        }
        public async Task<IActionResult> Delete(int MaNV)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _employeeApiClient.Delete(MaNV);
            if (result)
                return RedirectToAction("Index");
            return View();
        }
    }
}