using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Services;

namespace WebApplication666.Controllers
{
    public class TaskController : Controller
    {
        // GET: TaskController
        public ActionResult Index()
        {
            TaskService taskService = new TaskService();
            ViewData["problems"] = taskService.FindAll();
            return View();
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            TaskService taskService = new TaskService();
            ViewBag.task = taskService.FindById(id);
            string txt = "";
            return View();
        }

        public ActionResult AddComments()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult AddComments(string id, string mess)
        {
            TaskService taskService = new TaskService();
            string cook = Request.Cookies["uid"];
            taskService.AddComments(Request.Cookies["uid"], Int32.Parse(id), mess);
            return Redirect("/Home/Index");
        }
        // GET: TaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
