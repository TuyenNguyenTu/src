using System.Threading.Tasks;
using Abp.Application.Services;
using Project.SoftwareArchitecture.Authorization.Accounts.Dto;

namespace Project.SoftwareArchitecture.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
