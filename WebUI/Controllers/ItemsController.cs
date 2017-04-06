using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository repository;
        public int pageSize = 3;

        public ItemsController(IItemRepository repo)

        {
            repository = repo;
        }

        public ViewResult List(string Type, int page = 1)
        {
            ItemListViewModel model = new ItemListViewModel
            {
                items = repository.items
                .Where(b => Type == null || b.type == Type)
                .OrderBy(item=>item.itemId)
                .Skip((page - 1) *pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = Type == null ?
                    repository.items.Count() : 
                    repository.items.Where(items => items.type == Type).Count()
                },
                CurrentType=Type
            };

            return View(model);
        }
    }
}