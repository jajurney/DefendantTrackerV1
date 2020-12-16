using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.DefendantModels
{
    public class DefendantListItem
    {
        public Guid DefendantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
   
        public bool Prosecuted { get; set; }
        public bool Arrested { get; set; }
    }
}
