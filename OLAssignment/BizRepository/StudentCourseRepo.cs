using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public class StudentCourseRepo: IBizRepository<StudentCourse, int>
    {
        OLDbContext ctx;

        public StudentCourseRepo()
        {
            ctx = new OLDbContext();
        }

 
        public StudentCourse GetData(int id)
        {
            var res = ctx.StudentCourses.Find(id);
            return res;
        }

        public List<StudentCourse> GetData()
        {
            var res = ctx.StudentCourses.ToList();
            return res;
        }

        public StudentCourse Create(StudentCourse entity)
        {
            entity = ctx.StudentCourses.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public StudentCourse Update(int id, StudentCourse entity)
        {
            var res = ctx.StudentCourses.Find(id);
            if (res != null)
            {
                res.Status = entity.Status;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.StudentCourses.Find(id);
            if (res == null) return false;
            ctx.StudentCourses.Remove(res);
            ctx.SaveChanges();
            return true;
        }

    }
}