using Core.Entities;
using Core.Entities.Contracts;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Infrastructure.Repositories
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly SQLServerDBContext _context;
        private readonly IElasticClient _elasticClient;
        private const string IndexName = "permissions";

        public PermissionsRepository(SQLServerDBContext context, IElasticClient elasticClient)
        {
            _context = context;
            _elasticClient = elasticClient;
        }

        public async Task<IEnumerable<Permissions>> FetchPermissionsRep()
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
        public async Task<Permissions> AddPermissionRep(PermissionRequestContract permission)
        {
            var permissionEntity = new Permissions
            {
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionTypeId = permission.PermissionTypeId,
                PermissionDate = DateTime.Now
            };
            await AddAsyncElastic(permissionEntity);
            _context.Permissions.Add(permissionEntity);
            await _context.SaveChangesAsync();
            return permissionEntity;
        }
        public async Task<Permissions> ModifyPermissionRep(Permissions permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        public async Task<IndexResponse> AddAsyncElastic(Permissions permission)
        {
            return await _elasticClient.IndexAsync(permission, i => i.Index(IndexName));
        }
    }
}
