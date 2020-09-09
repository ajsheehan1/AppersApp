using APPers.Data;
using APPers.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Services
{
    public class MenuService
    {
        private readonly Guid _userId;

        public MenuService(Guid userId)
        {
            _userId = userId;
        }

        public MenuService()
        {
        }

        public bool CreateMenu(MenuCreate model)
        {
            var entity =
                new Menu()
                {
                    OwnerId = _userId,
                    Location = model.Location,
                    BeerId = model.BeerId,
                    TabId = model.TabId, 
                    //OrderTotal = model.Beer.Price,
                    //BeerName = model.Beer.BeerName,
                    //TabName = model.Tab.Name,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menus.Add(entity);
                bool addedOrder = ctx.SaveChanges() == 1;
                if (!addedOrder) { return false; }
            }

            using (var ctx = new ApplicationDbContext())
            {
                var newMenu =
                    ctx
                        .Beers
                        .Single(e => e.BeerId == entity.BeerId);
                newMenu.InventoryCount -= 1;
                

                bool addedOrder = ctx.SaveChanges() == 1;
                if (!addedOrder) { return false; }

            }

            using (var ctx = new ApplicationDbContext())
            {
                var newTab =
                    ctx
                        .Menus
                        .Single(e => e.OrderId == entity.OrderId);
                newTab.Tab.GrandTotal = newTab.Tab.GrandTotal + newTab.Beer.Price; 

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<MenuListItem> GetMenus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menus
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    OrderId = e.OrderId,
                                    Location = e.Location,
                                    TabId = e.TabId,
                                    TabName = e.Tab.Name,
                                    BeerId = e.BeerId,
                                    BeerName = e.Beer.BeerName,
                                    OrderTotal = e.Beer.Price, // Multiple order total listed here or somewhere else?
                                    OrderComplete = e.OrderComplete,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<MenuListItem> GetAllOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menus
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    OrderId = e.OrderId,
                                    Location = e.Location,
                                    TabId = e.TabId,
                                    TabName = e.Tab.Name,
                                    BeerId = e.BeerId,
                                    BeerName = e.Beer.BeerName,
                                    OrderTotal = e.Beer.Price, // Multiple order total listed here or somewhere else?
                                    OrderComplete = e.OrderComplete,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }



        public IEnumerable<MenuListItem> GetOrdersDropDown()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menus
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    OrderId = e.OrderId,
                                    Location = e.Location,
                                    TabId = e.TabId,
                                    TabName = e.Tab.Name,
                                    BeerId = e.BeerId,
                                    BeerName = e.Beer.BeerName,
                                    OrderTotal = e.Beer.Price, // Multiple order total listed here or somewhere else?
                                    OrderComplete = e.OrderComplete,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToList();
            }

        }

        public MenuDetail GetMenuById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.OrderId == id);
                return
                    new MenuDetail
                    {
                        OrderId = entity.OrderId,
                        Location = entity.Location,
                        TabId = entity.TabId,
                        TabName = entity.Tab.Name,
                        BeerId = entity.BeerId,
                        BeerName = entity.Beer.BeerName,
                        OrderTotal = entity.Beer.Price,
                        OrderComplete = entity.OrderComplete,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }

        }


        public bool UpdateMenu(MenuEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.OrderId == model.OrderId);

                // Subtract old beer count and money on tab
                entity.Tab.GrandTotal = entity.Tab.GrandTotal - entity.Beer.Price;
                entity.Beer.InventoryCount = entity.Beer.InventoryCount + 1;

                entity.OrderId = model.OrderId;
                entity.Location = model.Location;
                entity.TabId = model.TabId;
                //entity.OrderTotal = model.OrderTotal;
                entity.BeerId = model.BeerId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.OrderComplete = model.OrderComplete;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateKeys(MenuEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.OrderId == model.OrderId);

                //Update inventory of new beer chosen and/or new tab
                entity.Tab.GrandTotal = entity.Tab.GrandTotal + entity.Beer.Price;
                entity.Beer.InventoryCount = entity.Beer.InventoryCount - 1;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMenu(int orderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.OrderId == orderId && e.OwnerId == _userId);

                entity.Tab.GrandTotal = entity.Tab.GrandTotal - entity.Beer.Price;
                entity.Beer.InventoryCount = entity.Beer.InventoryCount + 1;

                ctx.Menus.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

    }
}