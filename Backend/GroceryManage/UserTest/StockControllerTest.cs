using AutoFixture;
using GroceryManage.Controllers;
using GroceryManage.models;
using GroceryManage.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage
{
    [TestClass]
    public class StockControllerTest
    {
        private Mock<IStock> _stockRepository;
        private Fixture _fixture;
        private StockController _controller;

        public StockControllerTest()
        {
            _fixture = new Fixture();
            _stockRepository = new Mock<IStock>();
        }

        [TestMethod]
        public void adminlogin()
        {
            string message = "Success";
            string mail = "Admin@gmail.com";
            string pass = "Admin@2022";
            GroceryManage.Mstesting.Testing obj = new GroceryManage.Mstesting.Testing();
            Assert.AreEqual(6, obj.Loginchecker(2, 4));
            Assert.AreEqual(message, obj.Logincheck(mail, pass));

        }
        [TestMethod]
        public void userlogin()
        {
            string message = "Success";
            string mail = "Admin@gmail.com";
            string pass = "Admin@2022";
            GroceryManage.Mstesting.Testing obj = new GroceryManage.Mstesting.Testing();
            Assert.AreEqual(message, obj.userLogincheck(mail, pass));

        }
        [TestMethod]
        public async Task Getstockreturnok()
        {
            var stocklist = _fixture.CreateMany<Stocks>(2).ToList();

            _stockRepository.Setup(repo => repo.GetStocksList()).Returns(stocklist);

            _controller = new StockController(_stockRepository.Object);

            var result = await _controller.Getstocks();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);

        }
    }
}
