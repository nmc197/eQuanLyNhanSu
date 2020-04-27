﻿using EQuanLyNhanSu.Data.EF;
using EQuanLyNhanSu.ViewModel.Catalog.Common;
using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSu.Application.Catalog.Employee.Service
{
    public class PublicEmployeeService : IPublicEmployeeService
    {
        private readonly EQuanLyNhanSuDbContext _context;
        public PublicEmployeeService(EQuanLyNhanSuDbContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeViewModel>> GetAll()
        {
            var query = from e in _context.NhanViens
                        join i in _context.Infos on e.MaNV equals i.MaNV
                        join pb in _context.PhongBans on e.MaPb equals pb.MaPb
                        select new { e,i,pb };
            var data = await query.Select(x => new EmployeeViewModel()
            {
                MaNV = x.e.MaNV,
                TenNv = x.e.TenNv,
                GioiTinh = x.e.GioiTinh,
                ChucVu = x.e.ChucVu,
                MaPb = x.pb.MaPb,
                CMND = x.e.CMND,
                NgaySinh = x.e.NgaySinh,
                NoiSinh = x.i.NoiSinh,
                NguyenQuan = x.i.NguyenQuan,
                HKTT = x.i.HKTT,
                SDT = x.i.SDT,
                TonGiao = x.i.TonGiao,
                QuocTich = x.i.QuocTich,
                HocVan = x.i.HocVan,
                TrinhDoNgoaiNgu = x.i.TrinhDoNgoaiNgu
            }).ToListAsync();
            return data;
        }

        public Task<PagedResult<EmployeeViewModel>> GetAllByPhongBanId(GetPublicEmployeePagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}