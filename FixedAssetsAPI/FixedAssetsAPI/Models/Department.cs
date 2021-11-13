using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public List<Employee> employees { get; set; }
        public FixedAsset fixedAsset { get; set; }
    }
}
