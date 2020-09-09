using APPers.Data;
using APPers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Services
{
    public class BeerService
    {
        private readonly Guid _userId;

        public BeerService(Guid userId)
        {
            _userId = userId;
        }

        public BeerService()
        {
        }

        public bool CreateBeer(BeerCreate model)
        {
            var entity =
                new Beer()
                {
                    OwnerId = _userId,
                    BeerName = model.BeerName,
                    InventoryCount = model.InventoryCount,
                    TypeOfBeer = model.TypeOfBeer,
                    Price = model.Price,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now,
                    ImageURL = model.ImageURL,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Beers.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<BeerListItem> GetBeers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Beers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new BeerListItem
                                {
                                    BeerId = e.BeerId,
                                    BeerName = e.BeerName,
                                    InventoryCount = e.InventoryCount,
                                    TypeOfBeer = e.TypeOfBeer,
                                    Price = e.Price,
                                    //InRotation = e.InRotation,
                                    ImageURL = e.ImageURL,
                                    CreatedUtc = e.CreatedUtc
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<Beer> GetBeersDropDown()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Beers.ToList();
            }

        }
        public BeerDetail GetBeerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == id && e.OwnerId == _userId);
                return
                    new BeerDetail
                    {
                        BeerId = entity.BeerId,
                        BeerName = entity.BeerName,
                        InventoryCount = entity.InventoryCount,
                        TypeOfBeer = entity.TypeOfBeer,
                        Price = entity.Price,
                        ImageURL = entity.ImageURL,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        Description = entity.Description,
                    };
            }

        }


        public bool UpdateBeer(BeerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == model.BeerId && e.OwnerId == _userId);

                entity.BeerId = model.BeerId;
                entity.BeerName = model.BeerName;
                entity.InventoryCount = model.InventoryCount;
                entity.TypeOfBeer = model.TypeOfBeer;
                entity.Price = model.Price;
                entity.ImageURL = model.ImageURL;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.Description = model.Description;
                //entity.InRotation = model.InRotation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBeer(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == noteId && e.OwnerId == _userId);

                ctx.Beers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
