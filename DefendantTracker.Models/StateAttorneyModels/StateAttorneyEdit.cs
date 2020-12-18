using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.StateAttorneyModels
{
    public class StateAttorneyEdit
    {
        public Guid StateAttorneyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
