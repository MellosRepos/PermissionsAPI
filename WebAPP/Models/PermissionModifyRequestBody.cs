namespace WebAPP.Models
{
    public class PermissionModifyRequestBody
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public int PermissionTypeId { get; set; }

    }
}
