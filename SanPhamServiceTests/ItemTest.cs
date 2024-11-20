using Lab45.Models;
using Lab45.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPhamServiceTests
{
    [TestFixture]
    internal class ItemTest
    {
        private ItemManager _itemManager;

        [SetUp]
        public void Setup()
        {
            _itemManager = new ItemManager();
        }

        [Test]
        public void AddItem()
        {
            // Arrange
            var manager = new ItemManager();
            var item = new Item(1, "ValidItem");

            // Act
            manager.AddItem(item);

            // Assert
            Assert.DoesNotThrow(() => manager.UpdateItem(1, "NewName")); // Kiểm tra item có tồn tại
        }



        //sua
        [Test]
        public void UpdateItem()
        {
            // Arrange
            var manager = new ItemManager();
            var item = new Item(1, "OriginalName");
            manager.AddItem(item);

            // Act
            manager.UpdateItem(1, "UpdatedName");

            // Assert
            Assert.DoesNotThrow(() => manager.UpdateItem(1, "FinalName")); // Kiểm tra sửa lần nữa không lỗi
        }


        //xoa
        [Test]
        public void DeleteItem()
        {
            // Arrange
            var manager = new ItemManager();
            var item = new Item(1, "ItemToDelete");
            manager.AddItem(item);

            // Act
            manager.DeleteItem(1);

            // Assert
            Assert.DoesNotThrow(() => manager.DeleteItem(1)); // Kiểm tra không lỗi khi xóa lần nữa
        }

    }
}
