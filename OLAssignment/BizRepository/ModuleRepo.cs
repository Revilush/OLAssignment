using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public class ModuleRepo : IBizRepository<Module, int>
    {
        OLDbContext ctx;

        public ModuleRepo()
        {
            ctx = new OLDbContext();
        }

        public Module Create(Module entity)
        {
            entity = ctx.Modules.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Modules.Find(id);
            if (res == null) return false;
            ctx.Modules.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Module> GetData()
        {
            var res = ctx.Modules.ToList();
            return res;
        }

        public Module GetData(int id)
        {
            var res = ctx.Modules.Find(id);
            return res;
        }

        public Module Update(int id, Module entity)
        {
            var res = ctx.Modules.Find(id);
            if (res != null)
            {
                res.MName = entity.MName;
                res.MContent = entity.MContent;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}