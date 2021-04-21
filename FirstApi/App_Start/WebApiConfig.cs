using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FirstApi
{
    public static class WebApiConfig
    {
        // Web API configuration and services
        public static void Register(HttpConfiguration config)
        {
            //開啟Cors跨來源資源共用
            config.EnableCors(new EnableCorsAttribute(
            "*",
            "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers,Authorization",
            "*"
            ));

            // Enable Attribute Routing
            config.MapHttpAttributeRoutes();

            // Enable Convention-based routes
            // (to use ontop of Attribute Routing)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
        }
    }
}