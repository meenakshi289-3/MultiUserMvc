using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiUserMvc.Models;

namespace MultiUserMvc.Controllers
{
    public class LoginController : Controller
    {
        MVCMultiuserDBEntities dbobj = new MVCMultiuserDBEntities();
        // GET: Login
        public ActionResult Login_pageload()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(LoginCls objcls)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_loginCountId(objcls.username, objcls.pass).First();
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.username, objcls.pass).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_loginType(objcls.username, objcls.pass).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                    else
                    {
                        objcls.msg = "Invalid Username or Password";
                        return View("Login_pageload");
                    }
                }               
            
            }
            return View("Login_pageload");
        }
    }
}