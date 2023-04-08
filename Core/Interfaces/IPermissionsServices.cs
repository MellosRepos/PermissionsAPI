using Core.Entities;
using Core.Entities.Contracts;


namespace Core.Interfaces
{
    public interface IPermissionsServices
    {
        Task<IEnumerable<Permissions>> GetPermissions();

        Task<Permissions> PostPermissionServ(PermissionRequestContract permission);

        Task<Permissions> PutPermissionServ(PermissionModifyRequestContract id);

    }
}
