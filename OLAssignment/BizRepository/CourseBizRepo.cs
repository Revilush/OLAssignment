using OLAssignment.BizRepository;
using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public class CourseBizRepo : IBizRepository<Course , int>
    {
         OLDbContext ctx;

        public CourseBizRepo()
        {
            ctx = new OLDbContext();
        }

        public Course Create(Course entity)
        {
            entity = ctx.Courses.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Courses.Find(id);
            if (res == null) return false;
            ctx.Courses.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Course> GetData()
        {
            var res = ctx.Courses.ToList();
            return res;
        }

        public Course GetData(int id)
        {
            var res = ctx.Courses.Find(id);
            return res;
        }

        public Course Update(int id, Course entity)
        {
            var res = ctx.Courses.Find(id);
            if (res != null)
            {
                res.CourseId = entity.CourseId;
                res.CourseName = entity.CourseName;
                res.Description= entity.Description;
                res.Price = entity.Price;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}