using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.OfficerModels
{
    public class OfficerDetails
    {
        public Guid OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
        public string DepartmentCity { get; set; }
        public string DepartmentCounty { get; set; }
        public string DepartmentState { get; set; }
        public int DepartmentZipcode { get; set; }
        public string DepartmentLocation
        {
            get
            {
                return DepartmentCity + " " + DepartmentCounty + " " + DepartmentState + " " + DepartmentZipcode;
            }
            set { }
        }
        public string DepartmentName { get; set; }
    }
}
