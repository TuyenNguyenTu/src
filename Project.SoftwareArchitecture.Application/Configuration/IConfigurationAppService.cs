using System.Threading.Tasks;
using Abp.Application.Services;
using Project.SoftwareArchitecture.Configuration.Dto;

namespace Project.SoftwareArchitecture.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}