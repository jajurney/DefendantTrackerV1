using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class DefenseAttorney
    {
        [Key]
        public int DefenseAttorneyID { get; set; }
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
    }
}
