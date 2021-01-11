using DefendantTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ConvictionModels
{
    public class ConvictionListItem
    {
        [Display(Name = "Conviction Id:")]
        public int ConvicID { get; set; }
        [Display(Name = "Street Address:")]
        public string StreetAddress { get; set; }
        [Display(Name = "City:")]
        public string City { get; set; }
        [Display(Name = "County:")]
        public string County { get; set; }
        [Display(Name = "State:")]
        public string State { get; set; }
        [Display(Name = "Zipcode:")]
        public int Zipcode { get; set; }
        [Display(Name = "Full Location:")]
        public string FullLocation
        {
            get
            {
                return StreetAddress + " " + City + " " + County + " " + State + " " + Zipcode;
            }
            set { }
        }
        [Display(Name = "Conviction Date:")]
        public DateTime DateOfConviction { get; set; }
        [Display(Name = "Conviction Level:")]
        public ConvictionSeverity ConvictionSeverity { get; set; }
        [Display(Name = "Arrest Id:")]
        public int ArrestID { get; set; }
        [Display(Name = "Defendant Id:")]
        public int DefendantID { get; set; }
        [Display(Name = "Defendant Name:")]
        public string DFullName { get; set; }
        [Display(Name = "Court Hearing Id:")]
        public int CourtHearingID { get; set; }

    }
}
