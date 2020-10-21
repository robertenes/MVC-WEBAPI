using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMPLOYEE_INSERT_WEBAPI.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string EMPLOYEENAME { get; set; }
        public string EMPLOYEESURNAME { get; set; }
        public string EMPLOYEEAGE { get; set; }
        public string EMPLOYEEMAIL { get; set; }
    }
}