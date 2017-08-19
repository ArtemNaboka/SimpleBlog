using System.Collections.Generic;
using Blog.Domain.Entities.Base;
using Microsoft.AspNet.Identity;

namespace Blog.Domain.Entities
{
    public class User : BaseEntity, IUser<int>
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}