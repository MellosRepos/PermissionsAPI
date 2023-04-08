using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly SQLServerDBContext _context;

        public PermissionsRepository(SQLServerDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permissions>> FetchPermissions()
        {
            var permissions = new List<Permissions>();
            permissions = await (from p in _context.Permissions
                                 join pt in _context.PermissionTypes on p.PermissionTypeId equals pt.Id
                                 select new Permissions
                                 {
                                     Id = p.Id,
                                     EmployeeFirstName = p.EmployeeFirstName,
                                     EmployeeLastName = p.EmployeeLastName,
                                     PermissionTypeId = p.PermissionTypeId,
                                     PermissionDate = p.PermissionDate,
                                 }).ToListAsync();
            return permissions;
        }
    }
}
