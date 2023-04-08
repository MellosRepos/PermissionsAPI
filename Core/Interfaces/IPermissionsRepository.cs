
using Core.Entities;
using Core.Entities.Contracts;

namespace Core.Interfaces
{
    public interface IPermissionsRepository
    {
        Task<IEnumerable<Permissions>> FetchPermissionsRep();

        Task<Permissions> AddPermissionRep(PermissionRequestContract permission);

        Task<Permissions> ModifyPermissionRep(Permissions permission);

    }
}
