using Abp.AutoMapper;
using Project.SoftwareArchitecture.Sessions.Dto;

namespace Project.SoftwareArchitecture.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}