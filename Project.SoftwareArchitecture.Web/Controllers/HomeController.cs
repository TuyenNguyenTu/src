using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Project.SoftwareArchitecture.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SoftwareArchitectureControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}