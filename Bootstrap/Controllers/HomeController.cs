﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public ActionResult Index()
        {
	  return View();
        }
    }
}
