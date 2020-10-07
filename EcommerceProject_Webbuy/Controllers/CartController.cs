using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject_Webbuy.Models.DAL;
using EcommerceProject_Webbuy.Models.DataObjects;
using EcommerceProject_Webbuy.Models.ViewModel;
using Microsoft.AspNet.Identity;

namespace EcommerceProject_Webbuy.Controllers
{
    public class CartController : Controller
    {
        CartManagement cartManagement = new CartManagement();
        public ActionResult Index()
        {
            List<CartDO> records = cartManagement.GetAllRecordsInCart();

            var query = from p in records
                        select new CartViewModel
                        {
                            Cart_ID = p.Cart_ID,
                            User_ID = p.User_ID
                        };

            return View(query.ToList());

        }

        public ActionResult AddToCart(int id, CartAddViewModel model)
        {
            CartDO cartDO = new CartDO();
            if (User.Identity.IsAuthenticated)
            {
                cartDO.User_ID = User.Identity.GetUserId();
                //checking if user already has cart created
                cartDO = cartManagement.GetCartByUserID(cartDO.User_ID);
                if(cartDO.Cart_ID == 0)
                {
                    try
                    {
                        cartDO.User_ID = User.Identity.GetUserId();
                        cartDO.Cart_ID = model.Cart_ID;
                        CartManagement cartManagement = new CartManagement();
                        cartManagement.AddCartIDandUserIDInCart(cartDO);

                        return RedirectToAction("Index");
                    }


                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            return null;
        }
    }

}