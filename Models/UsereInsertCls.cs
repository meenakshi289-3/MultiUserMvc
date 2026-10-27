using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MultiUserMvc.Models
{
    public class UsereInsertCls
    {
        [Required(ErrorMessage = "Enter the name")]
        public string name { set; get; }
        [Range(18,50,ErrorMessage = "Enter the age")]
        public int age { set; get; }
        [Required(ErrorMessage = "Enter the address")]
        public string address { set; get; }
        
        [EmailAddress(ErrorMessage = "Enter the email id")]
        public string email { set; get; }
        public string photo { set; get; }
        public string username { set; get; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "Password Missmatch")]
        public string cpassword { set; get; }
        public string usermsg { set; get; }
    }
}