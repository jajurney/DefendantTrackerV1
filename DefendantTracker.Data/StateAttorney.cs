using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class StateAttorney
    {
        [Key]
        public Guid DefenseAttorneyID { get; set; }
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
        //public List<CourtHearing> CourtHearings { get; set; } = new List<CourtHearing>();
        //public List<Conviction> Convictions { get; set; } = new List<Conviction>();

    }
}
