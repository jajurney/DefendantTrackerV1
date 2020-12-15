using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class Officer
    {
        [Key]
        public Guid OfficerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
        [Required]
        public string DepartmentCity { get; set; }
        [Required]
        public string DepartmentCounty { get; set; }
        [Required]
        public string DepartmentState { get; set; }
        [Required]
        public int DepartmentZipcode { get; set; }
        [Required]
        public string DepartmentLocation
        {
            get
            {
                return DepartmentCity + " " + DepartmentCounty + " " + DepartmentState + " " + DepartmentZipcode;
            }
            set { }
        }
        [Required]
        public string DepartmentName { get; set; }
    }
}
