using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public AddressDTO Address { get; set; }
        public string Dept { get; set; }
    }

    public class AddressDTO
    {
        public string City { get; set; }
        public string State { get; set; }
    }
}
