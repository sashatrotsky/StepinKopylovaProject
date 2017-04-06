using WebUI.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Controllers
{
    internal class ItemListViewsModel
    {
        public IEnumerable<item> items { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentType { get; set; }
    }
}