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
            bool rs = false;
            int TableID = 6;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(TableID);
            int foodID = 2;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(TableID);
                rs = BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, 0);

            }
            else
            {
                rs = BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, 0);
            }
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void TestAddDisk2()
        {
            bool rs = false;
            int TableID = 1;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(TableID);
            int foodID = 2;
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(TableID);
                rs = BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, 1);
            }
            else
            {
                rs = BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, 1);
            }
            Assert.IsTrue(rs);
        }
    }
}
