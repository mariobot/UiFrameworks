using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Bootstrap.Models;

namespace Bootstrap.Controllers
{
    public class ProductsController : Controller
    {   
        public ProductsController(){}

        public ActionResult Index()
        { 
	  return View();
        }
    }
}
