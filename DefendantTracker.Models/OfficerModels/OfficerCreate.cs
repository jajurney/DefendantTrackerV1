using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.OfficerModels
{
    public class OfficerCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DepartmentCity { get; set; }
        [Required]
        public string DepartmentCounty { get; set; }
        [Required]
        public string DepartmentState { get; set; }
        [Required]
        public int DepartmentZipcode { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
