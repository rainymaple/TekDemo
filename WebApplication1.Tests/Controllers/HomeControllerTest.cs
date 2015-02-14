using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Modules;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Database _db;
        private Repository<Product> _repository;
        private IBusiness _business;
        private HomeController _homeController;
        private IList<Product> _product;

        [TestInitialize]
        public void Init()
        {
            _db = new Database();
            _repository = new Repository<Product>(_db);
            _business=new Business();
            _homeController = new HomeController(_repository,_business);
            _product = new List<Product>
            {
                new Product {Id = 1, Name = "Book", IsExempt = true,Price = 12.23,IsImported = true,Amount = 2},
                new Product {Id = 2, Name = "Music CD",Price = 1.99,IsImported = false,Amount = 1}
            };
        }
        [TestMethod]
        public void Index()
        {

            // Act
            ViewResult result = _homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
        [TestMethod]
        public void CanGetAllProducts()
        {
            var products = _homeController.GetAllProducts() as JsonResult;
            Assert.IsNotNull(products);
            
        }

        [TestMethod]
        public void CanCreateReceit()
        {
            var receipt = _homeController.PrintReceipt(_product) as JsonResult;
            Assert.IsNotNull(receipt);

        }
    }
}
