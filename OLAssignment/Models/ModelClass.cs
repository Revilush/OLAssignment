using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OLAssignment.Models
{
    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }

        public string CourseId { get; set; }

        [Required(ErrorMessage = "Category Name is Must")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Description is Must")]
        [StringLength(500, ErrorMessage = "Description can be 500 characters max")]
        public string Description { get; set; }

        [Required(ErrorMessage = "No oF Modules is Must")]
        public int NoFMod { get; set; }
        
        public bool CStatus { get; set; }

        [Required(ErrorMessage = "Price is Must")]
        public int Price { get; set; }

        public int Rating { get; set; }

        // one to many relationship:
        //public virtual int TrainerRowId { get; set; }

        public virtual Trainer CTrainer  { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

    }

    public class Student 
    {
        [Key]
        public int StudentRowId { get; set; }

        [Required(ErrorMessage = "Student Id is Must")]
        [StringLength(50, ErrorMessage = "Trainer Id can be 50 characters max")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Student Name is Must")]
        [StringLength(200, ErrorMessage = "Student NAme can be 200 characters max")]
        //[Remote("CheckCapStudentName", "Student")]
        public string StudentName { get; set; }

        //[Required(ErrorMessage = "Email  is Must")]
        //[StringLength(50, ErrorMessage = "Email can be 50 characters max")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "Email  is Must")]
        [StringLength(50, ErrorMessage = "Email can be 50 characters max")]
        public string Address { get; set; }

        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "MobNo  is Must")]
        [StringLength(10, ErrorMessage = "MobNo can be 10 characters max")]
        public string MobNo { get; set; }

        [Required(ErrorMessage = "Interest  is Must")]
        [StringLength(50, ErrorMessage = "Interest can be 50 characters max")]
        public string Interest { get; set; }

        public string Id { get; set; }
    }


    public class Trainer 
    {
        [Key]
        public int TrainerRowId { get; set; }

        [Required(ErrorMessage = "Trainer Id is Must")]
        [StringLength(50, ErrorMessage = "Trainer Id can be 50 characters max")]
        public string TrainerId { get; set; }

        [Required(ErrorMessage = "Trainer Name is Must")]
        [StringLength(200, ErrorMessage = "Trainer NAme can be 200 characters max")]
            //[Remote("CheckCapProductName", "Trainer")]
        public string TrainerName { get; set; }

        [Required(ErrorMessage = "Expertise  is Must")]
        [StringLength(300, ErrorMessage = "Expertise can be 300 characters max")]
        public string Exp { get; set; }

        public string Id { get; set; }
    }


    public class StudentCourse
    {
        [Key]
        public int RowId { get; set; }

        public virtual Course CourseId { get; set; }
        public virtual Student StudentId { get; set; }
        public int Status { get; set; }
    }

    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required(ErrorMessage = "Module Id is Must")]
        public int MId { get; set; }

        [Required(ErrorMessage = "Module Name  is Must")]
        public int MName { get; set; }

        [Required(ErrorMessage = "Module Content is Must")]
        public int MContent { get; set; }

        //public int CourseRowId { get; set; }

        public virtual Course CourseRowId { get; set; }

    }

    //    public class TrainerCourse
    //    {
    //        [Key]
    //        public int RowId { get; set; }

    //        public string CourseId { get; set; }
    //        public string TrainerId { get; set; }

    //    }


}