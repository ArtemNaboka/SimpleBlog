using System.Collections.Generic;
using Blog.Domain.Entities.Base;
using Microsoft.AspNet.Identity;

namespace Blog.Domain.Entities
{
    public class Role : BaseEntity, IRole<int>
    {
        public string Name { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}