using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using DemoAPI.Models;
using DemoAPI.Services;
using DemoAPI.Controller;

namespace DemoAPITest
{
    public class BuyControllerTest
    {
        BuyController _controller;
        IBuyService _service;
        public BuyControllerTest()
        {
            _service = new BuyServiceFake();
            _controller = new BuyController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<BuyItem>>(okResult.Value);
            Assert.Equal(4, items.Count);
        }
    }
}