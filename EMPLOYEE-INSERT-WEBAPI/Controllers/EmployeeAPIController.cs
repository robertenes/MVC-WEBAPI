using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMPLOYEE_INSERT_WEBAPI.Models;
namespace EMPLOYEE_INSERT_WEBAPI.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        EmployeeEntities context = new EmployeeEntities();
        [HttpGet]
        public IHttpActionResult SelectList()
        {
            IList<Employee> emp = context.TABLE_EMPLOYEE.Include("TABLE_EMPLOYEE").Select(x => new Employee()
            {
                ID = x.ID,
                EMPLOYEEAGE = x.EMPLOYEEAGE,
                EMPLOYEEMAIL = x.EMPLOYEEMAIL,
                EMPLOYEENAME = x.EMPLOYEENAME,
                EMPLOYEESURNAME = x.EMPLOYEESURNAME
            }).ToList<Employee>();

            return Ok(emp);
        }
        [HttpPost]
        public IHttpActionResult Create(Employee emp)
        {
            context.TABLE_EMPLOYEE.Add(new TABLE_EMPLOYEE()
            {
                EMPLOYEEAGE = emp.EMPLOYEEAGE,
                EMPLOYEEMAIL = emp.EMPLOYEEMAIL,
                EMPLOYEENAME = emp.EMPLOYEESURNAME,
                EMPLOYEESURNAME = emp.EMPLOYEESURNAME
            });
            context.SaveChanges();
            return Ok();
        }
    }
}
