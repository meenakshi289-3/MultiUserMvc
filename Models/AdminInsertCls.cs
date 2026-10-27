using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MultiUserMvc.Models
{
    public class AdminInsertCls
    {
        [Required(ErrorMessage ="Enter the name")]
        public string name { set; get; }
        public string address { set; get; }
        [RegularExpression(@"^(\d{10})$",ErrorMessage ="Enter valid Number")]
        public string phone { set; get; }
        [EmailAddress(ErrorMessage = "Enter the email id")]
        public string email { set; get; }
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass",ErrorMessage ="Password Missmatch")]
        public string cpassword { set; get; }
        public string adminmsg { set; get; }
    }
}