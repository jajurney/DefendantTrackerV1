using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.DefenseAttorneyModels
{
    public class DefenseAttorneyDetails
    {
        public Guid DefenseAttorneyID { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
    }
}
