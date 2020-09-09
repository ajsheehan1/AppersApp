using APPers.Data;
using APPers.Models.Menu;
using APPers.Models.Tab;
using APPers.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPers.Controllers
{
    public class TabController : Controller
    {
        // GET: Tab
        public ActionResult Index()
        {

            var service = CreateTabService();
            var model = service.GetTabs();

            return View(model);
        }

        public ActionResult MyTabs()
        {

            var service = CreateTabService();
            var model = service.GetTabs();

            return View(model);
        }


        // GET: Tab
        public ActionResult TabsAdminView()
        {

            var service = CreateTabService();
            var model = service.GetTabsAdmin();

            return View(model);
        }



        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TabCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateTabService();

            if (service.CreateTab(model))
            {
                TempData["SaveResult"] = "Your tab was created!";
                return RedirectToAction("Index","Home");
            };

            ModelState.AddModelError("", "Tab could not be added.");

            return View(model);
        }

        private TabService CreateTabService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TabService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTabService();
            var model = svc.GetTabById(id);

            var allDetails = new MenuService().GetOrdersDropDown().ToList();

            List<MenuListItem> orderDetails = new List<MenuListItem>();
            foreach (MenuListItem menu in allDetails)
            {
                if (menu.TabId == id)
                {
                    orderDetails.Add(menu);
                }
            }

            ViewBag.OrderDetails = orderDetails;

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTabService();
            var detail = service.GetTabById(id);
            var model =
                new TabEdit
                {
                    TabId = detail.TabId,
                    Name = detail.Name,
                    TabPaid = detail.TabPaid,
                    GrandTotal = detail.GrandTotal,
                   
                };


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TabEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TabId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTabService();

            if (service.UpdateTab(model))
            {
                TempData["SaveResult"] = "Process complete, thanks for choosing APPers!!";
                return RedirectToAction("Index", "Home");
            };

            ModelState.AddModelError("", "There was an error, please try again.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTabService();
            var model = svc.GetTabById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTabService();

            service.DeleteTab(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

    }
}