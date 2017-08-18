using Blog.Domain.Entities.Base;

namespace Blog.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}