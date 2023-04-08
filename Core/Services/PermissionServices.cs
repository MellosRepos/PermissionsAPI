using Core.Entities;
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
            return await _permissionsRepository.FetchPermissions();
        }
    }
}