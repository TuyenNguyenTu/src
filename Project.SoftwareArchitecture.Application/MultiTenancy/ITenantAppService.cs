using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project.SoftwareArchitecture.MultiTenancy.Dto;

namespace Project.SoftwareArchitecture.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
