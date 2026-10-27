using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MultiUserMvc.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter the user name")]
        public string username { set; get; }
        [Required(ErrorMessage = "Enter the password")]
        public string pass { set; get; }
        public string msg { set; get; }
    }
}
