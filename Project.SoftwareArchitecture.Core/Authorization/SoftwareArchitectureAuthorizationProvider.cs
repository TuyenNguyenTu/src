using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Project.SoftwareArchitecture.Authorization
{
    public class SoftwareArchitectureAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Administrators, L("Administrators"));
            context.CreatePermission(PermissionNames.Pages_QuanLys, L("QuanLys"));
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Doctors, L("Doctors"));
            context.CreatePermission(PermissionNames.Pages_Cashiers, L("Cashiers"));
            context.CreatePermission(PermissionNames.Pages_TiepBenhNhans, L("TiepBenhNhans"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SoftwareArchitectureConsts.LocalizationSourceName);
        }
    }
}
