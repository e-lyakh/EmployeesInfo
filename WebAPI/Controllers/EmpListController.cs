using HR.DataLayer.BizLayer;
using HR.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class EmpListController : Controller
    {
        // GET: EmpList
        IEntityService<BizEmployee> BizEmployeeService = new BizEmployeeService();

        public ActionResult Index()
        {
            var model = BizEmployeeService.GetAll();
            return View(model);
        }
    }
}