using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SumITCompOnline.Entities;
using SumITCompOnline.WebApi.Controllers;
using System.Web.Http.Results;
using System.Net.Http;
using System;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net;

namespace SumITCompOnline.WebApi.Test.Controllers
{
    /// <summary>
    ///     Tests for Products Controller
    ///     Author: Risath
    /// </summary>
    [TestFixture]
    public class ProductsControllerTest
    {
        [Test]
        public void Get_Should_Return_All_Existing_Products()
        {
            // Arrange
            TestProductContext context = new TestProductContext();
            context.Products.Add(new Product
            {
                Id = 1,
                Title = "Monitor",
                Description = "LCD Monitor",
                Price = 15000.00m
            });
            context.Products.Add(new Product
            {
                Id = 2,
                Title = "Keyboard",
                Description = "Logitech Wireless Keyboard",
                Price = 55.00m
            });
            context.Products.Add(new Product
            {
                Id = 3,
                Title = "Mouse",
                Description = "Logitech wireless mouse",
                Price = 45.00m
            });
            ProductsController controller = new ProductsController(context);

            // Act
            IEnumerable<Product> actual = controller.Get();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count());
        }

        [Test]
        public void Get_Id_Should_Return_Current_Product_With_Id()
        {
            // Arrange
            TestProductContext context = new TestProductContext();
            context.Products.Add(new Product
            {
                Id = 1,
                Title = "Monitor",
                Description = "LCD Monitor",
                Price = 15000.00m
            });
            
            ProductsController controller = new ProductsController(context);

            // Act

            var result = controller.Get(1) as OkNegotiatedContentResult<Product>;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Id);
        }

        [Test]
        public void PostProduct_ShouldReturnSameProduct()
        {
            // Arrange
            TestProductContext context = new TestProductContext();

            ProductsController controller = new ProductsController(context);
            
            var item = GetDemoProduct();

            // Act
            var result =
                controller.PostProduct(item) as CreatedAtRouteNegotiatedContentResult<Product>;
            
            // Assert
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Id, item.Id);
        }

        
        [Test]
        public void PutProduct_ShouldReturnStatusCode()
        {
            // Arrange
            TestProductContext context = new TestProductContext();

            ProductsController controller = new ProductsController(context);

            var item = GetDemoProduct();

            // Act
            var result = controller.PutProduct(item.Id, item) as StatusCodeResult;

            // Assert
            
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [Test]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            TestProductContext context = new TestProductContext();

            ProductsController controller = new ProductsController(context);

            var badresult = controller.PutProduct(999, GetDemoProduct());
            Assert.IsInstanceOfType(typeof(BadRequestResult),badresult);

        }

        [Test]
        public void DeleteProduct_ShouldReturnOK()
        {
            TestProductContext context = new TestProductContext();

            var item = GetDemoProduct();
            context.Products.Add(item);

            ProductsController controller = new ProductsController(context);

            var result = controller.DeleteProduct(42) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
            
            //var result = controller.DeleteProduct(42) as OkNegotiatedContentResult<Product>;

            //Assert.IsNotNull(result);
            //Assert.AreEqual(item.Id, result.Content.Id);
        }

        Product GetDemoProduct()
        {
            return new Product() { Id = 42, Title = "Monitor", Description = "LCD Monitor", Price = 15000.00m };
        }


    }
}