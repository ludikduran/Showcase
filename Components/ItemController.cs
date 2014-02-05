using System;
using System.Collections.Generic;
using DotNetNuke.Data;

namespace LD2.Showcase.Components
{
    public class ItemController
    {
        // Create
        public void CreateItem(Item i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Insert(i);
            }
        }

        // Delete
        public void DeleteItem(int i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Delete("WHERE Itm = @0", i);
            }
        }

        // Get
        public Item GetItem(int itm)
        {
            Item x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                x = rep.GetById(itm);
            }
            return x;
        }

        // Get All
        public IEnumerable<Item> GetItems()
        {
            IEnumerable<Item> x;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                x = rep.Get();
            }
            return x;
        }

        // Update
        public void UpdateItem(Item itm)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Item>();
                rep.Update(itm);
            }
        }
    }
}