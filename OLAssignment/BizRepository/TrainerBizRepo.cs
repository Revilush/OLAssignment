using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public class TrainerBizRepo : IBizRepository<Trainer, int>
    {
        OLDbContext ctx;

        public TrainerBizRepo()
        {
            ctx = new OLDbContext();
        }

        public Trainer Create(Trainer entity)
        {
            entity = ctx.Trainers.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Trainers.Find(id);
            if (res == null) return false;
            ctx.Trainers.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Trainer> GetData()
        {
            var res = ctx.Trainers.ToList();
            return res;
        }

        public Trainer GetData(int id)
        {
            var res = ctx.Trainers.Find(id);
            return res;
        }

        public Trainer Update(int id, Trainer entity)
        {
            var res = ctx.Trainers.Find(id);
            if (res != null)
            {
                //res.TrainerId = entity.TrainerId;
                res.TrainerName= entity.TrainerName;
                res.Exp = entity.Exp;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }
}