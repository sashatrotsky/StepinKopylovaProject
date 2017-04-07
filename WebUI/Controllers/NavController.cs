using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Repository.Repositories;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IItemRepository repository;

        public NavController(IItemRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string type = null)
        {
            ViewBag.SelectedType = type;

            IEnumerable<string> types = repository.items
                .Select(item => item.type)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(types);
        }
    }
}