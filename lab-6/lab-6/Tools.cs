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
        // Uppgift 1 och 3
        public void PrintStudents()
        {
            using (var ctx = new ADOschool())
            {

                var students = ctx.Students.Include(x => x.Enrollments.Select(c => c));

                var recordCount = 0;
                var enrollmentCount = 0;

                foreach (var student in students)
                {
                    recordCount++;
                    Console.WriteLine($"{recordCount}. ID: {student.ID}. Name: {student.FirstMidName} {student.LastName}.");

                    foreach (var enrollment in student.Enrollments)
                    {
                        enrollmentCount++;
                        Console.WriteLine($"{enrollmentCount}. Enrollment name: {enrollment.EnrollmentName}  Course name: {enrollment.Course.CourseName} Grade: {enrollment.Grade}");
                    }
                    Console.WriteLine("---------------------------------------------------------------------------");
                }

            }
        }


        // Uppgift 4
        public void SearchStudentFirstMidName()
        {
            using (var ctx = new ADOschool())
            {
                // Uppgift 4, Punkt 1
                ctx.Configuration.LazyLoadingEnabled = false;

                // Uppgift 4, punkt 2
                Console.Write("Please Enter Name: ");
                var userQuery = Console.ReadLine();
                var student = ctx.Students.Where(x => x.FirstMidName.StartsWith(userQuery)).FirstOrDefault();

                if (student != null)
                {

                    Console.WriteLine($"ID: {student.ID}. Name: {student.FirstMidName} {student.LastName}.");
                    Console.WriteLine("---------------------------------------------------------------------------");

                    // Uppgift 4, punkt 5
                    ctx.Entry(student).Collection(x => x.Enrollments).Load();

                    var recordCount = 0;

                    // Uppgift 4, punkt 6
                    foreach (var enrollment in student.Enrollments)
                    {
                        recordCount++;

                        //Uppgift 4, punkt 7
                        Console.WriteLine($"{recordCount}. ID {enrollment.EnrollmentID} Enrollment: {enrollment.EnrollmentName} Course ID: {enrollment.Course.CourseID} Course Name: {enrollment.Course.CourseName} Grade: {enrollment.Grade}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo record of your query in the database. Press any key to continue...");
                }

            }
            // Uppgift 4, punkt 4
            Console.Write("\n\nUsing Exlplicit loading.\nPress any key to continue...");
            Console.ReadKey();
        }

        public void SearchStudentWithInclude()
        {
            using (var ctx = new ADOschool())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                Console.Write("Please Enter Name: ");
                var userQuery = Console.ReadLine();

                // Uppgift 4, punkt 3
                var student = ctx.Students.Where(x => x.FirstMidName.StartsWith(userQuery)).Include(x => x.Enrollments.Select(c => c.Course)).FirstOrDefault();

                if (student != null)
                {

                    Console.WriteLine($"ID: {student.ID}. Name: {student.FirstMidName} {student.LastName}.");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    ctx.Entry(student).Collection(x => x.Enrollments).Load();
                    var recordCount = 0;
                    foreach (var enrollment in student.Enrollments)
                    {
                        recordCount++;
                        Console.WriteLine($"{recordCount}. ID {enrollment.EnrollmentID} Enrollment: {enrollment.EnrollmentName} Course ID: {enrollment.Course.CourseID} Course Name: {enrollment.Course.CourseName} Grade: {enrollment.Grade}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo record of your query in the database. Press any key to continue...");
                }

            }
            Console.Write("\n\nUsing Exlplicit loading.\nPress any key to continue...");
            Console.ReadKey();
        }

        }
    }
