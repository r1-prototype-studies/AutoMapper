using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class Employee
    {
        public Name EmployeeName { get; set; }
        public int Salary { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
