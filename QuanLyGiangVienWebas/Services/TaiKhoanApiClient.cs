using QuanLyGiangVien.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QuanLyGiangVienWebas.Services
{
    public class TaiKhoanApiClient : ITaiKhoanApiClient
    {
        public HttpClient _httpClient;

        public TaiKhoanApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<LoginRequest>> GetAllUser()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LoginRequest>>($"/api/logins");
            return result;
        }

        public Task<LoginRequest> GetUser()
        {
            throw new NotImplementedException();
        }
    }
}
