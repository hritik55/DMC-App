﻿using System.Web;
using System.Web.Mvc;

namespace Diagnostic_Medical_Center
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
