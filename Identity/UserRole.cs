﻿using CMSApplication.Contracts;

namespace CMSApplication.Identity
{
    public class UserRole : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
