using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MultiUserMvc.Models;


namespace MultiUserMvc.Controllers
{
    public class AdminInsertController : Controller
    {
        MVCMultiuserDBEntities dbobj = new MVCMultiuserDBEntities();  
        // GET: AdminReg
        public ActionResult InsertAdmin_Pageload()
        {
            return View();
        }
        public ActionResult InsertAdmin_click(AdminInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
                var maxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(maxid);
                int regid = 0;
                if(mid==0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_adminReg(regid,clsobj.name,clsobj.address, clsobj.phone, clsobj.email);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass,"admin");
                clsobj.adminmsg = "Successfully inserted";
                return View("InsertAdmin_Pageload", clsobj);

            }
            return View("InsertAdmin_Pageload", clsobj);

        }

    }
}