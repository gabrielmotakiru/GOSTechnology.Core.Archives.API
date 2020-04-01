using GOSTechnology.Core.Archives.Api.Infra;
using GOSTechnology.Core.Archives.Domain.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace GOSTechnology.Core.Archives.Controllers
{
    /// <summary>
    /// HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Redirect(ConstantsConfiguration.SWAGGER_ROUTE);
        }
    }
}
