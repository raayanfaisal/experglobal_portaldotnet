using System;
using Microsoft.AspNetCore.Identity;

namespace expertglobal.Model
{
    public class UserBio: IdentityUser
    {
        public string FullName { get; set; }

    }
}
