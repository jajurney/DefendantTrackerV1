using DefendantTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ConvictionModels
{
    public class ConvictionEdit
    {
        public int ConvicID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public DateTime DateOfConviction { get; set; }
        public ConvictionSeverity ConvictionSeverity { get; set; }
    }
}
