using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.OfficerModels
{
    public class OfficerListItem
    {
        [Display(Name = "Officer Id:")]
        public int OfficerID { get; set; }
        [Display(Name = "Badge Id:")]
        public int BadgeID { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Department City:")]
        public string DepartmentCity { get; set; }
        [Display(Name = "Department County:")]
        public string DepartmentCounty { get; set; }
        [Display(Name = "Department State:")]
        public string DepartmentState { get; set; }
        [Display(Name = "Department Zipcode:")]
        public int DepartmentZipcode { get; set; }
        [Display(Name = "Department Name:")]
        public string DepartmentName { get; set; }
    }
}
