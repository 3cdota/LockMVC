//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LockWebMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class DomainUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DomainUser()
        {
            this.User_key = new HashSet<User_key>();
        }
    
        public long ID { get; set; }
        public string UserName { get; set; }
        public int DepartmentID { get; set; }
        public bool NoKey { get; set; }
        public bool ShowC { get; set; }
        public bool CanShare { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_key> User_key { get; set; }
    }
}
