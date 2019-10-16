using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeMajorsMVVM.Models
{
    public class Major
    {
        public string Name { get; set; }
        public int TotalMen { get; set; }
        public int TotalWomen { get; set; }
        public string Category { get; set; }
        public int TotalEmployed { get; set; }
        public int TotalUnemployed { get; set; }

        public int NumberOfStudents
        {
            get
            {
                return TotalMen + TotalWomen;
            }
        }
        public double ShareOfWomen
        {
            get
            {
                return Math.Round(Convert.ToDouble(TotalWomen) / NumberOfStudents * 10000.0) / 100.0;
            }
        }
        public double UnemploymentRate
        {
            get
            {
                return Math.Round(Convert.ToDouble(TotalEmployed) / NumberOfStudents * 10000.0) / 100.0;
            }
        }
    }
}
