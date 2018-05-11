using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApartmentFinal.Models
{
    public class Report
    {
        public int ID { get; set; }
        public string RegionId { get; set; }
        public int NumOfOrders{ get; set; }
        public int PercentageFromTotal { get; set; }
    }
}