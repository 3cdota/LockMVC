using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LockWebMVC.Models
{
    public class DomainUserMetadata
    {

        public long ID { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "单位")]
        public int DepartmentID { get; set; }

        [Display(Name = "没有Ukey")]
        public bool NoKey { get; set; }
        [Display(Name = "C盘可访问")]
        public bool ShowC { get; set; }
        [Display(Name = "可以共享")]
        public bool CanShare { get; set; }

        [Display(Name = "桌面可存放")]
        public bool UseDeskTop { get; set; }

        [JsonIgnore]
        public virtual Department Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<User_key> User_key { get; set; }
    }
}