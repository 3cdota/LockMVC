using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LockWebMVC.Models
{
    public class UserMetadata
    {

        public int ID { get; set; }
        [Display(Name = "具体单位")]
        public string SpecificDepartment { get; set; }
        [Display(Name = "办公室地址")]
        public string Address { get; set; }
        [Display(Name = "电话")]
        public string Number { get; set; }
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "登录名")]
        public string DomainUserName { get; set; }
        [Display(Name = "IP地址")]
        public string IpAddress { get; set; }
        [Display(Name = "mac 地址")]
        public string MacAddress { get; set; }
        [Display(Name = "ukey 标识")]
        public string CN { get; set; }
        [Display(Name = "密码")]
        public string Password { get; set; }
        [Display(Name = "显示C盘")]
        public bool ShowC { get; set; }
        [Display(Name = "可以共享")]
        public bool CanShare { get; set; }
        [Display(Name = "桌面可用")]        
        public bool UseDeskTop { get; set; }

        [Display(Name = "U盘可用")]
        public bool Usb { get; set; }
        [Display(Name = "是否批准")]
        public bool Approved { get; set; }
        [Display(Name = "单位")]
        public int DepartmentID { get; set; }
        [Display(Name = "认证类型")]
        public int AuthTypeID { get; set; }
        [Display(Name = "认证类型")]
        public virtual AuthType AuthType1 { get; set; }
        [Display(Name = "单位")]
        public virtual Department Department1 { get; set; }
    }
}