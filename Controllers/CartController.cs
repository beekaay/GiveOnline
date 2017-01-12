using GiveOnline.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiveOnline.Controllers
{
    [Authorize(Roles = "Member")]
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ApplicationUser Owner = db.Users.Find(User.Identity.GetUserId());

            ShoppingcartViewModel vm = new ShoppingcartViewModel()
            {
                Products = db.Products.ToList(),
                Cart = db.Carts.Where(x => x.OwnerId == Owner.Id).FirstOrDefault(),
                CartItems = db.CartItems.ToList(),
                Variants = db.Variants.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var Owner = db.Users.Find(User.Identity.GetUserId());

            if (Owner.Carts.Any())
            {
                CartItem AddToCart = new CartItem()
                {
                    Product = db.Products.Find(productId),
                    Cart = db.Carts.Where(x => x.OwnerId == Owner.Id).FirstOrDefault(),
                    Quantity = quantity
                };

                db.CartItems.Add(AddToCart);
            }
            else
            {
                Cart cart = new Cart
                {
                    Owner = db.Users.Find(User.Identity.GetUserId()),
                };

                db.Carts.Add(cart);

                CartItem AddToCart = new CartItem()
                {
                    Product = db.Products.Find(productId),
                    Cart = db.Carts.Where(x => x.OwnerId == Owner.Id).FirstOrDefault(),
                    Quantity = quantity
                };
            }


            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Cart_Delete(int? id)
        {
            if (id.HasValue)
            {
                CartItem model = db.CartItems.Find(id.Value);

                if (model != null)
                {
                    db.CartItems.Remove(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}