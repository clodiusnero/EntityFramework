﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public string EnrollmentName { get; set; }
        public string CourseID { get; set; }
        public string Grade  { get; set; }

        public Enrollment(string enrollmentName, string grade)
        {
            EnrollmentName = enrollmentName;
            Grade = grade;
        }
    }
}