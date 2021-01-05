using DefendantTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ConvictionModels
{
    public class ConvictionListItem
    {
        public int ConvicID { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string FullLocation
        {
            get
            {
                return StreetAddress + " " + City + " " + County + " " + State + " " + Zipcode;
            }
            set { }
        }
        public DateTime DateOfConviction { get; set; }
        public ConvictionSeverity ConvictionSeverity { get; set; }
        public int ArrestID { get; set; }
        public int DefendantID { get; set; }
        public int CourtHearingID { get; set; }

    }
}
