using Abp.Authorization;
using Project.SoftwareArchitecture.Authorization.Roles;
using Project.SoftwareArchitecture.Authorization.Users;

namespace Project.SoftwareArchitecture.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
