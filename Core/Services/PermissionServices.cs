using Core.Entities;
using Core.Entities.Contracts;
using Core.Interfaces;



namespace Core.Services
{
    public class PermissionServices : IPermissionsServices
    {
        private readonly IPermissionsRepository _permissionsRepository;
        public PermissionServices(IPermissionsRepository permissionsRepository)
        {
            _permissionsRepository = permissionsRepository;

        }
        public async Task<IEnumerable<Permissions>> GetPermissions()
        {
            return await _permissionsRepository.FetchPermissionsRep();
        }

        public async Task<Permissions> PostPermissionServ(PermissionRequestContract permission)
        {

            var addedPermission = await _permissionsRepository.AddPermissionRep(permission);
            return addedPermission;

        }

        public async Task<Permissions> PutPermissionServ(PermissionModifyRequestContract permission)
        {
            var permissionEntity = new Permissions
            {
                Id = permission.Id,
                EmployeeFirstName = permission.EmployeeFirstName,
                EmployeeLastName = permission.EmployeeLastName,
                PermissionTypeId = permission.PermissionTypeId,
                PermissionDate = DateTime.Now,
            };
            return await _permissionsRepository.ModifyPermissionRep(permissionEntity);
        }
    }
}