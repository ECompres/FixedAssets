using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string documentId { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }
        public string personType { get; set; }
        public DateTime admissionDate { get; set; }
        public bool status { get; set; }
    }
}
