using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyNhaHang;
using QuanLyNhaHang.DAO;

namespace TestTableManager
{
    [TestClass]
    public class UnitTestManager
    {
        [TestMethod]
        public void TestGetInforTable1()
        {
            int id = 2;
            int count = 0;
            int count_expect = 0;
            List<QuanLyNhaHang.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyNhaHang.DTO.Menu item in listBillInfo)
            {
                count++;
            }
            Assert.AreEqual(count_expect, count);
        }

        [TestMethod]
        public void TestGetInforTable2()
        {
            int id = 6;
            int count = 0;
            int count_expect = 1;
            List<QuanLyNhaHang.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyNhaHang.DTO.Menu item in listBillInfo)
            {
                count++;
            }
            Assert.AreEqual(count_expect, count);
        }

        [TestMethod]
        public void TestAddDisk1()
        {

        }
}
