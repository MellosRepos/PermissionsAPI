
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPermissionsRepository
    {
        Task<IEnumerable<Permissions>> FetchPermissions();
    }
}
