using OLAssignment.BizRepository;
using OLAssignment.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OLAssignment.Controllers;
using Unity.Injection;

namespace OLAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IBizRepository<Student, int>, StudentBizRepo>();
            container.RegisterType<IBizRepository<Trainer, int>, TrainerBizRepo>();
            container.RegisterType<IBizRepository<Course, int>, CourseBizRepo>();
            container.RegisterType<IBizRepository<StudentCourse, int>, StudentCourseRepo>();
            container.RegisterType<IBizRepository<Module, int>, ModuleRepo>();
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<RoleController>(new InjectionConstructor());


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}