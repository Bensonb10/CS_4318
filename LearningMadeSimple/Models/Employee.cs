using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningMadeSimple.Models
{
    public class Employee
    {
        internal DB Db { get; set; }
        public Department Department { get; set; }
        public int Employee_id { get; set; }
        public int Manager_id { get; set; }
        public string Date_hired { get; set; }
        public int Salary { get; set; }
        public enum Role { Admin, Instructor }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip_code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Employee() { }
        public Employee(DB db) { Db = db; }
    }
}
