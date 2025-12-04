using Microsoft.AspNetCore.Authorization;

namespace AuthLibrary.Permissions
{
    //hhhhhh//ahdgdf
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; set; }
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}