using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.DefenseAttorneyModels
{
    public class DefenseAttorneyListItem
    {
        public Guid DefenseAttorneyID { get; set; }
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
    }
}
