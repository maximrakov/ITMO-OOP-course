using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication666.Models;
using WebApplication666.Services;

namespace WebApplication666.Controllers
{
    public class MemberController : Controller
    {
        // GET: MemberController
        public ActionResult Index()
        {
            StuffMemberService stuffMemberService = new StuffMemberService();
            ViewData["members"] = stuffMemberService.GetAll();
            return View();
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            StuffMemberService stuffMemberService = new StuffMemberService();
            ViewBag.stuff = stuffMemberService.GetById(id);
            return View();
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
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

        public ActionResult Hierarchy()
        {
            StuffMemberService stuffMemberService = new StuffMemberService();
            List<List<StuffMember>> stuffMembers = new List<List<StuffMember>>();
            List<StuffMember> stuffMembers1 = stuffMemberService.GetAll();
            List<String> logins = new List<string>();
            foreach(StuffMember stuff in stuffMembers1)
            {
                stuffMembers.Add(stuff.employees);
                logins.Add(stuff.Login);
            }
            ViewData["stuff"] = stuffMembers;
            ViewData["logins"] = logins;
            return View();
        }
        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController/Edit/5
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

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Delete(string id)
        {
            StuffMemberService stuffMemberService = new StuffMemberService();
            stuffMemberService.DeleteMember(Int32.Parse(id));
            return Redirect("/Home/Index");
        }
    }
}
