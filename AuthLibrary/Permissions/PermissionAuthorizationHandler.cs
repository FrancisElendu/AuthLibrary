using AuthLibrary.Constants.Authentication;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Permissions
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {
                
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if(context.User == null)
            {
                await Task.CompletedTask;
            }

            var permissions = context.User.Claims
                .Where(c => c.Type == AppClaim.Permission
                    && c.Value == requirement.Permission
                    && c.Issuer == AppClaim.Issuer);
            if (permissions.Any())
            {
                context.Succeed(requirement);
                await Task.CompletedTask;
            }
        }
    }
}
