using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IItemRepository repository;
        public CartController(IItemRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

     /*  public RedirectToRouteResult AddToCart(Cart cart, int itemID, string returnUrl)
        {
           item Item = repository.items
               .FirstOrDefault(b => b.itemId == itemID);

            if (Item != null)
            {
                cart.AddItem(Item, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }*/

        public RedirectToRouteResult RemoveFromCart(Cart cart, int ItemID, string returnUrl)
        {
            item Item = repository.items
                .FirstOrDefault(b => b.itemId == ItemID);

            if (Item != null)
            {
                cart.RemoveLine(Item);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}