using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; } 
        public int Credits { get; set; }

        public Course(string courseName, int credits)
        {
            CourseName = courseName;
            Credits = credits;
    }
    }
}
