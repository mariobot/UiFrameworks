using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Materializecss.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() { return View(); }      

        public ActionResult Buttons() { return View(); }

        public ActionResult Cards() { return View(); }

        public ActionResult Collapsible() { return View(); }

        public ActionResult Typography() { return View(); }

        public ActionResult Media() { return View(); }

        public ActionResult Forms() { return View(); }                

        public ActionResult Dialogs() { return View(); }

        public ActionResult Modals() { return View(); }

        public ActionResult Tabs() { return View(); }
    }
}
