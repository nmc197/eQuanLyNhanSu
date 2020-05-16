using EQuanLyNhanSu.Data.EF;
using EQuanLyNhanSu.Data.Entities;
using EQuanLyNhanSu.Untilities.Exceptions;
using EQuanLyNhanSu.ViewModel.Catalog.Common;
using EQuanLyNhanSu.ViewModel.Catalog.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQuanLyNhanSu.Application.Catalog.Employee.Service
{
    public class ManagedEmployeeService : IManagedEmployeeService
    {
        private readonly EQuanLyNhanSuDbContext _context;
        public ManagedEmployeeService(EQuanLyNhanSuDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(EmployeeCreateRequest request)
        {
            var nhanvien = new NhanVien()
            {
                TenNv = request.TenNv,
                GioiTinh = request.GioiTinh,
                ChucVu = request.ChucVu,
                MaPb = request.MaPb,
                CMND = request.CMND,
                NgaySinh = request.NgaySinh,
            };
            _context.NhanViens.Add(nhanvien);
            await _context.SaveChangesAsync();
            return nhanvien.MaNV;
        }

        public async Task<int> Delete(int MaNV)
         {
            var nhanvien = await _context.NhanViens.FindAsync(MaNV);
            if (nhanvien == null) throw new EQuanLyNhanSuException($"Can not find user: {MaNV}");
            _context.NhanViens.Remove(nhanvien);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAll()
        {
            var query = from e in _context.NhanViens
                        join pb in _context.PhongBans on e.MaPb equals pb.MaPb
                        select new { e, pb };
            var data = await query.Select(x => new EmployeeViewModel()
            {
                MaNV = x.e.MaNV,
                TenNv = x.e.TenNv,
                GioiTinh = x.e.GioiTinh,
                ChucVu = x.e.ChucVu,
                MaPb = x.pb.MaPb,
                CMND = x.e.CMND,
                NgaySinh = x.e.NgaySinh,

            }).ToListAsync();
            return data;
        }
        public async Task<List<EmployeeViewModel>> GetAllByNhanVienId(int id)
        {
            var query = from e in _context.NhanViens
                        join i in _context.Infos on e.MaNV equals i.MaNV
                        join pb in _context.PhongBans on e.MaPb equals pb.MaPb
                        select new { e, i, pb };
            if (id != 0)
            {
                query = query.Where(x => x.e.MaNV == id);
            }
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
        public async Task<List<EmployeeViewModel>> GetAllEByMaPb(int ibPb)
        {
            var query = from pb in _context.PhongBans
                        join e in _context.NhanViens on pb.MaPb equals e.MaPb
                        select new { e, pb };
            if (ibPb != 0)
            {
                query = query.Where(x => x.pb.MaPb == ibPb);
            }
            var data = await query.Select(x => new EmployeeViewModel()
            {
                MaPb = x.pb.MaPb,
                TenPhongBan = x.pb.TenPhongBan,
                SDT = x.pb.SDT,
                MaNV = x.e.MaNV,
                TenNv = x.e.TenNv,
                GioiTinh = x.e.GioiTinh,
                ChucVu = x.e.ChucVu,
                CMND = x.e.CMND,
                NgaySinh = x.e.NgaySinh

            }).ToListAsync();
            return data;
        }
        public async Task<EmployeeViewModel> GetById(int MaNV)
        {
            var nhanvien = await _context.NhanViens.FindAsync(MaNV);
            var info = await _context.Infos.FirstOrDefaultAsync(x => x.MaNV == MaNV);
            var employeeViewModel = new EmployeeViewModel()
            {
                MaNV = nhanvien.MaNV,
                GioiTinh = nhanvien.GioiTinh,
                ChucVu = nhanvien.ChucVu,
                CMND = nhanvien.CMND,
                NgaySinh = nhanvien.NgaySinh,
            };
            return employeeViewModel;
        }

        public async Task<int> Update(EmployeeUpdateRequest request)
        {
            var nhanvien = await _context.NhanViens.FindAsync(request.MaNV);
            if (nhanvien == null) throw new EQuanLyNhanSuException($"Can not update user: {request.MaNV}");
            nhanvien.TenNv = request.TenNv;
            nhanvien.GioiTinh = request.GioiTinh;
            nhanvien.ChucVu = request.ChucVu;
            nhanvien.MaPb = request.MaPb;
            nhanvien.CMND = request.CMND;
            nhanvien.NgaySinh = request.NgaySinh;
            return await _context.SaveChangesAsync();
        }
    }
}
