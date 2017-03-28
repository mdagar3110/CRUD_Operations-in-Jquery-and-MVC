using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentAPI_Start.DAL
{
    public class Student
    {
        //[Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    public class StudentDetails : Student
    {
        [Key]
        public int StudentDetailsId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }

    public class StudentLogin : Student
    {
        [Key]
        public int StudentLoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}