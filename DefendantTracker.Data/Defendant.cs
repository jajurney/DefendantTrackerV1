using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class Defendant
    {
        [Key]
        public Guid DefendantID { get; set; }
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
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public string FullLocation
        {
            get
            {
                return StreetAddress + " " + City + " " + County + " " + State + " " + Zipcode;
            }
            set { }
        }
        public bool Prosecuted { get; set; }
        public bool Arested { get; set; }
        // [ForeignKey(nameof(StateAttorneyID))]
        // public virtual StateAttorney StateAttorney { get; set; }
        // [ForeignKey(nameof(DefenseAttorneyID))]
        // public virtual DefenseAttorney DefenseAttorney { get; set; }
        // [ForeignKey(nameof(OfficerID))]
        // public virtual Officer Officer { get; set; }
        // public List<CourtHearing> CourtHearings { get; set; } = new List<CourtHearing>();
        //public List<Conviction> Convictions { get; set; } = new List<Conviction>();
        //public List<Arrest> Arrests { get; set; } = new List<Arrest>();
    }
}
