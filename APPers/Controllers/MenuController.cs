using APPers.Data;
using APPers.Models.Menu;
using APPers.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace APPers.Controllers
{
    public class MenuController : Controller
    {


        // GET: Menu
        public ActionResult Index()
        {

            var service = CreateMenuService();
            var model = service.GetAllOrders();

            return View(model);
        }


        public ActionResult OrderHistory()
        {

            var service = CreateMenuService();
            var model = service.GetMenus();

            return View(model);
        }


        //GET
        public ActionResult Create()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());

            List<Beer> Beers = new BeerService().GetBeersDropDown().ToList();
            ViewBag.BeerMenu = new BeerService().GetBeersDropDown().ToList();


            List<Beer> BeersInStock = new List<Beer>();
            foreach (Beer beer in Beers)
            {
                if (beer.InRotation == true)
                {
                    BeersInStock.Add(beer);
                }
            }

            //Beers.Select(b => new SelectListItem() { });
            var query = from b in BeersInStock
                        select new SelectListItem()
                        {
                            Value = b.BeerId.ToString(),
                            Text = b.BeerName + " $" + b.Price
                        };

            ViewBag.BeerId = query.ToList();


            //Generate Drop Down for Tabs
            List<Tab> Tabs = new TabService().GetTabsDropDown().ToList();

            List<Tab> OpenTabs = new List<Tab>();
            foreach (Tab tab in Tabs)
            {
                if (tab.OwnerId == userId)
                {
                    if (tab.TabPaid == false)
                    {
                        OpenTabs.Add(tab);
                    }
                }
            }


            var query2 = from t in OpenTabs
                             //.Where(e => e.OwnerId == userId)
                         select new SelectListItem()
                         {
                             Value = t.TabId.ToString(),
                             Text = t.Name,
                         };
            ViewBag.TabId = query2.ToList();

            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMenuService();

            if (service.CreateMenu(model))
            {
                TempData["SaveResult"] = $"Your drink is on the way to the {model.Location} station!";
                return RedirectToAction("Index", "Home");
            };

            ModelState.AddModelError("", "Your drink could not be ordered.");

            return View(model);
        }

        private MenuService CreateMenuService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MenuService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMenuService();
            var model = svc.GetMenuById(id);




            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMenuService();
            var detail = service.GetMenuById(id);

            List<Beer> Beers = new BeerService().GetBeersDropDown().ToList();
            List<Beer> BeersInStock = new List<Beer>();
            foreach (Beer beer in Beers)
            {
                if (beer.InRotation == true)
                {
                    BeersInStock.Add(beer);
                }
            }


            ViewBag.BeerId = BeersInStock.Select(b => new SelectListItem()
            {
                Value = b.BeerId.ToString(),
                Text = b.BeerName + " $" + b.Price,
                Selected = detail.BeerId == b.BeerId
            });

            //ViewBag.BeerId = query.ToList();

            List<Tab> Tabs = new TabService().GetTabsDropDown().ToList();

            List<Tab> OpenTabs = new List<Tab>();
            foreach (Tab tab in Tabs)
            {
                if (tab.TabPaid == false)
                {
                    OpenTabs.Add(tab);
                }
            }


            var query2 = from t in OpenTabs
                             //.Where(e => e.OwnerId == _userId)
                         select new SelectListItem()
                         {
                             Value = t.TabId.ToString(),
                             Text = t.Name,
                         };
            ViewBag.TabId = query2.ToList();


            var model =
                new MenuEdit
                {
                    OrderId = detail.OrderId,
                    TabId = detail.TabId,
                    Location = detail.Location,
                    BeerId = detail.BeerId,
                    OrderComplete = detail.OrderComplete,
                    OrderTotal = detail.OrderTotal,
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrderId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMenuService();

            if (!service.UpdateMenu(model) && !service.UpdateKeys(model))
            {
                TempData["SaveResult"] = "Your order was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your order could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMenuService();
            var model = svc.GetMenuById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMenuService();

            service.DeleteMenu(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

    }
}