using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LockWebMVC.Models
{
    public class AuthTypeMetadata
    {
        
        public int ID { get; set; }
        [Display(Name = "认证方式")]
        public string AuthName { get; set; }
    }
}