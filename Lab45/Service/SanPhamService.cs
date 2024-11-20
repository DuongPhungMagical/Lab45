using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab45.Models;

namespace Lab45.Service
{
    public class SanPhamService
    {
        public List<SanPham> danhSachSanPham = new List<SanPham>();

        public void ThemSanPham(SanPham sanPham)
        {
            if (sanPham.SoLuong <= 0 || sanPham.SoLuong >= 100)
            {
                throw new ArgumentException("Số lượng phải là số nguyên dương và nhỏ hơn 100.");
            }

            danhSachSanPham.Add(sanPham);
        }

        public void SuaSanPham(string id, SanPham sanPhamMoi)
        {
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanPham == null)
            {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm.");
            }

            if (!sanPhamMoi.MaSanPham.StartsWith("SP"))
            {
                throw new ArgumentException("Mã sản phẩm phải bắt đầu bằng 'SP'.");
            }

            if (danhSachSanPham.Any(sp => sp.MaSanPham == sanPhamMoi.MaSanPham && sp.Id != id))
            {
                throw new ArgumentException("Mã sản phẩm phải là duy nhất.");
            }

            sanPham.MaSanPham = sanPhamMoi.MaSanPham;
            sanPham.TenSanPham = sanPhamMoi.TenSanPham;
            sanPham.Gia = sanPhamMoi.Gia;
            sanPham.MauSac = sanPhamMoi.MauSac;
            sanPham.KichThuoc = sanPhamMoi.KichThuoc;
            sanPham.SoLuong = sanPhamMoi.SoLuong;
        }

        public void XoaSanPham(string id)
        {
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanPham == null)
            {
                throw new KeyNotFoundException("Không tìm thấy sản phẩm.");
            }

            danhSachSanPham.Remove(sanPham);
        }
    }
}
