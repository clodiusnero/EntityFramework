using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using System.Data.Entity;

namespace lab_6
{
    public class DBinitilizer : DropCreateDatabaseAlways<ADOschool>
    {
        public void SeedDb()
        {
            using (var ctx = new ADOschool())
            {
                //Enrollment enrollment1 = new Enrollment(".NET Webbutveckling", "IG, G, VG");
                //Enrollment enrollment2 = new Enrollment(".NET Entity", "IG, G, VG");
                //Enrollment enrollment3 = new Enrollment(".NET Jaded", "IG, G, VG");
                //ctx.Enrollments.Add(enrollment1);
                //ctx.Enrollments.Add(enrollment2);
                //ctx.Enrollments.Add(enrollment3);
                //ctx.SaveChanges();

                Course course1 = new Course("Joadå", 100);
                Course course2 = new Course(".Man", 10);
                Course course3 = new Course(".Kvinna", 10);
                ctx.Courses.Add(course1);
                ctx.Courses.Add(course2);
                ctx.Courses.Add(course3);
                ctx.SaveChanges();

                Student student1 = new Student("Johan", "Larsson", new DateTime(2005,05,05));
                Student student2 = new Student("Anders", "Johansson", new DateTime(2006,05,05));
                Student student3 = new Student("Lisa", "Frankenstein", new DateTime(2007,05,05));
                ctx.Students.Add(student1);
                ctx.Students.Add(student2);
                ctx.Students.Add(student3);
                ctx.SaveChanges();


                Enrollment enrollment5 = new Enrollment ( "Johan", "A" );
                ctx.Enrollments.Add(enrollment5);
                ctx.SaveChanges();
            }
        }
    }
}
