using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ArrestModels
{
    public class ArrestListItem
    {
        [Display(Name = "Arrest Id:")]
        public int ArrestID { get; set; }
        [Display(Name = "Arrest Date:")]
        public DateTime ArrestDate { get; set; }
        [Display(Name = "Street Name:")]
        public string StreetName { get; set; }
        [Display(Name = "Arrest City:")]
        public string ArrestCity { get; set; }
        [Display(Name = "Arrest County:")]
        public string ArrestCounty { get; set; }
        [Display(Name = "Arrest State:")]
        public string ArrestState { get; set; }
        [Display(Name = "Arrest Zipcode:")]
        public int ArrestZipcode { get; set; }
        [Display(Name = "Arrest Description:")]
        public string ArrestDesc { get; set; }
        [Display(Name = "Defendant Id:")]
        public int DefendantID { get; set; }
        [Display(Name = "Defendant Name:")]
        public string DFullName { get; set; }
        [Display(Name = "Defendant Location:")]
        public string FullLocation { get; set; }
        [Display(Name = "Officer Id:")]
        public int OfficerID { get; set; }
        [Display(Name = "Badge Number:")]
        public int BadgeID{ get; set; }
        [Display(Name = "Officer Name:")]
        public string OFullName { get; set; }
        [Display(Name = "Department Name:")]
        public string DepartmentName { get; set; }
        [Display(Name = "Department Location:")]
        public string DepartmentLocation { get; set; }
    }
}
