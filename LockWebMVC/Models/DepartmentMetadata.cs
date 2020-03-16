using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LockWebMVC.Models
{
    public class DepartmentMetadata
    {

        public int ID { get; set; }
        [Display(Name = "单位")]
        public string DepartmentName { get; set; }
    }
}