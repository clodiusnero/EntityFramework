using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Uppgift 1

namespace lab_6.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }

        public Student(string lastName, string firstMidName, DateTime enrollmentdate)
        {
            this.Enrollments = new HashSet<Enrollment>();
            LastName = lastName;
            FirstMidName = firstMidName;
            EnrollmentDate = enrollmentdate;
        }
    }
}
