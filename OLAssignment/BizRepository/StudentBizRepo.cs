    using OLAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public class StudentBizRepo : IBizRepository<Student, int>
    {
         OLDbContext ctx;

        public StudentBizRepo()
        {
            ctx = new OLDbContext();
        }

        public Student Create(Student entity)
        {
            entity = ctx.Students.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Students.Find(id);
            if (res == null) return false;
            ctx.Students.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Student> GetData()
        {
            var res = ctx.Students.ToList();
            return res;
        }

        public Student GetData(int id)
        {
            var res = ctx.Students.Find(id);
            return res;
        }

        public Student Update(int id, Student entity)
        {
            var res = ctx.Students.Find(id);
            if (res != null)
            {
                res.StudentId = entity.StudentId;
                res.StudentName = entity.StudentName;
                res.Address = entity.Address;
                res.DOB= entity.DOB;
                res.Interest = entity.Interest;
                res.MobNo = entity.MobNo;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}