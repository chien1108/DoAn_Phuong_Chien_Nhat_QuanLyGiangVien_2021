using QuanLyGiangVien.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace QuanLyGiangVienWasm.Services
{
    public class GiaoVienApiClient : IGiaoVienApiClient
    {
        private HttpClient _httpClient;

        public GiaoVienApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GiaoVienRequest>> GetListGiangVien()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GiaoVienRequest>>($"/api/giaoviens");
            return result;
        }

        //public async Task<Lis<giaovienrequest>> getlistgiangvien()
        //{
        //    var result = await _httpclient.getfromjsonasync<list<loginrequest>>($"/api/giaoviens");
        //    return result;
        //}

    }
}
