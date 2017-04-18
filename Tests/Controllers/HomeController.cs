using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Tests.Models;
using Tests.Models.BLL;

namespace Tests.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            

            var incomeTypes=DAL.GetIncomeOptions();

            return Json(incomeTypes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IncomeMultiSelect()
        {
            ViewBag.Incomes = new MultiSelectList(DAL.GetIncomeOptions().ToList(), "IncomeTitle", "IncomeTitle");
            return View();
        }

        [HttpPost]
        public ActionResult IncomeMultiSelect(List<string> Incomes)
        {
            return View();
        }


        public ActionResult ShowStudents()
        {
            var lstStudents = DAL.GetAllStudents();
            return View(lstStudents);
        }

        public ActionResult NewStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                if (DAL.SaveStudent(s))
                {
                    return RedirectToAction("ShowStudents");
                }
                
            }
            return View(s);
        }

        public ActionResult PostListOfStudents()
        {
            return View(new BulkStudent());
        }
        [HttpPost]
        public ActionResult PostListOfStudents(BulkStudent bulk, IEnumerable<Student> lstStudent)
        {
            if (ModelState.IsValid)
            {
                if (DAL.SaveListOfStudents(lstStudent))
                {
                    return RedirectToAction("ShowStudents");
                }
            }
            return View();
        }


        public ActionResult TodoTask()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TodoTask(ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                DAL.SaveTask(toDo);
                return RedirectToAction("TodoTask");
            }

            return View(toDo);
        }
        public ActionResult ShowTasks()
        {
            var lst = DAL.GetAllTasks();
            return PartialView("ShowTasks", lst.ToList());
        }

    }
}