using Microsoft.AspNetCore.Components;
using QuanLyGiangVien.Models.Models;
using QuanLyGiangVienWasm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVienWasm.Pages
{
    public partial class FetchData
    {
        [Inject] private IGiaoVienApiClient GiaoVienApiClient { set; get; }

        public List<GiaoVienRequest> ListGV = new List<GiaoVienRequest>();
        protected async override Task OnInitializedAsync()
        {
            ListGV = await GiaoVienApiClient.GetListGiangVien();
        }
    }
}
