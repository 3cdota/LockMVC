﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lockEntities : DbContext
    {
        public lockEntities()
            : base("name=lockEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DomainUser> DomainUsers { get; set; }
        public virtual DbSet<LockConfig> LockConfigs { get; set; }
        public virtual DbSet<Ukey> Ukeys { get; set; }
        public virtual DbSet<User_key> User_key { get; set; }
    }
}
