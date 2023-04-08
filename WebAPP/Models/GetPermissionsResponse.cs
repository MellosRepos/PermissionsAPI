namespace WebAPP.Models
{
    public class GetPermissionsResponse
    {
        public int Id { get; set; }

        public string? EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string PermissionType { get; set; }

        public DateTime PermissionDate { get; set; }
    }
}
