using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using WebAPP.Models;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Core.Interfaces;
using Core.Entities;

namespace WebAPP.Controllers
{


    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsServices _permissionServices;
        private static readonly List<GetPermissionsResponse> _permissions = new List<GetPermissionsResponse>
        {
            new GetPermissionsResponse { Id = 1, EmployeeFirstName = "John", EmployeeLastName = "Doe", PermissionType = "Admin", PermissionDate = DateTime.Now },
            new GetPermissionsResponse { Id = 2, EmployeeFirstName = "Jane", EmployeeLastName = "Doe", PermissionType = "User", PermissionDate = DateTime.Now }
        };
        public PermissionsController(IPermissionsServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<GetPermissionsResponse>>> RetrievePermissions()
        {
            var PermissionsList = await _permissionServices.GetPermissions();
            var GetPermissionsResponse = new List<GetPermissionsResponse>();
            foreach (var permission in PermissionsList)
            {
                GetPermissionsResponse.Add(new GetPermissionsResponse
                {
                    Id = permission.Id,
                    EmployeeFirstName = permission.EmployeeFirstName,
                    EmployeeLastName = permission.EmployeeLastName,
                    PermissionType = "test",
                    PermissionDate = permission.PermissionDate
                });
            }
            return GetPermissionsResponse;
        }
        //<summary>
        // This is the controller for the Permissions API
        //</summary>
        //<param name="id">The id of the permission</param>
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<GetPermissionsResponse>> RetrievePermissionsById(int id)
        {
            var permission = _permissions.Find(p => p.Id == id);

            if (permission == null)
            {
                return NotFound();
            }

            return permission;
        }
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public async Task<ActionResult> ModifyPermission(ModifyPermissionRequestBody modifyPermissionRequestBody)
        {
            // Your code here
            return Ok();

        }

    }
}