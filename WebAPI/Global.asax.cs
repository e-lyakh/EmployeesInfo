﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace WebAPI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Игнорирование циклических ссылок
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.
               SerializerSettings.ReferenceLoopHandling =
               Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //Возвращать данные ТОЛЬКО в формате JSON!
            GlobalConfiguration.Configuration.
                Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);



            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}