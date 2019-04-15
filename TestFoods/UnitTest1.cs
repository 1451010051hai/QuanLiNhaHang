using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyNhaHang.DAO;
using System.Data;
using QuanLyNhaHang.DTO;

namespace TestFoods
{
    [TestClass]
    public class UnitTest1
    {
        string name;
        float price;
        int categoryID;
        FoodDAO accDao = FoodDAO.Instance;
        bool resultFood = false;
        bool test = false;
        [TestMethod]
        public void TestNameNull()
        {
            // Test tên thức ăn rỗng
            name = ""; categoryID = 1; price = 20000;
            AddFood(name, categoryID,price);
            Assert.AreEqual(test, resultFood);
        }
        [TestMethod]
        public void TestPriceNull()
        {
            // Test giá thức ăn rỗng
            name = "bún bò"; categoryID = 1; price = 0;
            AddFood(name, categoryID, price);
            Assert.AreEqual(test, resultFood);
        }
        [TestMethod]
        public void TestSameName()
        {
            // Test tên  thức ăn trùng
            name = "Chả giò tôm thịt"; categoryID = 1; price = 100000;
            AddFood(name, categoryID, price);
            Assert.AreEqual(test, resultFood);
        }
        public void AddFood(string name, int categoryID, float price)
        {
            resultFood = accDao.InsertFood(name, categoryID, price);
            string query = string.Format("INSERT dbo.Food ( name, idCategory, price )VALUES  ( N'{0}', {1}, {2})", name, 1, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
            {
                test = true;
            }
        }
        
    }
}

