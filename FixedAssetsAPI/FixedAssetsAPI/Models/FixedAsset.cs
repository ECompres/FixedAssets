using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class FixedAsset
    {
        public int id { get; set; }
        public string description { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }
        public int activeTypeId { get; set; }
        public ActiveType activeType { get; set; }
        public DateTime admissionDate { get; set; }
        public double purchaseValue { get; set; }
        public double depreciationAccumulated { get; set; }
        public CalculusDepreciation calculusDepreciation { get; set; }
    }
}
