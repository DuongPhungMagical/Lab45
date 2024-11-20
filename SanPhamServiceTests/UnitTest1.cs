using Lab45.Models;
using Lab45.Service;

namespace SanPhamServiceTests
{
    [TestFixture]   
    public class Tests
    {
        private SanPhamService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SanPhamService();
        }

        [Test]
        public void ThemSanPham_ThanhCong()
        {
            var sanPham = new SanPham("1", "SP001", "San Pham 1", 100.0f, "Red", "L", 50);
            Assert.DoesNotThrow(() => _service.ThemSanPham(sanPham));
        }

        [Test]
        public void ThemSanPham_SoLuongNhoHon0()
        {
            var sanPham = new SanPham("2", "SP002", "San Pham 2", 100.0f, "Blue", "M", -1);
            Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
        }

        [Test]
        public void ThemSanPham_SoLuongBang100()
        {
            var sanPham = new SanPham("3", "SP003", "San Pham 3", 100.0f, "Green", "S", 100);
            Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
        }

        [Test]
        public void ThemSanPham_SoLuongBang0()
        {
            var sanPham = new SanPham("4", "SP004", "San Pham 4", 100.0f, "Yellow", "XL", 0);
            Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
        }

        [Test]
        public void ThemSanPham_SoLuongHopLe()
        {
            var sanPham = new SanPham("5", "SP005", "San Pham 5", 150.0f, "Black", "XXL", 99);
            Assert.DoesNotThrow(() => _service.ThemSanPham(sanPham));
        }

        [Test]
        public void SuaSanPham_ValidData()
        {
            var sanPham = new SanPham("1", "SP001", "San Pham 1", 100.0f, "Red", "L", 50);
            _service.ThemSanPham(sanPham);

            var sanPhamMoi = new SanPham("1", "SP002", "San Pham Moi", 200.0f, "Blue", "M", 20);
            Assert.DoesNotThrow(() => _service.SuaSanPham("1", sanPhamMoi));
        }

        [Test]
        public void SuaSanPham_MaSanPhamKhongBatDauSP()
        {
            var sanPham = new SanPham("2", "SP002", "San Pham 2", 100.0f, "Blue", "M", 50);
            _service.ThemSanPham(sanPham);

            var sanPhamMoi = new SanPham("2", "XX002", "San Pham Moi", 200.0f, "Yellow", "S", 20);
            Assert.Throws<ArgumentException>(() => _service.SuaSanPham("2", sanPhamMoi));
        }

        [Test]
        public void SuaSanPham_MaSanPhamKhongDuyNhat()
        {
            var sanPham1 = new SanPham("1", "SP001", "San Pham 1", 100.0f, "Red", "L", 50);
            var sanPham2 = new SanPham("2", "SP002", "San Pham 2", 150.0f, "Blue", "M", 30);
            _service.ThemSanPham(sanPham1);
            _service.ThemSanPham(sanPham2);

            var sanPhamMoi = new SanPham("1", "SP002", "San Pham Moi", 200.0f, "Green", "S", 20);
            Assert.Throws<ArgumentException>(() => _service.SuaSanPham("1", sanPhamMoi));
        }

        [Test]
        public void SuaSanPham_KhongTimThaySanPham()
        {
            var sanPhamMoi = new SanPham("1", "SP003", "San Pham Moi", 200.0f, "Yellow", "M", 20);
            Assert.Throws<KeyNotFoundException>(() => _service.SuaSanPham("3", sanPhamMoi));
        }
        [Test]
        public void SuaSanPham_DuLieuDayDuVaHopLe()
        {
            var sanPham = new SanPham("7", "SP007", "San Pham 7", 300.0f, "White", "L", 70);
            _service.ThemSanPham(sanPham);

            var sanPhamMoi = new SanPham("7", "SP007", "San Pham Moi", 350.0f, "Pink", "XL", 80);
            Assert.DoesNotThrow(() => _service.SuaSanPham("7", sanPhamMoi));
        }
    }
}