using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Domain.Abstract;
using WebUI.Controllers;
using System.Web.Mvc;
using WebUI.Models;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация
            item item1 = new item { itemId = 1, name = "item1" };
            item item2 = new item { itemId = 2, name = "item2" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            List<CartLine> results = cart.Lines.ToList();

            // Утвержение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].item, item1);
            Assert.AreEqual(results[1].item, item2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Организация
            item item1 = new item { itemId = 1, name = "item1" };
            item item2 = new item { itemId = 2, name = "item2" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            cart.AddItem(item1, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.item.itemId).ToList();

            // Утвержение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Организация
            item item1 = new item { itemId = 1, name = "item1" };
            item item2 = new item { itemId = 2, name = "item2" };
            item item3 = new item { itemId = 3, name = "item3" };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            cart.AddItem(item1, 5);
            cart.AddItem(item3, 2);
            cart.RemoveLine(item2);

            // Утвержение
            Assert.AreEqual(cart.Lines.Where(c => c.item == item2).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Организация
            item item1 = new item {  itemId = 1, name = "item1", price = 100 };
            item item2 = new item {  itemId = 2, name = "item2", price = 55 };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            cart.AddItem(item1, 5);
            decimal result = cart.ComputeTotalValue();

            // Утвержение
            Assert.AreEqual(result, 655);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Организация
            item item1 = new item { itemId = 1, name = "item1", price = 100 };
            item item2 = new item { itemId = 2, name = "item2", price = 55 };

            Cart cart = new Cart();

            // Действие
            cart.AddItem(item1, 1);
            cart.AddItem(item2, 1);
            cart.AddItem(item1, 5);
            cart.Clear();

            // Утвержение
            Assert.AreEqual(cart.Lines.Count(), 0);
        }

        // Добавление элемента в корзину
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>{
                new item { itemId = 1, name = "item1", type = "type1"}
            }.AsQueryable());

            Cart cart = new Cart();

            CartController controller = new CartController(mock.Object);

            controller.AddToCart(cart, 1, null);

            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToList()[0].item.itemId, 1);
        }

        // После добавления книги в корзину - перенаправление на страницу корзины
        [TestMethod]
        public void Adding_Book_To_Cart_Goes_To_Cart_Screen()
        {
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>{
                new item {itemId = 1, name = "item1", type = "type1"}
            }.AsQueryable());

            Cart cart = new Cart();

            CartController controller = new CartController(mock.Object);

            RedirectToRouteResult result = controller.AddToCart(cart, 2, "myUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }


        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            Cart cart = new Cart();
            CartController target = new CartController(null);

        }
    }
}
