using System;
using System.Collections.Generic;
using System.Text;
using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Организация
            var p = new Product { Name = "Test", Price = 100M };
            //Действие
            p.Name = "New Name";
            //Утверждение
            Assert.Equal("New name", p.Name);
        }

    }
}
