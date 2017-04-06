using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using Domain.Entities;
using WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.HtmlHelpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>
            {
                new item{itemId = 1, name = "item1"},
                new item{itemId = 2, name = "item2"},
                new item{itemId = 3, name = "item3"},
                new item{itemId = 4, name = "item4"},
                new item{itemId = 5, name = "item5"},
            });

            ItemsController controller = new ItemsController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            ItemListViewModel result = (ItemListViewModel)controller.List(null, 2).Model;

            // Утверждение (assert)
            List<item> item = result.items.ToList();
            Assert.IsTrue(item.Count == 2);
            Assert.AreEqual(item[0].name, "item4");
            Assert.AreEqual(item[1].name, "item5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Организация
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>
            {
                 new item{itemId = 1, name = "item1"},
                new item{itemId = 2, name = "item2"},
                new item{itemId = 3, name = "item3"},
                new item{itemId = 4, name = "item4"},
                new item{itemId = 5, name = "item5"},
            });

            ItemsController controller = new ItemsController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            ItemListViewModel result = (ItemListViewModel)controller.List(null, 2).Model;

            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Items()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>
            {
                new item{itemId = 1, name = "item1", type="type1"},
                new item{itemId = 2, name = "item2", type="type2"},
                new item{itemId = 3, name = "item3", type="type1"},
                new item{itemId = 4, name = "item4", type="type3"},
                new item{itemId = 5, name = "item5", type="type2"}
            });

            ItemsController controller = new ItemsController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            List<item> result = ((ItemListViewModel)controller.List("type2", 1).Model).items.ToList();

            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].name == "item2" && result[0].type == "type2");
            Assert.IsTrue(result[1].name == "item5" && result[1].type == "type2");
        }
        [TestMethod]

        public void Can_Create_Categories()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>
            {
                new item{itemId = 1, name = "item1", type="type1"},
                new item{itemId = 2, name = "item2", type="type2"},
                new item{itemId = 3, name = "item3", type="type3"},
                new item{itemId = 4, name = "item4", type="type1"},
                new item{itemId = 5, name = "item5", type="type2"},
            });

            NavController target = new NavController(mock.Object);

            // Действие (act)
            List<string> result = ((IEnumerable<string>)target.Menu().Model).ToList();

            Assert.AreEqual(result.Count(), 3);
            Assert.AreEqual(result[0], "type1");
            Assert.AreEqual(result[1], "type2");
            Assert.AreEqual(result[2], "type3");
        }

        [TestMethod]

        public void Indicates_Selected_Type()
        {
            // Организация (arrange)
            Mock<IItemRepository> mock = new Mock<IItemRepository>();
            mock.Setup(m => m.items).Returns(new List<item>
            {
                new item{itemId = 1, name = "item1", type="type1"},
                new item{itemId = 2, name = "item2", type="type2"},
                new item{itemId = 3, name = "item3", type="type3"},
                new item{itemId = 4, name = "item4", type="type1"},
                new item{itemId = 5, name = "item5", type="type2"},
            });

            NavController target = new NavController(mock.Object);

            string typeToSelect = "Type2";

            // Действие (act)
            string result = target.Menu(typeToSelect).ViewBag.SelectedType;
            Assert.AreEqual(typeToSelect, result);
           
        }
        [TestMethod]

        public void Generete_Genre_Specific_Item_Count()
{
    // Организация (arrange)
    Mock<IItemRepository> mock = new Mock<IItemRepository>();
    mock.Setup(m => m.items).Returns(new List<item>
            {
          new item{itemId = 1, name = "item1", type="type1"},
                new item{itemId = 2, name = "item2", type="type2"},
                new item{itemId = 3, name = "item3", type="type3"},
                new item{itemId = 4, name = "item4", type="type1"},
                new item{itemId = 5, name = "item5", type="type2"}
            });

    ItemsController controller = new ItemsController(mock.Object);
    controller.pageSize = 3;

    int res1 = ((ItemListViewModel)controller.List("type1").Model).PagingInfo.TotalItems;
    int res2 = ((ItemListViewModel)controller.List("type2").Model).PagingInfo.TotalItems;
    int res3 = ((ItemListViewModel)controller.List("type3").Model).PagingInfo.TotalItems;
    int resAll = ((ItemListViewModel)controller.List(null).Model).PagingInfo.TotalItems;

    Assert.AreEqual(res1, 2);
    Assert.AreEqual(res2, 2);
    Assert.AreEqual(res3, 1);
    Assert.AreEqual(resAll, 5);
}
    }
}
