using HR.DataLayer.BizLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AutoMapper;
using HR.DataLayer.DbLayer;
using Step.Repository.Common;

namespace HR.DataLayer.Repositories
{
    public class BizEmployeeService : IEntityService<BizEmployee>
    {
        // добавим пакет AutoMapper
        IGenericRepository<Employee> employeeRep = new EmployeeRepository(new HrContext());
        IMapper mapper;

        public BizEmployeeService()
        {
            var config = new MapperConfiguration(c => c.CreateMap<Employee, BizEmployee>());
            mapper = config.CreateMapper();
            var config1 = new MapperConfiguration(c => c.CreateMap<BizEmployee, Employee>());
            mapper = config1.CreateMapper();
        }

        public IQueryable<BizEmployee> GetAll()
        {
            return employeeRep.GetAll()
                .ToList()
                .Select(e => mapper.Map<BizEmployee>(e)).AsQueryable();
        }

        public BizEmployee Get(int id)
        {
            return mapper.Map<BizEmployee>(employeeRep.Get(id));
        }

        public BizEmployee AddOrUpdate(BizEmployee obj)
        {
            Employee emp = mapper.Map<Employee>(obj);
            employeeRep.AddOrUpdate(emp);
            return mapper.Map<BizEmployee>(emp);
        }

        public BizEmployee Delete(BizEmployee obj)
        {
            Employee emp = employeeRep.Get(obj.EmployeeId);
            employeeRep.Delete(emp);
            //return mapper.Map<BizEmployee>(emp);
            return obj;
        }

        public IQueryable<BizEmployee> FindBy(Expression<Func<BizEmployee, bool>> predicate)
        {
            return GetAll()
                .ToList()
                .Select(e => mapper.Map<BizEmployee>(e))
                .AsQueryable()
                .Where(predicate);
        }
    }
}