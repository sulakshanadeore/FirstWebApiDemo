﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Models
{
    public class ErrorHandlingByUser:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            filterContext.Result = new ViewResult() { ViewName = "Error", ViewData = new ViewDataDictionary(model) };
            //base.OnException(filterContext);
        }

    }
}