using System.Threading.Tasks;
using Abp.Application.Services;
using Project.SoftwareArchitecture.Sessions.Dto;

namespace Project.SoftwareArchitecture.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
