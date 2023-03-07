﻿using Microsoft.EntityFrameworkCore;
using CMSApp.Contexts;
using CMSApp.Identity;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
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
