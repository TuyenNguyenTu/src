using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Project.SoftwareArchitecture.Authorization.Users;
using Project.SoftwareArchitecture.MultiTenancy;
using Project.SoftwareArchitecture.Users;
using Microsoft.AspNet.Identity;

namespace Project.SoftwareArchitecture
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SoftwareArchitectureAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SoftwareArchitectureAppServiceBase()
        {
            LocalizationSourceName = SoftwareArchitectureConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}