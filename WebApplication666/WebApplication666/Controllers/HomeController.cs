using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Models;
using WebApplication666.Repositories;
using WebApplication666.Services;

namespace WebApplication666.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Enter(string login)
        {
            StuffMemberService stuffMemberService = new StuffMemberService();
            stuffMemberService.addMember(login);
            return Redirect("/Home/Index");
        }

        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult EnterForm(string id)
        {
            Response.Cookies.Append("uid", id);
            return Redirect("/Home/Index");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Problem(string State, string Info)
        {
            TaskService taskRepository = new TaskService();
            taskRepository.addTask(Info);
            return Redirect("/Home/Index");
        }

        public IActionResult Problem()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            TaskService taskRepository = new TaskService();
            //ViewBag["model"] = ;
            return View(taskRepository.FindAll());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Appoint() {
            return View();
        }

        [HttpPost]
        public RedirectResult Appoint(string employer, string employment)
        {
            StuffMemberService stuffMember = new StuffMemberService();
            stuffMember.Appoint(employer, employment);
            return Redirect("Home/Index");
        }
    }
}
