using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndeActionModelIsComplete()
        {
            //Организация
            var controller=new HomeController();
            Product[] products = new Product[]
            {
                new Product{Name="Kayak",Price=275M},
                new Product{Name="Lifejacket",Price=48.95M }
            };
            //Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //Утверждение
            Assert.Equal(products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
