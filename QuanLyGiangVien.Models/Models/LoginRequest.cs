namespace QuanLyGiangVien.Models.Models
{
    public class LoginRequest
    {
        public string MaGv { get; set; }
        public string TenDangNhap { get; set; }
        public byte[] MatKhau { get; set; }
        public string Quyen { get; set; }
    }
}
