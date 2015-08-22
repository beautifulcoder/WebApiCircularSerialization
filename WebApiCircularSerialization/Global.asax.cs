using System.Web;
using System.Web.Http;

namespace WebApiCircularSerialization
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
