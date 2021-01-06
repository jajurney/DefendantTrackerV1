using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.StateAttorneyModels
{
    public class StateAttorneyListItem
    {
        [Display(Name = "State Attorney Id:")]
        public int StateAttorneyID { get; set; }
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
    }
}
