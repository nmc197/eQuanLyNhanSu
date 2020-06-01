using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSU.AdminApp.Services
{
    public class EmployeeApiClient : IEmployeeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public EmployeeApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<bool> Create(EmployeeCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PostAsync($"/api/Employee/Create", httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int MaNV)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.DeleteAsync($"/api/Employee/Delete?MaNV={MaNV}");
            return  response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(int MaNV,EmployeeUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.PutAsync($"/api/Employee/Update?Manv={MaNV}",httpContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<EmployeeViewModel>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/Employee/");
            var body = await response.Content.ReadAsStringAsync();
            var nhanvien = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(body);
            return nhanvien;
        }

        public async Task<List<EmployeeViewModel>> GetById(int MaNV)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var response = await client.GetAsync($"/api/Employee/{MaNV}");
            var body = await response.Content.ReadAsStringAsync();
            var nhanvien = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(body);
            return nhanvien;
        }
    }
}
