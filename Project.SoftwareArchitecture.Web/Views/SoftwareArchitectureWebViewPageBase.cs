using Abp.Web.Mvc.Views;

namespace Project.SoftwareArchitecture.Web.Views
{
    public abstract class SoftwareArchitectureWebViewPageBase : SoftwareArchitectureWebViewPageBase<dynamic>
    {

    }

    public abstract class SoftwareArchitectureWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SoftwareArchitectureWebViewPageBase()
        {
            LocalizationSourceName = SoftwareArchitectureConsts.LocalizationSourceName;
        }
    }
}