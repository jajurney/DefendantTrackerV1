using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.OfficerModels
{
    public class OfficerDetails
    {
        [Display(Name = "Officer Id:")]
        public int OfficerID { get; set; }
        [Display(Name = "Badge Id:")]
        public int BadgeID { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Full Name:")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
        [Display(Name = "Department City:")]
        public string DepartmentCity { get; set; }
        [Display(Name = "Department County:")]
        public string DepartmentCounty { get; set; }
        [Display(Name = "Department State:")]
        public string DepartmentState { get; set; }
        [Display(Name = "Department Zipcode:")]
        public int DepartmentZipcode { get; set; }
        [Display(Name = "Department Location:")]
        public string DepartmentLocation
        {
            get
            {
                return DepartmentCity + " " + DepartmentCounty + " " + DepartmentState + " " + DepartmentZipcode;
            }
            set { }
        }
        [Display(Name = "Department Name:")]
        public string DepartmentName { get; set; }
    }
}
