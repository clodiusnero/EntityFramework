using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;
using System.Data.Entity;
namespace lab_6
{
    class Tools
    {
        public void SearchStudent()
        {
                using (var ctx = new ADOschool())
                {
                ctx.Configuration.LazyLoadingEnabled = false;
                Console.Write("Please Enter Name: ");
                    var userQuery = Console.ReadLine();
                    var student = ctx.Students.Where(x => x.FirstMidName.StartsWith(userQuery)).FirstOrDefault();

                    if (student != null)
                    {

                        Console.WriteLine($"ID: {student.ID}. Name: {student.FirstMidName} {student.LastName}.");
                        Console.WriteLine("---------------------------------------------------------------------------");

                        ctx.Entry(student).Collection(x => x.Enrollments).Load();
                        var recordCount = 0;
                        foreach (var enrollment in student.Enrollments)
                        {
                            recordCount++;
                            Console.WriteLine($"{recordCount}. ID {enrollment.EnrollmentID} Enrollment: {enrollment.EnrollmentName} Course ID: {enrollment.CourseID} Grade: {enrollment.Grade}");
                            Console.WriteLine("---------------------------------------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo record of your query in the database. Press any key to continue...");
                    }

                }
                Console.Write($"\n\nExlplicit loading.\nPress any key to continue...");
                Console.ReadKey();
        }

        public void SearchStudentWithInclude()
        {
                using (var ctx = new ADOschool())
                {
                ctx.Configuration.LazyLoadingEnabled = false;
                Console.Write("Please Enter Name: ");
                    var userQuery = Console.ReadLine();
                    var student = ctx.Students.Include(x => x.Enrollments.Select(y => y.CourseID)).FirstOrDefault();

                    if (student != null)
                    {

                        Console.WriteLine($"ID: {student.ID}. Name: {student.FirstMidName} {student.LastName}.");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        ctx.Entry(student).Collection(x => x.Enrollments).Load();
                        var recordCount = 0;
                        foreach (var enrollment in student.Enrollments)
                        {
                            recordCount++;
                            Console.WriteLine($"{recordCount}. ID {enrollment.EnrollmentID} Enrollment: {enrollment.EnrollmentName} Course ID: {enrollment.CourseID} Grade: {enrollment.Grade}");
                            Console.WriteLine("---------------------------------------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo record of your query in the database. Press any key to continue...");
                    }

                }
                Console.Write($"\n\nExlplicit loading.\nPress any key to continue...");
                Console.ReadKey();
        }


        public void PrintStudents()
        {
                using (var ctx = new ADOschool())
                {
                    var query = from it in ctx.Students
                                orderby it.ID, it.FirstMidName, it.LastName
                                select it;

                    var counter = 0;
                    foreach (Student student in query)
                    {
                        counter++;
                        Console.WriteLine($"{counter}. ID: {student.ID}. Student Name{student.FirstMidName} {student.LastName}\n---------------------------------------------------------------------------");
                    }
                }
                Console.Write($"\n\nExlplicit loading.\nPress any key to continue...");
                Console.ReadKey();
        }

    }
}
