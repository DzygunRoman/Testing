using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Xunit;
using Moq;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndeActionModelIsComplete()
        {
            //Организация
            Product[] testData = new Product[]
            {
                new Product {Name="P1", Price=75.10M},
                new Product {Name="P2", Price=120M},
                new Product {Name="P3", Price=110M}
            };
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m=>m.Products).Returns(testData);
            var controller=new HomeController();
            controller.dataSource = mock.Object;
            //Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //Утверждение
            Assert.Equal(testData, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products,Times.Once);
        }
    }
}
