using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Areas.Admin.Models
{
    public class LoginModels
    {
        [Display(Name = "Enter your email"), Required] 
        public string UserName { get; set; }

        [Display(Name = "Enter your password"), Required]
        public string PassWord { get; set; }

    }
}