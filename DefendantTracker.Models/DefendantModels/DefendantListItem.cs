using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.DefendantModels
{
    public class DefendantListItem
    {
        [Display(Name = "Defendant Id:")]
        public int DefendantID { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
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
        [Display(Name = "Prosecuted")]
        public bool Prosecuted { get; set; }
        [Display(Name = "Arrested:")]
        public bool Arrested { get; set; }
    }
}
