using APPers.Data;
using APPers.Models;
using APPers.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPers.Controllers
{
   
    public class BeerController : Controller
    {
        // GET: Beer
        public ActionResult Index()
        {

            var service = CreateBeerService();
            var model = service.GetBeers();

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
        public ActionResult Create(BeerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateBeerService();

            if (service.CreateBeer(model))
            {
                TempData["SaveResult"] = "Your beer was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Beer could not be added.");

            return View(model);
        }

        private BeerService CreateBeerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeerService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBeerService();
            var model = svc.GetBeerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBeerService();
            var detail = service.GetBeerById(id);
            var model =
                new BeerEdit
                {
                    BeerId = detail.BeerId,
                    BeerName = detail.BeerName,
                    InventoryCount = detail.InventoryCount,
                    TypeOfBeer = detail.TypeOfBeer,
                    Price = detail.Price,
                    ImageURL = detail.ImageURL,
                    Description = detail.Description,
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BeerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBeerService();

            if (service.UpdateBeer(model))
            {
                TempData["SaveResult"] = "Your beer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your beer could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBeerService();
            var model = svc.GetBeerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBeerService();

            service.DeleteBeer(id);

            TempData["SaveResult"] = "Your beer was deleted";

            return RedirectToAction("Index");
        }

    }
}