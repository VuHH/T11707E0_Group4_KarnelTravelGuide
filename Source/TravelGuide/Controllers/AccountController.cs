using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelGuide.Controllers
{
    public class AccountController : Controller
    {
        TravelGuideDBContext dbContext = new TravelGuideDBContext();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterInfor(USERACCOUNT newUser)
        {
            if (ModelState.IsValid)
            {

                var t = dbContext.USERACCOUNTs.Where(x => x.EMAIL_USER == newUser.EMAIL_USER).FirstOrDefault();
                if (t != null)
                {
                    ViewBag.Message = "Email is existing!";
                }
                else
                {
                    USERACCOUNT userInfo = new USERACCOUNT();
                    userInfo.ID_USER = Guid.NewGuid().ToString("N");
                    userInfo.NAME_USER = newUser.NAME_USER;
                    userInfo.PASS_USER = newUser.PASS_USER;
                    userInfo.ADDRESS_USER = newUser.ADDRESS_USER;
                    userInfo.EMAIL_USER = newUser.EMAIL_USER;
                    userInfo.TEL_USER = newUser.TEL_USER;
                    userInfo.DISASBLE = true;
                    dbContext.USERACCOUNTs.Add(userInfo);
                    dbContext.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View("Register");

        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginAccount(string EMAIL_USER, string PASS_USER)
        {
            if (ModelState.IsValid)
            {
                var t = dbContext.USERACCOUNTs.Where(x => x.EMAIL_USER == EMAIL_USER).FirstOrDefault();
                if (t == null)
                {
                    ViewBag.Message = "Account is not existing!";
                }
                else
                {
                    if (t.PASS_USER != PASS_USER)
                    {
                        ViewBag.Message = "Password wrong";
                    } else
                    {
                        Session["userInfor"] = t.EMAIL_USER;
                        Session["USER_ID"] = t.ID_USER;
                        return RedirectToAction("Index", "Home");
                    }

                    
                }
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}