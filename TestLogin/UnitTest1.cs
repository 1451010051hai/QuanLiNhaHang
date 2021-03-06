﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyNhaHang.DAO;
using System.Data;
namespace TestLogin
{

    [TestClass]
    public class UnitTest1
    {
        AccountDAO accDao = AccountDAO.Instance;
        string user;
        string pass;
        bool test = false;
        bool resultLogin = false;
        [TestMethod]
        public void TestLogin()
        {
            //pass sai
            user = "Admin";pass = "789";
            getLogin(user, pass);
            Assert.AreEqual(test,resultLogin);
        }
        [TestMethod]
        public void TestUserWrong()
        {
            // user sai
            user = "Admin123"; pass = "123";
            getLogin(user, pass);
            Assert.AreEqual(test, resultLogin);
        }
        [TestMethod]
        public void TestUserNull()
        {
            // user sai
            user = ""; pass = "123";
            getLogin(user, pass);
            Assert.AreEqual(test, resultLogin);
        }
        [TestMethod]
        public void TestPassNull()
        {
            // pass sai
            user = "Admin"; pass = "";
            getLogin(user, pass);
            Assert.AreEqual(test, resultLogin);
        }
        [TestMethod]
        public void TestPassKiTu()
        {
            // user sai
            user = "Admin"; pass = "@Admin_";
            getLogin(user, pass);
            Assert.AreEqual(test, resultLogin);
        }
        [TestMethod]
        public void TestPassCase()
        {
            // user sai
            user = "Admin"; pass = "123";
            getLogin(user, pass);
            Assert.AreEqual(test, resultLogin);
        }

        public void getLogin(string user,string pass)
        {
            
            resultLogin = accDao.Login(user, pass);
            string query = "select *from dbo.Account where UserName=N'" + user + "'AND Password=N'" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            test = false;
            if (result.Rows.Count > 0)
            {
                test = true;
            }
        }
    }
}
