using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Project.SoftwareArchitecture.Configuration.Dto;

namespace Project.SoftwareArchitecture.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SoftwareArchitectureAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
