using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.CourtHearingModels
{
    public class CourtHearingListItem
    {
        [Display(Name = "Court Hearing Id:")]
        public int CourtHearingID { get; set; }
        [Display(Name = "Description:")]
        public string HearingDesc { get; set; }
        [Display(Name = "Court Date:")]
        public DateTime CourtDate { get; set; }
        [Display(Name = "Address:")]
        public string CourtAddress { get; set; }
        [Display(Name = "City:")]
        public string CourtCity { get; set; }
        [Display(Name = "County:")]
        public string CourtCounty { get; set; }
        [Display(Name = "State:")]
        public string CourtState { get; set; }
        [Display(Name = "Zipcode:")]
        public int CourtZipcode { get; set; }
        [Display(Name = "Address:")]
        public string FullLocation
        {
            get
            {
                return CourtAddress + " " + CourtCity + " " + CourtCounty + " " + CourtState + " " + CourtZipcode;
            }
            set { }
        }
        [Display(Name = "State Attorney Id:")]
        public int StateAttorneyID { get; set; }
        [Display(Name = "State Attorney Name:")]
        public string SAFullName { get; set; }
        [Display(Name = "Defense Attorney Id:")]
        public int DefenseAttorneyID { get; set; }
        [Display(Name = "Defense Attorney Name:")]
        public string DAFullName { get; set; }
        [Display(Name = "Officer Id:")]
        public int OfficerID { get; set; }
        [Display(Name = "Officer Name:")]
        public string OFullName{ get; set; }
        [Display(Name = "Defendant Id:")]
        public int DefendantID { get; set; }
        [Display(Name = "Defendant Name:")]
        public string DFullName { get; set; }
        [Display(Name = "Arrest Id:")]
        public int ArrestID { get; set; }

    }
}
