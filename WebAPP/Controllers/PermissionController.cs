using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using WebAPP.Models;
using Microsoft.EntityFrameworkCore;
using Core.Services;
using Core.Interfaces;
using Core.Entities;
using System.Security;
using Core.Entities.Contracts;

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
        [Microsoft.AspNetCore.Mvc.Route("GetPermissions")]
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

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("RequestPermission")]
        public async Task<ActionResult<Permissions>> AddPermission(PermissionRequestBody permissionBody)
        {
            var permission = new PermissionRequestContract()
            {
                EmployeeFirstName = permissionBody.EmployeeFirstName,
                EmployeeLastName = permissionBody.EmployeeLastName,
                PermissionTypeId = permissionBody.PermissionTypeId
            };
            var newPermission = await _permissionServices.PostPermissionServ(permission);

            return newPermission;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("ModifyPermission")]
        public async Task<ActionResult<Permissions>> ModifyPermission(PermissionRequestBody permissionBody)
        {
            var permission = new PermissionRequestContract()
            {
                EmployeeFirstName = permissionBody.EmployeeFirstName,
                EmployeeLastName = permissionBody.EmployeeLastName,
                PermissionTypeId = permissionBody.PermissionTypeId
            };
            var newPermission = await _permissionServices.PostPermissionServ(permission);

            return newPermission;
        }

    }
}