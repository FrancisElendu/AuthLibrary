using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Constants.Authentication
{
    //hhhhhh//ahdgdf
    public record AppPermission(string Service, string Feature, string Action, string Group, string Description, bool IsBasic=false)
    {
        public string Name => NameFor(Service, Feature, Action);
        public static string NameFor(string service, string feature, string action)
            => $"Permission.{service}.{feature}.{action}";
    }

    public class AppPermissions
    {
        private static readonly AppPermission[] _allPermissions =
        {
            //user permissions
            new AppPermission(AppService.Identity, AppFeature.Users, AppAction.Create, AppRoleGroup.SystemAccess, "Create Users"),
            new AppPermission(AppService.Identity, AppFeature.Users, AppAction.Read, AppRoleGroup.SystemAccess, "Read Users"),
            //new AppPermission(AppService.Identity, AppFeature.Users, AppAction.Read, AppRoleGroup.SystemAccess, "Read Users", true),
            new AppPermission(AppService.Identity, AppFeature.Users, AppAction.Update, AppRoleGroup.SystemAccess, "Update Users"),
            new AppPermission(AppService.Identity, AppFeature.Users, AppAction.Delete, AppRoleGroup.SystemAccess, "Delete Users"),
            
            //role permissions
            new AppPermission(AppService.Identity, AppFeature.Roles, AppAction.Create, AppRoleGroup.SystemAccess, "Create Roles"),
            new AppPermission(AppService.Identity, AppFeature.Roles, AppAction.Read, AppRoleGroup.SystemAccess, "Read Roles"),
            //new AppPermission(AppService.Identity, AppFeature.Roles, AppAction.Read, AppRoleGroup.SystemAccess, "Read Roles", true),
            new AppPermission(AppService.Identity, AppFeature.Roles, AppAction.Update, AppRoleGroup.SystemAccess, "Update Roles"),
            new AppPermission(AppService.Identity, AppFeature.Roles, AppAction.Delete, AppRoleGroup.SystemAccess, "Delete Roles"),

            //userRoles permissions
            new AppPermission(AppService.Identity, AppFeature.UserRoles, AppAction.Read, AppRoleGroup.SystemAccess, "Read User Roles"),
            new AppPermission(AppService.Identity, AppFeature.UserRoles, AppAction.Update, AppRoleGroup.SystemAccess, "Update User Roles"),

            //RoleClaims permissions
            new AppPermission(AppService.Identity, AppFeature.RoleClaims, AppAction.Read, AppRoleGroup.SystemAccess, "Read Role Claims/Permissions"),
            new AppPermission(AppService.Identity, AppFeature.RoleClaims, AppAction.Update, AppRoleGroup.SystemAccess, "Update Role Claims/Permissions")
        };

        public static IReadOnlyList<AppPermission> AdminPermissions { get; } = 
            new ReadOnlyCollection<AppPermission>(_allPermissions.Where(p => !p.IsBasic).ToArray()
        );

        public static IReadOnlyList<AppPermission> BasicPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_allPermissions.Where(p => p.IsBasic).ToArray()
        );

        public static IReadOnlyList<AppPermission> AllPermissions { get; } =
            new ReadOnlyCollection<AppPermission>(_allPermissions);

    }
}
