using Core.Entities;


namespace Core.Interfaces
{
    public interface IPermissionsServices
    {
        Task<IEnumerable<Permissions>> GetPermissions();
    }
}
