using Microsoft.AspNetCore.Components;
using QuanLyGiangVien.Models.Models;
using QuanLyGiangVienWebas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyGiangVienWebas.Pages
{
    public partial class FetchData
    {
        [Inject] private ITaiKhoanApiClient Login { get; set; }
        private List<LoginRequest> logins;

        protected async override Task OnInitializedAsync()
        {
            logins = await Login.GetAllUser();
        }
    }
}
