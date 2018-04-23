using HR.DataLayer.BizLayer;
using HR.DataLayer.DbLayer;
using HR.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers.WebAPI
{
    public class EmployeeController : ApiController
    {
        //HrContext context = new HrContext();
        IEntityService<BizEmployee> BizEmployeeService = new BizEmployeeService();

        public IEnumerable<BizEmployee> GetAll()
        {
            return BizEmployeeService.GetAll();
        }

        public BizEmployee Get(int id)
        {
            return BizEmployeeService.Get(id);
        }        

        //For both Post (add) and Put (update)      
        public void Post(BizEmployee employee)
        {
            if(employee != null)
                BizEmployeeService.AddOrUpdate(employee);            
        }
        
        public void Delete(int id)
        {
            var emp = BizEmployeeService.Get(id);
            BizEmployeeService.Delete(emp);
        }
    }
}