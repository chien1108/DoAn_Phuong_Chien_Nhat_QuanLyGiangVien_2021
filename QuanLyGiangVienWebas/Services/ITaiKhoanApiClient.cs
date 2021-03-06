using QuanLyGiangVien.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVienWebas.Services
{
    public interface ITaiKhoanApiClient 
    {
        Task<LoginRequest> GetUser();

        Task<List<LoginRequest>> GetAllUser();
    }
}
