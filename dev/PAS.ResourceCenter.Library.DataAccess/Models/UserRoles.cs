﻿using System;
using System.Collections.Generic;

namespace PAS.ResourceCenter.Library.DataAccess.Models
{
    public partial class UserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
