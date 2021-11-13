using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CalculusDepreciation
    {
        public int id { get; set; }
        public int processYear { get; set; }
        public int processMonth { get; set; }
        public int fixedAssetId { get; set; }
        public FixedAsset fixedAsset { get; set; }
        public DateTime processDate { get; set; }
        public double deprecciatedAmount { get; set; }
        public double deprecciatedAcumulated { get; set; }
        public int purchaseAccount { get; set; }
        public int deprecciatedAccount { get; set; }
    }
}
