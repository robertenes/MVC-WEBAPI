using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EMPLOYEE_INSERT_WEBAPI.Models;
namespace EMPLOYEE_INSERT_WEBAPI.Controllers
{
    public class HomeController : Controller
    {
        EmployeeEntities context = new EmployeeEntities();
        public ActionResult Index()
        {
            IList<Employee> emp = null;
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("http://localhost:52407/api/EmployeeAPI");

            var apiempcontroller = ht.GetAsync("EmployeeAPI");
            apiempcontroller.Wait();

            var resultdisplay = apiempcontroller.Result;
            if(resultdisplay.IsSuccessStatusCode)
            {
                var readtemp = resultdisplay.Content.ReadAsAsync<IList<Employee>>();
                readtemp.Wait();
                emp = readtemp.Result;
            }
            else
            {
                ViewBag.Messagge = "No result...";
            }

            return View(emp);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("http://localhost:52407/api/EmployeeAPI");

            var insertrecord = ht.PostAsJsonAsync<Employee>("EmployeeAPI", emp);
            insertrecord.Wait();

            var recorddisplay = insertrecord.Result;
            if(recorddisplay.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
          
            return View();
        }

    }
}
