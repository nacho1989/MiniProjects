using NServiceBus;
using System.Web.Http;

namespace ServerApplication.Controllers
{
    public class HomeController : ApiController
    {
        public IEndpointInstance instance;

        public HomeController(IEndpointInstance injected)
        {
            instance = injected;
        }

        public IHttpActionResult GetMessage()
        {
            return Ok("Hello");
        }
    }
}
