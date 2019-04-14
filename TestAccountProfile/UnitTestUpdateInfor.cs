using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyNhaHang.DAO;

namespace TestAccountProfile
{
    [TestClass]
    public class UnitTestUpdateInfor
    {
        [TestMethod]
        public void TestCapNhat_ThongTin1()
        {
            string userName = "NV";
            string displayName = "NhanVien";
            string password = "";
            string newpass = "";
            bool rs = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void TestCapNhat_ThongTin2()
        {
            string userName = "NV";
            string displayName = "NhanVien";
            string password = "12";
            string newpass = "";
            bool rs = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void TestCapNhat_ThongTin3()
        {
            string userName = "NV";
            string displayName = "NhanVien";
            string password = "123";
            string newpass = "";
            bool rs = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
            Assert.IsTrue(rs);
        }

        [TestMethod]
        public void TestCapNhat_ThongTin4()
        {
            string userName = "NV";
            string displayName = "NhanVien";
            string password = "123";
            string newpass = "12";
            bool rs = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
            Assert.IsTrue(rs);
        }

        [TestMethod]
        public void TestCapNhat_ThongTin5()
        {
            string userName = "NV";
            string displayName = "NhanVien";
            string password = "12";
            string newpass = "123";
            bool rs = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
            Assert.IsTrue(rs);
        }
    }
}
