using APPers.Models;
using APPers.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APPers.Controllers.WebAPI
{
    [System.Web.Mvc.Authorize]
    [System.Web.Mvc.RoutePrefix("api/Beer")]
    public class BeerController : ApiController
    {
        private bool SetStarState(int beerId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeerService(userId);

            // Get the note
            var detail = service.GetBeerById(beerId);

            // Create the BeerEdit model instance with the new star state
            var updatedBeer =
                new BeerEdit
                {
                    BeerId = detail.BeerId,
                    BeerName = detail.BeerName,
                    InventoryCount = detail.InventoryCount,
                    TypeOfBeer = detail.TypeOfBeer,
                    Price = detail.Price,
                    Description = detail.Description,
                    InRotation = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateBeer(updatedBeer);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}