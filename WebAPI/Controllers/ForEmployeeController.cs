using HR.DataLayer.BizLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ForEmployeeController : Controller
    {
        // GET: ForEmployee
        public ActionResult Index()
        {
            var model = new BizEmployee();
            return View(model);
        }
    }
}