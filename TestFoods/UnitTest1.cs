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
        int idFood;
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
        [TestMethod]
        public void TestFoodSuccess()
        {
            // Test tên  thức ăn trùng
            name = "bún chả hà nội"; categoryID = 1; price = 20000;
            AddFood(name, categoryID, price);
            Assert.AreEqual(test, resultFood);
        }
        public void AddFood(string name, int categoryID, float price)
        {
            resultFood = accDao.InsertFood(name, categoryID, price);
            string query = string.Format("INSERT dbo.Food ( name, idCategory, price )VALUES  ( N'{0}', {1}, {2})", name, 1, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            test = false;
            if (result > 0)
            {
                test = true;
            }
        }
        [TestMethod]
        public void TestUpdateFoodNull()
        {
            // Test tên  thức ăn không có trong thực đơn thức ăn
            name = "bún chả sài gòn"; categoryID = 1; price = 20000; idFood = 35;
            UpdateFood(idFood,name, categoryID, price);
            Assert.AreEqual(test, resultFood);
        }
        [TestMethod]
        public void TestUpdateFoodSuccess()
        {
            // Test tên  thức ăn không có trong thực đơn thức ăn
            name = "bún chả hà nội"; categoryID = 1; price = 40000; idFood = 35;
            UpdateFood(idFood, name, categoryID, price);
            Assert.AreEqual(test, resultFood);
        }

        public void UpdateFood(int idFood, string name, int categoryID, float price)
        {
            resultFood = accDao.UpdateFood(idFood, name, categoryID, price);
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, categoryID, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            test = false;
            if (result > 0)
            {
                test = true;
            }
        }
        [TestMethod]
        public void TestDeleteFood()
        {
            // Test tên  thức ăn không có trong thực đơn thức ăn
            idFood = 1;
            DeleteFood(idFood);
            Assert.AreEqual(test, resultFood);
        }
        public void DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);
            resultFood = FoodDAO.Instance.DeleteFood(idFood);
            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            test = false;
            if (result > 0)
            {
                test = true;
            }
        }

    }
}

