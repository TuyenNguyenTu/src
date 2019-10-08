using Abp.MultiTenancy;
using Project.SoftwareArchitecture.Authorization.Users;

namespace Project.SoftwareArchitecture.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}