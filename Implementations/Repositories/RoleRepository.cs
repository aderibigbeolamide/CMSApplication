﻿using Microsoft.EntityFrameworkCore;
using CMSApplication.Contexts;
using CMSApplication.Identity;
using CMSApplication.Interfaces.Repositories;

namespace CMSApplication.Implementations.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IList<Role> GetRolesByUserId(int id)
        {
            var roles = _context.UserRoles.Include(r => r.Role).Where(x => x.UserId == id).Select(r => new Role
            {
                Name = r.Role.Name,
                Description = r.Role.Description
            }).ToList();
            return roles;
        }
    }
}
