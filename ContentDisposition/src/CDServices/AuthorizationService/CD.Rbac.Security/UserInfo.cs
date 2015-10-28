using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RBAC;

namespace CD.Rbac.Security
{
    public class UserInfo : IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string GroupRole { get; set; }
        public string GroupName { get; set; }
        public string AssignParty { get; set; }
    }
}
