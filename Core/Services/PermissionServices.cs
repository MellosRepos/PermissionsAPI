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

        public async Task<Permissions> PutPermissionServ(Permissions permission)
        {
            return await _permissionsRepository.ModifyPermissionRep(permission);
        }
    }
}