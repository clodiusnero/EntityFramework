using System;
using System.Data.Entity;
using System.Linq;
using lab_6.Models;

// Uppgift 1

namespace lab_6
{

    public class ADOschool : DbContext
    {
        public ADOschool()
            : base("name=ADOschool")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}