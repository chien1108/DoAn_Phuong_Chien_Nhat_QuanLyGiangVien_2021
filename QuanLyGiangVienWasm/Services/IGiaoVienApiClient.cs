using QuanLyGiangVien.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyGiangVienWasm.Services
{
    public interface IGiaoVienApiClient
    {
        Task<List<GiaoVienRequest>> GetListGiangVien();
    }
}
