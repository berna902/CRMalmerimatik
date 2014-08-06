using Clientes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Clientes
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        void Session_Start(object sender, EventArgs e)
        {
            //Application["historial"] = new ArrayList();
            List<ERROR> historial = new List<ERROR>();
            Session["historial"] = historial;
        }
        
    }
}