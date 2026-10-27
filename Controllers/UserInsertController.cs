using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiUserMvc.Models;

namespace MultiUserMvc.Controllers
{
   
    public class UserInsertController : Controller
    {
        MVCMultiuserDBEntities dbobj = new MVCMultiuserDBEntities();
        // GET: UserInsert
        public ActionResult InsertUser_Pageload()
        {
            return View();
        }
        public ActionResult InsertUser_click(UsereInsertCls clsobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s,fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~/Photos", fname);
                    clsobj.photo = fullpath;
                }
                var maxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(maxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userReg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.photo);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "Successfully inserted";
                return View("InsertUser_Pageload", clsobj);
            }
                return View("InsertUser_Pageload", clsobj);
        }
    }
}