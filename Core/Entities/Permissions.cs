

namespace Core.Entities
{
    public class Permissions
    {
        public int Id { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public int PermissionTypeId { get; set; }

        public DateTime PermissionDate { get; set; }


    }
}
