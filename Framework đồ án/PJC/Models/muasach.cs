using System;
using System.ComponentModel.DataAnnotations;

namespace PJC.Models
{
    public class muasach
    {
        private string hoTen, SoDienThoa, diaChi, maSach,User;
        private int ThanhToan, TinhTrangDonHang,maDonHang;
        [Display(Name ="Mã đơn hàng")]

        public int MaDonHang { get => maDonHang; set => maDonHang = value; }
        [Display(Name = "Họ và tên: ")]
        public string HoTen { get => hoTen; set => hoTen = value; }
        [Display(Name ="Số điện thoại")]
        public string SoDienThoai { get => SoDienThoa; set => SoDienThoa = value; }
        [Display(Name ="Địa chỉ")]
        public string DiaChi { get => diaChi; set => diaChi = value; }
        [Display(Name ="Mã sách")]
        public string MaSach { get => maSach; set => maSach = value; }
        [Display(Name ="Tình trạng thanh toán")]
        public int TinhTranThanhToan { get => ThanhToan; set => ThanhToan = value; }

        [Display(Name ="Tình trạng đơn hàng")]
        public int TinhTranDon { get => TinhTrangDonHang; set => TinhTrangDonHang = value; }
        [Display(Name ="Người bán")]
        public string NguoiBan { get => User; set => User = value; }

    }
}
