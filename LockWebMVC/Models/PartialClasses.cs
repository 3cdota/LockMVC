using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LockWebMVC.Models;

namespace LockWebMVC
{

    [MetadataType(typeof(DomainUserMetadata))]
    public partial class DomainUser
    {
    }


    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }


    [MetadataType(typeof(AuthTypeMetadata))]
    public partial class AuthType
    {
    }
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department
    {
    }
}