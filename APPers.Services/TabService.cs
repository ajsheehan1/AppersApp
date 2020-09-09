using APPers.Data;
using APPers.Models.Tab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPers.Services
{
    public class TabService
    {
        private readonly Guid _userId;

        public TabService(Guid userId)
        {
            _userId = userId;
        }

        public TabService()
        {
        }

        public bool CreateTab(TabCreate model)
        {
            var entity =
                new Tab()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    CreatedUtc = DateTimeOffset.UtcNow,
                    Signature = model.Signature
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tabs.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<TabListItem> GetTabs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tabs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TabListItem
                                {
                                    TabId = e.TabId,
                                    Name = e.Name,
                                    GrandTotal = e.GrandTotal,
                                    ModifiedUtc = e.ModifiedUtc,
                                    CreatedUtc = e.CreatedUtc,
                                    TabPaid = e.TabPaid
                                }
                        );

                return query.ToArray();
            }
        }


        public IEnumerable<TabListItem> GetTabsAdmin()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tabs
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TabListItem
                                {
                                    TabId = e.TabId,
                                    Name = e.Name,
                                    GrandTotal = e.GrandTotal,
                                    ModifiedUtc = e.ModifiedUtc,
                                    CreatedUtc = e.CreatedUtc,
                                    TabPaid = e.TabPaid
                                }
                        );

                return query.ToArray();
            }
        }


        public IEnumerable<Tab> GetTabsDropDown()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Tabs.ToList();
            }

        }



        public TabDetail GetTabById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tabs
                        .Single(e => e.TabId == id);
                return
                    new TabDetail
                    {
                        TabId = entity.TabId,
                        Name = entity.Name,
                        GrandTotal = entity.GrandTotal,
                        ModifiedUtc = entity.ModifiedUtc,
                        CreatedUtc = entity.CreatedUtc
                    };
            }

        }


        public bool UpdateTab(TabEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tabs
                        .Single(e => e.TabId == model.TabId);

                entity.TabId = model.TabId;
                entity.TabPaid = model.TabPaid;
                entity.Signature = model.Signature;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                
                //entity.InRotation = model.InRotation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTab(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tabs
                        .Single(e => e.TabId == noteId);

                ctx.Tabs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}